using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    public partial class updatedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDateOffered",
                table: "WatchMovie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 13, 38, 36, 787, DateTimeKind.Local).AddTicks(8388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 19, 18, 45, 24, 640, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Email",
                value: "akizhan@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "Email",
                value: "akizhan@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDateOffered",
                table: "WatchMovie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 19, 18, 45, 24, 640, DateTimeKind.Local).AddTicks(6560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 13, 38, 36, 787, DateTimeKind.Local).AddTicks(8388));
        }
    }
}
