using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBv013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_Sach_MaSach",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuTrangThai_ChiTietDonHang_MaChiTietDonHang",
                table: "LichSuTrangThai");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_MaSach",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "MaSach",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "ChiTietDonHang");

            migrationBuilder.AddColumn<double>(
                name: "TongTien",
                table: "DonHang",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MaSach",
                table: "ChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaSach",
                table: "ChiTietDonHang",
                column: "MaSach");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_Sach_MaSach",
                table: "ChiTietDonHang",
                column: "MaSach",
                principalTable: "Sach",
                principalColumn: "MaSach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuTrangThai_DonHang_MaChiTietDonHang",
                table: "LichSuTrangThai",
                column: "MaChiTietDonHang",
                principalTable: "DonHang",
                principalColumn: "MaDonHang",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_Sach_MaSach",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuTrangThai_DonHang_MaChiTietDonHang",
                table: "LichSuTrangThai");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonHang_MaSach",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "MaSach",
                table: "ChiTietDonHang");

            migrationBuilder.AddColumn<int>(
                name: "MaSach",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TongTien",
                table: "ChiTietDonHang",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaSach",
                table: "DonHang",
                column: "MaSach");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_Sach_MaSach",
                table: "DonHang",
                column: "MaSach",
                principalTable: "Sach",
                principalColumn: "MaSach",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuTrangThai_ChiTietDonHang_MaChiTietDonHang",
                table: "LichSuTrangThai",
                column: "MaChiTietDonHang",
                principalTable: "ChiTietDonHang",
                principalColumn: "MaChiTietDonHang",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
