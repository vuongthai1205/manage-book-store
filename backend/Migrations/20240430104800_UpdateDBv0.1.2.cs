using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBv012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quyen",
                columns: new[] { "MaQuyen", "TenQuyen" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Staff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quyen",
                keyColumn: "MaQuyen",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quyen",
                keyColumn: "MaQuyen",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quyen",
                keyColumn: "MaQuyen",
                keyValue: 3);
        }
    }
}
