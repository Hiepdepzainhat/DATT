using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_TT_Share.Migrations
{
    public partial class createDBCOntext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangSanXuat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHangSanXuat = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangSanXuat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhanTramGiam = table.Column<int>(type: "int", nullable: false),
                    TenCoupon = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "Date", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "Date", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VouCher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenVouCher = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    TienGiam = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
                    DieuKienDonHang = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "Date", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "Date", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VouCher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChucVu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "Date", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDung_ChucVu_IdChucVu",
                        column: x => x.IdChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHangSX = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdCoupon = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenSanPham = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GiaNhap = table.Column<decimal>(type: "decimal(8,0)", nullable: true),
                    GiaBan = table.Column<decimal>(type: "decimal(8,0)", nullable: true),
                    DungLuongPin = table.Column<int>(type: "int", nullable: true),
                    HeDieuHanh = table.Column<int>(type: "int", nullable: true),
                    ManHinh = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Ram = table.Column<int>(type: "int", nullable: true),
                    TongSoLuong = table.Column<int>(type: "int", nullable: true),
                    SoLuongDaBan = table.Column<int>(type: "int", nullable: true),
                    SoLuongTon = table.Column<int>(type: "int", nullable: true),
                    ThongTinBaoHanh = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_DanhMuc_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DanhMuc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPham_HangSanXuat_IdHangSX",
                        column: x => x.IdHangSX,
                        principalTable: "HangSanXuat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPham_KhuyenMai_IdCoupon",
                        column: x => x.IdCoupon,
                        principalTable: "KhuyenMai",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaChiNhan = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    NgayDatHang = table.Column<DateTime>(type: "Date", nullable: false),
                    NgayGiaoHang = table.Column<DateTime>(type: "Date", nullable: false),
                    NgayNhanHang = table.Column<DateTime>(type: "Date", nullable: false),
                    SDTNhanHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienShip = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdNguoiNhan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdShipper = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonHang_NguoiDung_IdNguoiNhan",
                        column: x => x.IdNguoiNhan,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonHang_NguoiDung_IdShipper",
                        column: x => x.IdShipper,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonHang_VouCher_IdVoucher",
                        column: x => x.IdVoucher,
                        principalTable: "VouCher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(8,0)", nullable: true),
                    IdNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHang_NguoiDung_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GioHang_VouCher_IdVoucher",
                        column: x => x.IdVoucher,
                        principalTable: "VouCher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhoVoucher_NguoiDung",
                columns: table => new
                {
                    IDNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoVoucher_NguoiDung", x => new { x.IDNguoiDung, x.IDVoucher });
                    table.ForeignKey(
                        name: "FK_KhoVoucher_NguoiDung_NguoiDung_IDNguoiDung",
                        column: x => x.IDNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhoVoucher_NguoiDung_VouCher_IDVoucher",
                        column: x => x.IDVoucher,
                        principalTable: "VouCher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LienHe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNguoiTrLoi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayLienHe = table.Column<DateTime>(type: "DateTime", nullable: true),
                    NgayTraLoi = table.Column<DateTime>(type: "DateTime", nullable: true),
                    NoiDungLienHe = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    NoiDungTraLoi = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LienHe_NguoiDung_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LienHe_NguoiDung_IdNguoiTrLoi",
                        column: x => x.IdNguoiTrLoi,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LienHe_SanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_DonHang_IdDonHang",
                        column: x => x.IdDonHang,
                        principalTable: "DonHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_SanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GioHangItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
                    IdGioHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GioHangItem_GioHang_IdGioHang",
                        column: x => x.IdGioHang,
                        principalTable: "GioHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GioHangItem_SanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_IdDonHang",
                table: "ChiTietDonHang",
                column: "IdDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_IdSanPham",
                table: "ChiTietDonHang",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_IdNguoiNhan",
                table: "DonHang",
                column: "IdNguoiNhan");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_IdShipper",
                table: "DonHang",
                column: "IdShipper");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_IdVoucher",
                table: "DonHang",
                column: "IdVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdNguoiDung",
                table: "GioHang",
                column: "IdNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdVoucher",
                table: "GioHang",
                column: "IdVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangItem_IdGioHang",
                table: "GioHangItem",
                column: "IdGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangItem_IdSanPham",
                table: "GioHangItem",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_KhoVoucher_NguoiDung_IDVoucher",
                table: "KhoVoucher_NguoiDung",
                column: "IDVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_LienHe_IdNguoiDung",
                table: "LienHe",
                column: "IdNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_LienHe_IdNguoiTrLoi",
                table: "LienHe",
                column: "IdNguoiTrLoi");

            migrationBuilder.CreateIndex(
                name: "IX_LienHe_IdSanPham",
                table: "LienHe",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_IdChucVu",
                table: "NguoiDung",
                column: "IdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdCoupon",
                table: "SanPham",
                column: "IdCoupon");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdDanhMuc",
                table: "SanPham",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdHangSX",
                table: "SanPham",
                column: "IdHangSX");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "GioHangItem");

            migrationBuilder.DropTable(
                name: "KhoVoucher_NguoiDung");

            migrationBuilder.DropTable(
                name: "LienHe");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "VouCher");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "HangSanXuat");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "ChucVu");
        }
    }
}
