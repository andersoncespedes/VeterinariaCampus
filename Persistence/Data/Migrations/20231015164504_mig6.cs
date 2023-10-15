using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_laboratorio_LaboratorioId",
                table: "medicamento");

            migrationBuilder.DropIndex(
                name: "IX_medicamento_LaboratorioId",
                table: "medicamento");

            migrationBuilder.DropColumn(
                name: "LaboratorioId",
                table: "medicamento");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdLaboratorioFk",
                table: "medicamento",
                column: "IdLaboratorioFk");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_laboratorio_IdLaboratorioFk",
                table: "medicamento",
                column: "IdLaboratorioFk",
                principalTable: "laboratorio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_laboratorio_IdLaboratorioFk",
                table: "medicamento");

            migrationBuilder.DropIndex(
                name: "IX_medicamento_IdLaboratorioFk",
                table: "medicamento");

            migrationBuilder.AddColumn<int>(
                name: "LaboratorioId",
                table: "medicamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_LaboratorioId",
                table: "medicamento",
                column: "LaboratorioId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_laboratorio_LaboratorioId",
                table: "medicamento",
                column: "LaboratorioId",
                principalTable: "laboratorio",
                principalColumn: "Id");
        }
    }
}
