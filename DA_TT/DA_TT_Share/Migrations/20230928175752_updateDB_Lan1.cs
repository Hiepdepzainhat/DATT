using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_TT_Share.Migrations
{
    public partial class updateDB_Lan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_KhoVoucher_NguoiDung_IDVoucher",
                table: "KhoVoucher_NguoiDung",
                column: "IDVoucher");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoVoucher_NguoiDung_NguoiDung_IDNguoiDung",
                table: "KhoVoucher_NguoiDung",
                column: "IDNguoiDung",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KhoVoucher_NguoiDung_VouCher_IDVoucher",
                table: "KhoVoucher_NguoiDung",
                column: "IDVoucher",
                principalTable: "VouCher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhoVoucher_NguoiDung_NguoiDung_IDNguoiDung",
                table: "KhoVoucher_NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoVoucher_NguoiDung_VouCher_IDVoucher",
                table: "KhoVoucher_NguoiDung");

            migrationBuilder.DropIndex(
                name: "IX_KhoVoucher_NguoiDung_IDVoucher",
                table: "KhoVoucher_NguoiDung");
        }
    }
}
