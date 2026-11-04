using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEfCore.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDescripcionNota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Notas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Notas");
        }
    }
}
