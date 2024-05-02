using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBv015 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichSuTrangThai_DonHang_MaChiTietDonHang",
                table: "LichSuTrangThai");

            migrationBuilder.RenameColumn(
                name: "MaChiTietDonHang",
                table: "LichSuTrangThai",
                newName: "MaDonHang");

            migrationBuilder.RenameIndex(
                name: "IX_LichSuTrangThai_MaChiTietDonHang",
                table: "LichSuTrangThai",
                newName: "IX_LichSuTrangThai_MaDonHang");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaoLuc",
                table: "LichSuTrangThai",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CapNhatLuc",
                table: "LichSuTrangThai",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaoLuc",
                table: "DonHang",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CapNhatLuc",
                table: "DonHang",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaoLuc",
                table: "ChiTietDonHang",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CapNhatLuc",
                table: "ChiTietDonHang",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuTrangThai_DonHang_MaDonHang",
                table: "LichSuTrangThai",
                column: "MaDonHang",
                principalTable: "DonHang",
                principalColumn: "MaDonHang",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichSuTrangThai_DonHang_MaDonHang",
                table: "LichSuTrangThai");

            migrationBuilder.RenameColumn(
                name: "MaDonHang",
                table: "LichSuTrangThai",
                newName: "MaChiTietDonHang");

            migrationBuilder.RenameIndex(
                name: "IX_LichSuTrangThai_MaDonHang",
                table: "LichSuTrangThai",
                newName: "IX_LichSuTrangThai_MaChiTietDonHang");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaoLuc",
                table: "LichSuTrangThai",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CapNhatLuc",
                table: "LichSuTrangThai",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaoLuc",
                table: "DonHang",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CapNhatLuc",
                table: "DonHang",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaoLuc",
                table: "ChiTietDonHang",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CapNhatLuc",
                table: "ChiTietDonHang",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuTrangThai_DonHang_MaChiTietDonHang",
                table: "LichSuTrangThai",
                column: "MaChiTietDonHang",
                principalTable: "DonHang",
                principalColumn: "MaDonHang",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
