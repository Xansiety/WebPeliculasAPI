using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    public partial class RestoreDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasGeneros_Peliculas_PeliculaId",
                table: "PeliculasGeneros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculasGeneros",
                table: "PeliculasGeneros");

            migrationBuilder.DropColumn(
                name: "PeiculaId",
                table: "PeliculasGeneros");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculaId",
                table: "PeliculasGeneros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculasGeneros",
                table: "PeliculasGeneros",
                columns: new[] { "GeneroId", "PeliculaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasGeneros_Peliculas_PeliculaId",
                table: "PeliculasGeneros",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasGeneros_Peliculas_PeliculaId",
                table: "PeliculasGeneros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculasGeneros",
                table: "PeliculasGeneros");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculaId",
                table: "PeliculasGeneros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeiculaId",
                table: "PeliculasGeneros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculasGeneros",
                table: "PeliculasGeneros",
                columns: new[] { "GeneroId", "PeiculaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasGeneros_Peliculas_PeliculaId",
                table: "PeliculasGeneros",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id");
        }
    }
}
