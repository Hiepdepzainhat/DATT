using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_TT_Share.Migrations
{
    public partial class ekekekekeke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoiDungNguoiDung",
                table: "LienHe");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDungLienHe",
                table: "LienHe",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NoiDungLienHe",
                table: "LienHe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDungNguoiDung",
                table: "LienHe",
                type: "nvarchar(1000)",
                nullable: true);
        }
    }
}
