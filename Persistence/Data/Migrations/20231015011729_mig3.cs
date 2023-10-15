using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especie", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "laboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratorio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "propietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    correo = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_movimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_movimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    correo = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contraseña = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    especialidad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "raza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEspecieFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_raza_especie_IdEspecieFk",
                        column: x => x.IdEspecieFk,
                        principalTable: "especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cantidad_disponible = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precion = table.Column<double>(type: "double", precision: 2, scale: 6, nullable: false),
                    IdLaboratorioFk = table.Column<int>(type: "int", nullable: false),
                    LaboratorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_laboratorio_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "laboratorio",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios_roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_roles", x => new { x.RolId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_usuarios_roles_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdPropietarioFk = table.Column<int>(type: "int", nullable: false),
                    IdEspecieFk = table.Column<int>(type: "int", nullable: false),
                    IdRazaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mascota_especie_IdEspecieFk",
                        column: x => x.IdEspecieFk,
                        principalTable: "especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascota_propietario_IdPropietarioFk",
                        column: x => x.IdPropietarioFk,
                        principalTable: "propietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascota_raza_IdRazaFk",
                        column: x => x.IdRazaFk,
                        principalTable: "raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento_proveedor",
                columns: table => new
                {
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento_proveedor", x => new { x.MedicamentoId, x.ProveedorId });
                    table.ForeignKey(
                        name: "FK_medicamento_proveedor_medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_proveedor_proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimiento_medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    IdTipoMovFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimiento_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimiento_medicamento_medicamento_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimiento_medicamento_tipo_movimiento_IdTipoMovFk",
                        column: x => x.IdTipoMovFk,
                        principalTable: "tipo_movimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMascotaFk = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    hora = table.Column<TimeOnly>(type: "time", nullable: false),
                    motivo = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdVeterinario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cita_mascota_IdMascotaFk",
                        column: x => x.IdMascotaFk,
                        principalTable: "mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cita_veterinario_IdVeterinario",
                        column: x => x.IdVeterinario,
                        principalTable: "veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_movimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    IdMovMedFk = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<double>(type: "double", precision: 2, scale: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_movimiento_medicamento_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_movimiento_movimiento_medicamento_IdMovMedFk",
                        column: x => x.IdMovMedFk,
                        principalTable: "movimiento_medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tratamiento_medico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCitaFk = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    dosis = table.Column<int>(type: "int", nullable: false),
                    fecha_administracion = table.Column<DateOnly>(type: "date", nullable: false),
                    observacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tratamiento_medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tratamiento_medico_cita_IdCitaFk",
                        column: x => x.IdCitaFk,
                        principalTable: "cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tratamiento_medico_medicamento_IdMedicamentoFk",
                        column: x => x.IdMedicamentoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cita_IdMascotaFk",
                table: "cita",
                column: "IdMascotaFk");

            migrationBuilder.CreateIndex(
                name: "IX_cita_IdVeterinario",
                table: "cita",
                column: "IdVeterinario");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_movimiento_IdMovMedFk",
                table: "detalle_movimiento",
                column: "IdMovMedFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_movimiento_IdProductoFk",
                table: "detalle_movimiento",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_IdEspecieFk",
                table: "mascota",
                column: "IdEspecieFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_IdPropietarioFk",
                table: "mascota",
                column: "IdPropietarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_IdRazaFk",
                table: "mascota",
                column: "IdRazaFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_LaboratorioId",
                table: "medicamento",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_proveedor_IdProveedorFk_IdMedicamentoFk",
                table: "medicamento_proveedor",
                columns: new[] { "IdProveedorFk", "IdMedicamentoFk" });

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_proveedor_ProveedorId",
                table: "medicamento_proveedor",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_medicamento_IdProductoFk",
                table: "movimiento_medicamento",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_medicamento_IdTipoMovFk",
                table: "movimiento_medicamento",
                column: "IdTipoMovFk");

            migrationBuilder.CreateIndex(
                name: "IX_raza_IdEspecieFk",
                table: "raza",
                column: "IdEspecieFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tratamiento_medico_IdCitaFk",
                table: "tratamiento_medico",
                column: "IdCitaFk");

            migrationBuilder.CreateIndex(
                name: "IX_tratamiento_medico_IdMedicamentoFk",
                table: "tratamiento_medico",
                column: "IdMedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_roles_IdUserFk_IdRolFk",
                table: "usuarios_roles",
                columns: new[] { "IdUserFk", "IdRolFk" });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_roles_UsuarioId",
                table: "usuarios_roles",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_movimiento");

            migrationBuilder.DropTable(
                name: "medicamento_proveedor");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "tratamiento_medico");

            migrationBuilder.DropTable(
                name: "usuarios_roles");

            migrationBuilder.DropTable(
                name: "movimiento_medicamento");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "cita");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "tipo_movimiento");

            migrationBuilder.DropTable(
                name: "mascota");

            migrationBuilder.DropTable(
                name: "veterinario");

            migrationBuilder.DropTable(
                name: "laboratorio");

            migrationBuilder.DropTable(
                name: "propietario");

            migrationBuilder.DropTable(
                name: "raza");

            migrationBuilder.DropTable(
                name: "especie");
        }
    }
}
