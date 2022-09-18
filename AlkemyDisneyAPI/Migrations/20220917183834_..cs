using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkemyDisneyAPI.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Genres_GenreID",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "Films",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Films_GenreID",
                table: "Films",
                newName: "IX_Films_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Genres_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Genres_GenreId",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Films",
                newName: "GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_Films_GenreId",
                table: "Films",
                newName: "IX_Films_GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Genres_GenreID",
                table: "Films",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
