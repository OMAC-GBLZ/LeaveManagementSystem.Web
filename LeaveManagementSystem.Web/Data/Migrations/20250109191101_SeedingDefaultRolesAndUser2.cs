using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8e76c65-c900-495b-a047-7c7446ac0fd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "43a2cbc7-369a-4fa8-8c0f-97d1c1a389da", "AQAAAAIAAYagAAAAEJy4Nj6gnjCZcE138mjk6OfH/xGxIgYlLYnYVtuxQ1A4dlBYuoUhDjQrj/FMk5NQIA==", "1cf3bb8b-e166-40de-af20-9fb06c8d8582", "admin@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8e76c65-c900-495b-a047-7c7446ac0fd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "418d709e-d1f3-440a-a350-4219a862521b", "AQAAAAIAAYagAAAAEDgzwIssX/3F2lCDExkEErHpGzVkEL9JqdTN6CiDajYaUrz6fgz2yCMCn3iKKOnA6Q==", "07ee3ea6-5f37-45eb-aea3-e00bcebe6981", null });
        }
    }
}
