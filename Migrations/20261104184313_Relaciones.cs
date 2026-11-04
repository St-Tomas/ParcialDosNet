using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEfCore.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Notas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_CategoriaId",
                table: "Notas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_PersonaId",
                table: "Notas",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Categorias_CategoriaId",
                table: "Notas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Personas_PersonaId",
                table: "Notas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Categorias_CategoriaId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Personas_PersonaId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_CategoriaId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_PersonaId",
                table: "Notas");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Notas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
