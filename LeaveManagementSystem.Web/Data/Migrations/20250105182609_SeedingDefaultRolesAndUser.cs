using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b25e4a1-74c5-45f0-aa24-27a7a5d01421", null, "Supervisor", "SUPERVISOR" },
                    { "6e6a28ad-60bb-47f8-88f1-21c642cb5401", null, "Employee", "EMPLOYEE" },
                    { "af42a916-b144-45d3-8426-3d7db9febf95", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d8e76c65-c900-495b-a047-7c7446ac0fd3", 0, "5762f964-1a4f-4124-ad25-4d7a5a0d48d9", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGomh0M+o99WrTDXf5F8r4YJ54PvUaBrZzCC+geCpRe7RS89LJQ3p//Lwb+WqRrsfg==", null, false, "ce2979b3-c84a-4530-b94b-eaaf85d42ef5", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "af42a916-b144-45d3-8426-3d7db9febf95", "d8e76c65-c900-495b-a047-7c7446ac0fd3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b25e4a1-74c5-45f0-aa24-27a7a5d01421");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e6a28ad-60bb-47f8-88f1-21c642cb5401");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "af42a916-b144-45d3-8426-3d7db9febf95", "d8e76c65-c900-495b-a047-7c7446ac0fd3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af42a916-b144-45d3-8426-3d7db9febf95");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8e76c65-c900-495b-a047-7c7446ac0fd3");
        }
    }
}
