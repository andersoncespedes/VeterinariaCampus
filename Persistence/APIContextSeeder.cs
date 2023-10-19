using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
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
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!context.Proveedores.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Proveedor.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<Proveedor>();
                        context.Proveedores.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Propietarios.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Propietario.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<Propietario>();
                        context.Propietarios.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposMovimientos.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/TipoMovimiento.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<TipoMovimiento>();
                        context.TiposMovimientos.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposMovimientos.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/TipoMovimiento.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<TipoMovimiento>();
                        context.TiposMovimientos.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Especies.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Especie.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var especie = csvLaboratorio.GetRecords<Especie>();
                        context.Especies.AddRange(especie);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Razas.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Raza.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var especie = csvLaboratorio.GetRecords<Raza>();
                        context.Razas.AddRange(especie);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Mascotas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Mascota.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Mascota>();
                        List<Mascota> entidad = new List<Mascota>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Mascota
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                FechaNacimiento = item.FechaNacimiento,
                                IdPropietarioFk = item.IdPropietarioFk,
                                IdRazaFk = item.IdRazaFk,
                                IdEspecieFk = item.IdEspecieFk
                            });
                        }
                        context.Mascotas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Medicamentos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Medicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Medicamento>();
                        List<Medicamento> entidad = new List<Medicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Medicamento
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                CantidadDisponible = item.CantidadDisponible,
                                Precio = item.Precio,
                                IdLaboratorioFk = item.IdLaboratorioFk,
                            });
                        }
                        context.Medicamentos.AddRange(entidad);
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