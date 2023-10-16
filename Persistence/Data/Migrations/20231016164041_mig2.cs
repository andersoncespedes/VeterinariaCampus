using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimiento_medicamento_medicamento_MedicamentoId",
                table: "movimiento_medicamento");

            migrationBuilder.DropIndex(
                name: "IX_movimiento_medicamento_MedicamentoId",
                table: "movimiento_medicamento");

            migrationBuilder.DropColumn(
                name: "MedicamentoId",
                table: "movimiento_medicamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicamentoId",
                table: "movimiento_medicamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_medicamento_MedicamentoId",
                table: "movimiento_medicamento",
                column: "MedicamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimiento_medicamento_medicamento_MedicamentoId",
                table: "movimiento_medicamento",
                column: "MedicamentoId",
                principalTable: "medicamento",
                principalColumn: "Id");
        }
    }
}
