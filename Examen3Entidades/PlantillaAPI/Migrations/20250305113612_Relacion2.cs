using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Relacion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdObjeto",
                table: "Autor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdObjeto",
                table: "Autor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
