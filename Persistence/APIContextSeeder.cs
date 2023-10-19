using System;
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
    public static async Task SeedProveedorAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {


            if (!context.Proveedores.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Proveedor.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var record = csvLaboratorio.GetRecords<Proveedor>();
                        context.Proveedores.AddRange(record);
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
    public static async Task SeedPropietariosAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Propietarios.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Propietario.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var record = csvLaboratorio.GetRecords<Propietario>();
                        context.Propietarios.AddRange(record);
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
    public static async Task SeedTipoMovAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.TiposMovimientos.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/TipoMovimiento.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var record = csvLaboratorio.GetRecords<TipoMovimiento>();
                        context.TiposMovimientos.AddRange(record);
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
    public static async Task SeedEspeciesAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Especies.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Especie.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var record = csvLaboratorio.GetRecords<Especie>();
                        context.Especies.AddRange(record);
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
    public static async Task SeedRazasAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Razas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Raza.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Raza>();
                        List<Raza> entidad = new List<Raza>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Raza
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                IdEspecieFk = item.IdEspecieFk,
                            });
                        }
                        context.Razas.AddRange(entidad);
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
    public static async Task SeedCitasAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Citas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Cita.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Citas>();
                        List<Citas> entidad = new List<Citas>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Citas
                            {
                                Id = item.Id,
                                IdMascotaFk = item.IdMascotaFk,
                                Fecha = item.Fecha,
                                Hora = item.Hora,
                                Motivo = item.Motivo,
                                IdVeterinario = item.IdVeterinario,
                            });
                        }
                        context.Citas.AddRange(entidad);
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
    public static async Task SeedDetalMovAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.DetallesMovimientos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/DetalleMov.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<DetalleMovimiento>();
                        List<DetalleMovimiento> entidad = new List<DetalleMovimiento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new DetalleMovimiento
                            {
                                Id = item.Id,
                                IdProductoFk = item.IdProductoFk,
                                IdMovMedFk = item.IdMovMedFk,
                                Precio = item.Precio,
                                Cantidad = item.Cantidad,
                            });
                        }
                        context.DetallesMovimientos.AddRange(entidad);
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
    public static async Task SeedMedProvAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.MedicamentoProveedores.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/MedicamentoProveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MedicamentoProveedores>();
                        List<MedicamentoProveedores> entidad = new List<MedicamentoProveedores>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MedicamentoProveedores
                            {
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                IdProveedorFk = item.IdProveedorFk,
                            });
                        }
                        context.MedicamentoProveedores.AddRange(entidad);
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
    public static async Task SeedMovMedAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.MovimientosMedicamentos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/MovimientoMedicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MovimientoMedicamento>();
                        List<MovimientoMedicamento> entidad = new List<MovimientoMedicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MovimientoMedicamento
                            {
                                Id = item.Id,
                                IdTipoMovFk = item.IdTipoMovFk,
                                Fecha = item.Fecha,
                                Total = item.Total,
                            });
                        }
                        context.MovimientosMedicamentos.AddRange(entidad);
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
    public static async Task SeedVeterinarioAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Veterinarios.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Veterinario.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var record = csvLaboratorio.GetRecords<Veterinario>();
                        context.Veterinarios.AddRange(record);
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

    public static async Task SeedLabAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Laboratorios.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/laboratorio.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var record = csvLaboratorio.GetRecords<Laboratorio>();
                        context.Laboratorios.AddRange(record);
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
    public static async Task SeedAsync(APIContext context, ILoggerFactory loggerFactory)
    {
        try
        {
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