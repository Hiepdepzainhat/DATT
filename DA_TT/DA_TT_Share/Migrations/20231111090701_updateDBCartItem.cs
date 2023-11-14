using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_TT_Share.Migrations
{
    public partial class updateDBCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DonGia",
                table: "GioHangItem",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonGia",
                table: "GioHangItem");
        }
    }
}
