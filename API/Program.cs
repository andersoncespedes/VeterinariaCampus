using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using API.Extensions;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using Serilog;
using Persistence;
using API.Helpers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.|
var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureRatelimiting();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddSwaggerGen(options =>
{
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); 
});
builder.Services.AddAuthorization(opts =>
{
    opts.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddRequirements(new GlobalVerbRoleRequirement())
        .Build();
});

builder.Services.ConfigureJson();
builder.Services.AddDbContext<APIContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<APIContext>();
        await context.Database.MigrateAsync();
        await APIContextSeeder.SeedVeterinarioAsync(context, loggerFactory);
        await APIContextSeeder.SeedLabAsync(context, loggerFactory);
        await APIContextSeeder.SeedEspeciesAsync(context, loggerFactory);
        await APIContextSeeder.SeedPropietariosAsync(context, loggerFactory);
        await APIContextSeeder.SeedProveedorAsync(context, loggerFactory);
        await APIContextSeeder.SeedTipoMovAsync(context, loggerFactory);
        await APIContextSeeder.SeedRolesAsync(context, loggerFactory);
        await APIContextSeeder.SeedRazasAsync(context, loggerFactory);
        await APIContextSeeder.SeedMovMedAsync(context, loggerFactory);
        await APIContextSeeder.SeedAsync(context, loggerFactory);
        await APIContextSeeder.SeedDetalMovAsync(context, loggerFactory);
        await APIContextSeeder.SeedCitasAsync(context, loggerFactory);
        await APIContextSeeder.SeedMedProvAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogError(ex, "Ocurrio un error durante la migracion");
    }
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseIpRateLimiting();

app.MapControllers();


app.Run();