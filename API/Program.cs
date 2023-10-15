using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using API.Extensions;
using AspNetCoreRateLimit;
using System.Reflection;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.|

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseIpRateLimiting();

app.MapControllers();


app.Run();