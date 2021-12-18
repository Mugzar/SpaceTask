using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    public partial class addedEntityRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_WatchLists_WatchListID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchLists_Users_UserId",
                table: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_Movies_WatchListID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "LastDateOffered",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "WatchListID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WatchLists",
                newName: "UserRefId");

            migrationBuilder.RenameIndex(
                name: "IX_WatchLists_UserId",
                table: "WatchLists",
                newName: "IX_WatchLists_UserRefId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Movies",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "WatchMovies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    WatchListId = table.Column<int>(type: "int", nullable: false),
                    LastDateOffered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchMovies", x => new { x.WatchListId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_WatchMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchMovies_WatchLists_WatchListId",
                        column: x => x.WatchListId,
                        principalTable: "WatchLists",
                        principalColumn: "WatchListID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "Description", "Director", "Genre", "Poster", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "short description about the movie", "Some director", "ACtion", null, null, "Movie1" },
                    { 2, "short description about the movie", "Wachewski brothers", "ACtion", null, null, "Matrix" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName" },
                values: new object[,]
                {
                    { 1, "Morpheus" },
                    { 2, "Neo" }
                });

            migrationBuilder.InsertData(
                table: "WatchLists",
                columns: new[] { "WatchListID", "UserRefId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "WatchLists",
                columns: new[] { "WatchListID", "UserRefId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "WatchMovies",
                columns: new[] { "MovieId", "WatchListId", "LastDateOffered" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "WatchMovies",
                columns: new[] { "MovieId", "WatchListId", "LastDateOffered" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "WatchMovies",
                columns: new[] { "MovieId", "WatchListId", "LastDateOffered" },
                values: new object[] { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_WatchMovies_MovieId",
                table: "WatchMovies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchLists_Users_UserRefId",
                table: "WatchLists",
                column: "UserRefId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchLists_Users_UserRefId",
                table: "WatchLists");

            migrationBuilder.DropTable(
                name: "WatchMovies");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WatchLists",
                keyColumn: "WatchListID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WatchLists",
                keyColumn: "WatchListID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "UserRefId",
                table: "WatchLists",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WatchLists_UserRefId",
                table: "WatchLists",
                newName: "IX_WatchLists_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateOffered",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WatchListID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_WatchListID",
                table: "Movies",
                column: "WatchListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_WatchLists_WatchListID",
                table: "Movies",
                column: "WatchListID",
                principalTable: "WatchLists",
                principalColumn: "WatchListID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchLists_Users_UserId",
                table: "WatchLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
