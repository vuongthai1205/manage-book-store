using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBv018 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DanhMuc",
                columns: new[] { "MaDanhMuc", "TaoLuc", "TenDanhMuc", "CapNhatLuc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình C#", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình Java", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình Python", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình JavaScript", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình Ruby", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình PHP", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình Swift", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình Kotlin", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình Objective-C", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình R", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan",
                columns: new[] { "TenTaiKhoan", "DiaChi", "AnhDaiDien", "TaoLuc", "NgaySinh", "Email", "Ten", "GioiTinh", "NgonNguUaThich", "Ho", "MatKhau", "SoDienThoai", "MaQuyen", "TrangThai", "CapNhatLuc" },
                values: new object[,]
                {
                    { "staff", "Đà Nẵng", "https://example.com/avatar3.jpg", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff@example.com", "Phạm", "Nam", "Tiếng Việt", "Văn C", "$2a$13$6BjHaarncKGYIgYiBmcg8OVbItdMJuyiXjmuCokUpitoUjbBVvCFy", "0777666555", 3, "Khóa", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "user2", "TP. Hồ Chí Minh", "https://example.com/avatar2.jpg", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "Trần", "Nữ", "Tiếng Anh", "Thị B", "$2a$13$6BjHaarncKGYIgYiBmcg8OVbItdMJuyiXjmuCokUpitoUjbBVvCFy", "0987654321", 2, "1", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "user3", "Đà Nẵng", "https://example.com/avatar3.jpg", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "Phạm", "Nam", "Tiếng Việt", "Văn C", "$2a$13$6BjHaarncKGYIgYiBmcg8OVbItdMJuyiXjmuCokUpitoUjbBVvCFy", "0777666555", 2, "1", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "vuongthai", "Hà Nội", "https://example.com/avatar1.jpg", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vuongthai@example.com", "Nguyễn", "Nam", "Tiếng Việt", "Văn A", "$2a$13$6BjHaarncKGYIgYiBmcg8OVbItdMJuyiXjmuCokUpitoUjbBVvCFy", "0123456789", 1, "1", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "staff");

            migrationBuilder.DeleteData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "user2");

            migrationBuilder.DeleteData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "user3");

            migrationBuilder.DeleteData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "vuongthai");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "DonHang");
        }
    }
}
