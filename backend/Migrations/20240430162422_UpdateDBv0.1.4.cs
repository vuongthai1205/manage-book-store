using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBv014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapNhatLuc",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "TaoLuc",
                table: "TrangThaiDonHang");

            migrationBuilder.AddColumn<DateTime>(
                name: "CapNhatLuc",
                table: "LichSuTrangThai",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "LichSuTrangThai",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TaoLuc",
                table: "LichSuTrangThai",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "TrangThaiDonHang",
                columns: new[] { "MaTrangThai", "TenTrangThai" },
                values: new object[,]
                {
                    { 1, "Chuẩn bị hàng" },
                    { 2, "Đang giao hàng" },
                    { 3, "Đã giao hàng" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrangThaiDonHang",
                keyColumn: "MaTrangThai",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrangThaiDonHang",
                keyColumn: "MaTrangThai",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrangThaiDonHang",
                keyColumn: "MaTrangThai",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CapNhatLuc",
                table: "LichSuTrangThai");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "LichSuTrangThai");

            migrationBuilder.DropColumn(
                name: "TaoLuc",
                table: "LichSuTrangThai");

            migrationBuilder.AddColumn<DateTime>(
                name: "CapNhatLuc",
                table: "TrangThaiDonHang",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "TrangThaiDonHang",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TaoLuc",
                table: "TrangThaiDonHang",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
