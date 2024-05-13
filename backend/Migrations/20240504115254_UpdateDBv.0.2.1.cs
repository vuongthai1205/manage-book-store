using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBv021 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 1,
                column: "GiaTien",
                value: 29.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 2,
                column: "GiaTien",
                value: 35.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 3,
                column: "GiaTien",
                value: 39.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 4,
                column: "GiaTien",
                value: 24.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 5,
                column: "GiaTien",
                value: 42.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 6,
                column: "GiaTien",
                value: 37.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 7,
                column: "GiaTien",
                value: 45.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 8,
                column: "GiaTien",
                value: 33.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 9,
                column: "GiaTien",
                value: 39.000m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 10,
                column: "GiaTien",
                value: 29.000m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 1,
                column: "GiaTien",
                value: 29.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 2,
                column: "GiaTien",
                value: 35.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 3,
                column: "GiaTien",
                value: 39.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 4,
                column: "GiaTien",
                value: 24.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 5,
                column: "GiaTien",
                value: 42.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 6,
                column: "GiaTien",
                value: 37.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 7,
                column: "GiaTien",
                value: 45.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 8,
                column: "GiaTien",
                value: 33.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 9,
                column: "GiaTien",
                value: 39.99m);

            migrationBuilder.UpdateData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 10,
                column: "GiaTien",
                value: 29.99m);
        }
    }
}
