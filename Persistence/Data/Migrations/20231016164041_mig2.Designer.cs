﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20231016164041_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Citas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("time")
                        .HasColumnName("hora");

                    b.Property<int>("IdMascotaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdVeterinario")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("motivo");

                    b.HasKey("Id");

                    b.HasIndex("IdMascotaFk");

                    b.HasIndex("IdVeterinario");

                    b.ToTable("cita", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DetalleMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<int>("IdMovMedFk")
                        .HasColumnType("int");

                    b.Property<int>("IdProductoFk")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasPrecision(2, 8)
                        .HasColumnType("double")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.HasIndex("IdMovMedFk");

                    b.HasIndex("IdProductoFk");

                    b.ToTable("detalle_movimiento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Especie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("especie", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Laboratorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar")
                        .HasColumnName("direccion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.Property<int>("Telefono")
                        .HasColumnType("int")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("laboratorio", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date")
                        .HasColumnName("fecha_nacimiento");

                    b.Property<int>("IdEspecieFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPropietarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRazaFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecieFk");

                    b.HasIndex("IdPropietarioFk");

                    b.HasIndex("IdRazaFk");

                    b.ToTable("mascota", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CantidadDisponible")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("cantidad_disponible");

                    b.Property<int>("IdLaboratorioFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.Property<double>("Precio")
                        .HasPrecision(2, 6)
                        .HasColumnType("double")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.HasIndex("IdLaboratorioFk");

                    b.ToTable("medicamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedicamentoProveedores", b =>
                {
                    b.Property<int>("IdProveedorFk")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicamentoFk")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdProveedorFk", "IdMedicamentoFk");

                    b.HasIndex("IdMedicamentoFk");

                    b.ToTable("medicamento_proveedor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MovimientoMedicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<int>("IdTipoMovFk")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoMovFk");

                    b.ToTable("movimiento_medicamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Propietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("correo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.Property<int>("Telefono")
                        .HasColumnType("int")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("propietario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("direccion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.Property<int>("Telefono")
                        .HasColumnType("int")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("proveedor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEspecieFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecieFk");

                    b.ToTable("raza", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Empleado"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Administrador"
                        });
                });

            modelBuilder.Entity("Domain.Entities.RolesUsuarios", b =>
                {
                    b.Property<int>("IdUserFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdUserFk", "IdRolFk");

                    b.HasIndex("IdRolFk");

                    b.ToTable("usuarios_roles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipoMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("descripcion");

                    b.HasKey("Id");

                    b.ToTable("tipo_movimiento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TratamientoMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Dosis")
                        .HasColumnType("int")
                        .HasColumnName("dosis");

                    b.Property<DateOnly>("FechaAdministracion")
                        .HasColumnType("date")
                        .HasColumnName("fecha_administracion");

                    b.Property<int>("IdCitaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicamentoFk")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("observacion");

                    b.HasKey("Id");

                    b.HasIndex("IdCitaFk");

                    b.HasIndex("IdMedicamentoFk");

                    b.ToTable("tratamiento_medico", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("contraseña");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("correo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("correo");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("especialidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.Property<int>("Telefono")
                        .HasColumnType("int")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("veterinario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Citas", b =>
                {
                    b.HasOne("Domain.Entities.Mascota", "Mascota")
                        .WithMany("Citas")
                        .HasForeignKey("IdMascotaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Veterinario", "Veterinario")
                        .WithMany("Citas")
                        .HasForeignKey("IdVeterinario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("Domain.Entities.DetalleMovimiento", b =>
                {
                    b.HasOne("Domain.Entities.MovimientoMedicamento", "MovimientoMedicamento")
                        .WithMany("DetalleMovimientos")
                        .HasForeignKey("IdMovMedFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("DetalleMovimientos")
                        .HasForeignKey("IdProductoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("MovimientoMedicamento");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.HasOne("Domain.Entities.Especie", "Especie")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdEspecieFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Propietario", "Propietario")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdPropietarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Raza", "Raza")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdRazaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");

                    b.Navigation("Propietario");

                    b.Navigation("Raza");
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.HasOne("Domain.Entities.Laboratorio", "Laboratorio")
                        .WithMany("Medicamentos")
                        .HasForeignKey("IdLaboratorioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratorio");
                });

            modelBuilder.Entity("Domain.Entities.MedicamentoProveedores", b =>
                {
                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("MedicamentoProveedores")
                        .HasForeignKey("IdMedicamentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Proveedor", "Proveedor")
                        .WithMany("MedicamentoProveedores")
                        .HasForeignKey("IdProveedorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Domain.Entities.MovimientoMedicamento", b =>
                {
                    b.HasOne("Domain.Entities.TipoMovimiento", "TipoMovimiento")
                        .WithMany("MovimientoMedicamentos")
                        .HasForeignKey("IdTipoMovFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoMovimiento");
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.HasOne("Domain.Entities.Especie", "Especie")
                        .WithMany("Razas")
                        .HasForeignKey("IdEspecieFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.RolesUsuarios", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("IdUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.TratamientoMedico", b =>
                {
                    b.HasOne("Domain.Entities.Citas", "Citas")
                        .WithMany("TratamientoMedicos")
                        .HasForeignKey("IdCitaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("TratamientoMedicos")
                        .HasForeignKey("IdMedicamentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citas");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("Domain.Entities.Citas", b =>
                {
                    b.Navigation("TratamientoMedicos");
                });

            modelBuilder.Entity("Domain.Entities.Especie", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("Razas");
                });

            modelBuilder.Entity("Domain.Entities.Laboratorio", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.Navigation("DetalleMovimientos");

                    b.Navigation("MedicamentoProveedores");

                    b.Navigation("TratamientoMedicos");
                });

            modelBuilder.Entity("Domain.Entities.MovimientoMedicamento", b =>
                {
                    b.Navigation("DetalleMovimientos");
                });

            modelBuilder.Entity("Domain.Entities.Propietario", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Navigation("MedicamentoProveedores");
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("RolesUsuarios");
                });

            modelBuilder.Entity("Domain.Entities.TipoMovimiento", b =>
                {
                    b.Navigation("MovimientoMedicamentos");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("RolesUsuarios");
                });

            modelBuilder.Entity("Domain.Entities.Veterinario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
