using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    public partial class updatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchMovies_Movies_MovieId",
                table: "WatchMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchMovies_WatchLists_WatchListId",
                table: "WatchMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchMovies",
                table: "WatchMovies");

            migrationBuilder.RenameTable(
                name: "WatchMovies",
                newName: "WatchMovie");

            migrationBuilder.RenameIndex(
                name: "IX_WatchMovies_MovieId",
                table: "WatchMovie",
                newName: "IX_WatchMovie_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchMovie",
                table: "WatchMovie",
                columns: new[] { "WatchListId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WatchMovie_Movies_MovieId",
                table: "WatchMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchMovie_WatchLists_WatchListId",
                table: "WatchMovie",
                column: "WatchListId",
                principalTable: "WatchLists",
                principalColumn: "WatchListID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchMovie_Movies_MovieId",
                table: "WatchMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchMovie_WatchLists_WatchListId",
                table: "WatchMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchMovie",
                table: "WatchMovie");

            migrationBuilder.RenameTable(
                name: "WatchMovie",
                newName: "WatchMovies");

            migrationBuilder.RenameIndex(
                name: "IX_WatchMovie_MovieId",
                table: "WatchMovies",
                newName: "IX_WatchMovies_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchMovies",
                table: "WatchMovies",
                columns: new[] { "WatchListId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WatchMovies_Movies_MovieId",
                table: "WatchMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchMovies_WatchLists_WatchListId",
                table: "WatchMovies",
                column: "WatchListId",
                principalTable: "WatchLists",
                principalColumn: "WatchListID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
