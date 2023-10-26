using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_TT_Share.Migrations
{
    public partial class ekekekeke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TongTien",
                table: "ChiTietDonHang",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "ChiTietDonHang");
        }
    }
}
