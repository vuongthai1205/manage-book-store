using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBv022 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "staff",
                column: "TrangThai",
                value: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaiKhoan",
                keyColumn: "TenTaiKhoan",
                keyValue: "staff",
                column: "TrangThai",
                value: "Khóa");
        }
    }
}
