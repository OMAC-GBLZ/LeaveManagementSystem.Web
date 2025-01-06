using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8e76c65-c900-495b-a047-7c7446ac0fd3",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdae93e1-3308-494c-b89f-88ad933ce677", new DateOnly(1950, 12, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEHugszStFbvkrpqg3twGIUG2OjzhF8K1Ahh8Q171JWdjzq9a6q6IbHi0DCKKfBBDOg==", "a284f187-0a1f-423f-8029-800de16b6f36" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8e76c65-c900-495b-a047-7c7446ac0fd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5762f964-1a4f-4124-ad25-4d7a5a0d48d9", "AQAAAAIAAYagAAAAEGomh0M+o99WrTDXf5F8r4YJ54PvUaBrZzCC+geCpRe7RS89LJQ3p//Lwb+WqRrsfg==", "ce2979b3-c84a-4530-b94b-eaaf85d42ef5" });
        }
    }
}
