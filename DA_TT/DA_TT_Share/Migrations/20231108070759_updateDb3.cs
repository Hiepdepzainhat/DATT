using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_TT_Share.Migrations
{
    public partial class updateDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayNhap",
                table: "SanPham",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "GioHangItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ChiTietDonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "ChiTietDonHang",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayNhap",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "GioHangItem");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "Ten",
                table: "ChiTietDonHang");
        }
    }
}
