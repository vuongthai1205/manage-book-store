using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBv019 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sach",
                columns: new[] { "MaSach", "TacGia", "CategoryId", "TaoLuc", "MoTa", "HinhAnh", "GiaTien", "SoLuong", "TieuDe", "CapNhatLuc" },
                values: new object[,]
                {
                    { 1, "Nguyễn Văn A", 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sách hướng dẫn lập trình C# từ cơ bản đến nâng cao.", "https://example.com/images/sach1.jpg", 29.99m, 50, "Sách Lập trình C#", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Trần Văn B", 2, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sách hướng dẫn lập trình Java cho người mới bắt đầu.", "https://example.com/images/sach2.jpg", 35.99m, 30, "Sách Lập trình Java", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Lê Thị C", 3, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hướng dẫn lập trình Python nâng cao.", "https://example.com/images/sach3.jpg", 39.99m, 25, "Sách Lập trình Python", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Phạm Văn D", 4, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình JavaScript cơ bản.", "https://example.com/images/sach4.jpg", 24.99m, 40, "Sách Lập trình JavaScript", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Hoàng Thị E", 5, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruby cơ bản và nâng cao.", "https://example.com/images/sach5.jpg", 42.99m, 35, "Sách Lập trình Ruby", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Đặng Văn F", 6, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PHP từ cơ bản đến nâng cao.", "https://example.com/images/sach6.jpg", 37.99m, 20, "Sách Lập trình PHP", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Nguyễn Văn G", 7, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Học lập trình Swift.", "https://example.com/images/sach7.jpg", 45.99m, 25, "Sách Lập trình Swift", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Nguyễn Thị H", 8, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình Kotlin từ A đến Z.", "https://example.com/images/sach8.jpg", 33.99m, 30, "Sách Lập trình Kotlin", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Lê Văn I", 9, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Objective-C cơ bản và nâng cao.", "https://example.com/images/sach9.jpg", 39.99m, 15, "Sách Lập trình Objective-C", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Trần Văn J", 10, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R cho dữ liệu.", "https://example.com/images/sach10.jpg", 29.99m, 20, "Sách Lập trình R", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sach",
                keyColumn: "MaSach",
                keyValue: 10);
        }
    }
}
