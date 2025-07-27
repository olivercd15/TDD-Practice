using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NroDocumento",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumento",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "NroDocumento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Clientes");
        }
    }
}
