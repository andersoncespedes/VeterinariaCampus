using System.Globalization;
using System.Reflection;
using CsvHelper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Data;

namespace Persistence;

public class APIContextSeeder
{
    public static async Task SeedAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = "C:/Users/janus/Desktop/ProyectoAnderson/VeterinariaCampus/Persistence/Data/Csvs/";

            if (!context.Laboratorios.Any())
            {
                using (var readerLaboratorio = new StreamReader(ruta + @"Laboratorio.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<Laboratorio>();
                        context.Laboratorios.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Medicamentos.Any())
            {
                using (var readerMedicamento = new StreamReader(ruta + @"Medicamento.csv"))
                {
                    using (var csvMedicamento = new CsvReader(readerMedicamento, CultureInfo.InvariantCulture))
                    {
                        var Medic = csvMedicamento.GetRecords<Medicamento>();
                        context.Medicamentos.AddRange(Medic);
                        await context.SaveChangesAsync();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<APIContext>();
            logger.LogError(ex.Message);
        }
    }

    public static async Task SeedRolesAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Rol>()
                        {
                             new Rol { Id = 1, Nombre = "Empleado" },
                             new Rol { Id = 2, Nombre = "Administrador" }
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<APIContext>();
            logger.LogError(ex.Message);
        }
    }
}