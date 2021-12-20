using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    public partial class updatedMovieIMDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Movies",
                newName: "ImDbRating");

            migrationBuilder.RenameColumn(
                name: "Poster",
                table: "Movies",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Movies",
                newName: "Plot");

            migrationBuilder.RenameColumn(
                name: "Director",
                table: "Movies",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Movies",
                newName: "Directors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDateOffered",
                table: "WatchMovie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 19, 18, 45, 24, 640, DateTimeKind.Local).AddTicks(6560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1,
                columns: new[] { "Directors", "Genres", "IMDBtitleId", "ImDbRating", "Image", "Plot", "Title" },
                values: new object[] { "Lana Wachowski, Lilly Wachowski", "Action, Sci-Fi", "tt0133093", 8.6999999999999993, "https://imdb-api.com/images/original/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_Ratio0.6791_AL_.jpg", "Thomas A. Anderson is a man living two lives. By day he is an average computer programmer and by night a hacker known as Neo. Neo has always questioned his reality, but the truth is far beyond his imagination. Neo finds himself targeted by the police when he is contacted by Morpheus, a legendary computer hacker branded a terrorist by the government. As a rebel against the machines, Neo must confront the agents: super-powerful computer programs devoted to stopping Neo and the entire human rebellion.", "The Matrix" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2,
                columns: new[] { "Directors", "Genres", "Plot" },
                values: new object[] { "Wachewski brothers", "ACtion", "short description about the movie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Plot",
                table: "Movies",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Movies",
                newName: "Poster");

            migrationBuilder.RenameColumn(
                name: "ImDbRating",
                table: "Movies",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Genres",
                table: "Movies",
                newName: "Director");

            migrationBuilder.RenameColumn(
                name: "Directors",
                table: "Movies",
                newName: "Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDateOffered",
                table: "WatchMovie",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 19, 18, 45, 24, 640, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1,
                columns: new[] { "Description", "Director", "Genre", "IMDBtitleId", "Poster", "Rating", "Title" },
                values: new object[] { "short description about the movie", "Some director", "ACtion", "qwe123", null, null, "Movie1" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2,
                columns: new[] { "Description", "Director", "Genre" },
                values: new object[] { "short description about the movie", "Wachewski brothers", "ACtion" });
        }
    }
}
