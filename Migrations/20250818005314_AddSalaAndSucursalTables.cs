using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineManager.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaAndSucursalTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Salas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Salas");
        }
    }
}
