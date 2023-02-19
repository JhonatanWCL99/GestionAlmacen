using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaSitec.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalNetoVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "total_neto",
                table: "Ventas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_neto",
                table: "Ventas");
        }
    }
}
