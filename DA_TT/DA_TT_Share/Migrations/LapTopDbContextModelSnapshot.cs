﻿// <auto-generated />
using System;
using DA_TT_Share.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DA_TT_Share.Migrations
{
    [DbContext(typeof(LapTopDbContext))]
    partial class LapTopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DA_TT_Share.Models.ChucVu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChucVu", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgayBatDau")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<DateTime?>("NgayKetThuc")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<int?>("PhanTramGiam")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("TenCoupon")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KhuyenMai", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.DanhMuc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DanhMuc", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.DonHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid?>("IdNguoiNhan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdShipper")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdVoucher")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgayDatHang")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<DateTime?>("NgayGiaoHang")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<DateTime?>("NgayNhanHang")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<string>("SDTNhanHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TienShip")
                        .IsRequired()
                        .HasColumnType("decimal(8,0)");

                    b.Property<decimal?>("TongTien")
                        .IsRequired()
                        .HasColumnType("decimal(8,0)");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdNguoiNhan");

                    b.HasIndex("IdShipper");

                    b.HasIndex("IdVoucher");

                    b.ToTable("DonHang", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.DonHangChiTiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("DonGia")
                        .IsRequired()
                        .HasColumnType("decimal(8,0)");

                    b.Property<Guid?>("IdDonHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Soluong")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdDonHang");

                    b.HasIndex("IdSanPham");

                    b.ToTable("ChiTietDonHang", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.GioHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdVoucher")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(8,0)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdVoucher");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.GioHangItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdGioHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Soluong")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .IsRequired()
                        .HasColumnType("decimal(8,0)");

                    b.HasKey("ID");

                    b.HasIndex("IdGioHang");

                    b.HasIndex("IdSanPham");

                    b.ToTable("GioHangItem", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.HangSanXuat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenHangSanXuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HangSanXuat", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.LienHe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdNguoiTrLoi")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgayLienHe")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("NgayTraLoi")
                        .HasColumnType("DateTime");

                    b.Property<string>("NoiDungLienHe")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("NoiDungTraLoi")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdNguoiTrLoi");

                    b.HasIndex("IdSanPham");

                    b.ToTable("LienHe", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.NguoiDung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("IdChucVu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("NgaySinh")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdChucVu");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPU")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("DungLuongPin")
                        .HasColumnType("int");

                    b.Property<decimal?>("GiaBan")
                        .HasColumnType("decimal(8,0)");

                    b.Property<decimal?>("GiaNhap")
                        .HasColumnType("decimal(8,0)");

                    b.Property<int?>("HeDieuHanh")
                        .HasColumnType("int");

                    b.Property<Guid?>("IdCoupon")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdDanhMuc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdHangSX")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManHinh")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Ram")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongDaBan")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ThongTinBaoHanh")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TongSoLuong")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCoupon");

                    b.HasIndex("IdDanhMuc");

                    b.HasIndex("IdHangSX");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("DieuKienDonHang")
                        .IsRequired()
                        .HasColumnType("decimal(8,0)");

                    b.Property<DateTime?>("NgayBatDau")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<DateTime?>("NgayKetThuc")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<int?>("SoLuong")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("TenVouCher")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)");

                    b.Property<decimal?>("TienGiam")
                        .IsRequired()
                        .HasColumnType("decimal(8,0)");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VouCher", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.Voucher_NguoiDung", b =>
                {
                    b.Property<Guid>("IDNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDVoucher")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IDNguoiDung", "IDVoucher");

                    b.HasIndex("IDVoucher");

                    b.ToTable("KhoVoucher_NguoiDung", (string)null);
                });

            modelBuilder.Entity("DA_TT_Share.Models.DonHang", b =>
                {
                    b.HasOne("DA_TT_Share.Models.NguoiDung", "NguoiDat")
                        .WithMany("DonHangNguoiDats")
                        .HasForeignKey("IdNguoiNhan");

                    b.HasOne("DA_TT_Share.Models.NguoiDung", "NguoiShip")
                        .WithMany("DonHangNguoiShips")
                        .HasForeignKey("IdShipper");

                    b.HasOne("DA_TT_Share.Models.Voucher", "Voucher")
                        .WithMany("DonHangs")
                        .HasForeignKey("IdVoucher");

                    b.Navigation("NguoiDat");

                    b.Navigation("NguoiShip");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("DA_TT_Share.Models.DonHangChiTiet", b =>
                {
                    b.HasOne("DA_TT_Share.Models.DonHang", "DonHang")
                        .WithMany("DonHangChiTiets")
                        .HasForeignKey("IdDonHang");

                    b.HasOne("DA_TT_Share.Models.SanPham", "SanPham")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("IdSanPham");

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DA_TT_Share.Models.GioHang", b =>
                {
                    b.HasOne("DA_TT_Share.Models.NguoiDung", "NguoiDung")
                        .WithMany("GioHangs")
                        .HasForeignKey("IdNguoiDung");

                    b.HasOne("DA_TT_Share.Models.Voucher", "Voucher")
                        .WithMany("GioHangs")
                        .HasForeignKey("IdVoucher");

                    b.Navigation("NguoiDung");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("DA_TT_Share.Models.GioHangItem", b =>
                {
                    b.HasOne("DA_TT_Share.Models.GioHang", "GioHang")
                        .WithMany("GioHangItems")
                        .HasForeignKey("IdGioHang");

                    b.HasOne("DA_TT_Share.Models.SanPham", "SanPham")
                        .WithMany("GioHangItems")
                        .HasForeignKey("IdSanPham");

                    b.Navigation("GioHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DA_TT_Share.Models.LienHe", b =>
                {
                    b.HasOne("DA_TT_Share.Models.NguoiDung", "NguoiLienHe")
                        .WithMany("LienHeNguoiDungs")
                        .HasForeignKey("IdNguoiDung");

                    b.HasOne("DA_TT_Share.Models.NguoiDung", "NguoiTraLoi")
                        .WithMany("LienHeTraLois")
                        .HasForeignKey("IdNguoiTrLoi");

                    b.HasOne("DA_TT_Share.Models.SanPham", "SanPham")
                        .WithMany("LienHes")
                        .HasForeignKey("IdSanPham");

                    b.Navigation("NguoiLienHe");

                    b.Navigation("NguoiTraLoi");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DA_TT_Share.Models.NguoiDung", b =>
                {
                    b.HasOne("DA_TT_Share.Models.ChucVu", "ChucVu")
                        .WithMany("NguoiDungs")
                        .HasForeignKey("IdChucVu");

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("DA_TT_Share.Models.SanPham", b =>
                {
                    b.HasOne("DA_TT_Share.Models.Coupon", "Coupon")
                        .WithMany("SanPhams")
                        .HasForeignKey("IdCoupon");

                    b.HasOne("DA_TT_Share.Models.DanhMuc", "DanhMuc")
                        .WithMany("SanPhams")
                        .HasForeignKey("IdDanhMuc");

                    b.HasOne("DA_TT_Share.Models.HangSanXuat", "HangSanXuat")
                        .WithMany("SanPhams")
                        .HasForeignKey("IdHangSX");

                    b.Navigation("Coupon");

                    b.Navigation("DanhMuc");

                    b.Navigation("HangSanXuat");
                });

            modelBuilder.Entity("DA_TT_Share.Models.Voucher_NguoiDung", b =>
                {
                    b.HasOne("DA_TT_Share.Models.NguoiDung", "NguoiDung")
                        .WithMany("MyVoucher")
                        .HasForeignKey("IDNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DA_TT_Share.Models.Voucher", "Voucher")
                        .WithMany("KhoVouCher")
                        .HasForeignKey("IDVoucher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("DA_TT_Share.Models.ChucVu", b =>
                {
                    b.Navigation("NguoiDungs");
                });

            modelBuilder.Entity("DA_TT_Share.Models.Coupon", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("DA_TT_Share.Models.DanhMuc", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("DA_TT_Share.Models.DonHang", b =>
                {
                    b.Navigation("DonHangChiTiets");
                });

            modelBuilder.Entity("DA_TT_Share.Models.GioHang", b =>
                {
                    b.Navigation("GioHangItems");
                });

            modelBuilder.Entity("DA_TT_Share.Models.HangSanXuat", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("DA_TT_Share.Models.NguoiDung", b =>
                {
                    b.Navigation("DonHangNguoiDats");

                    b.Navigation("DonHangNguoiShips");

                    b.Navigation("GioHangs");

                    b.Navigation("LienHeNguoiDungs");

                    b.Navigation("LienHeTraLois");

                    b.Navigation("MyVoucher");
                });

            modelBuilder.Entity("DA_TT_Share.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietDonHangs");

                    b.Navigation("GioHangItems");

                    b.Navigation("LienHes");
                });

            modelBuilder.Entity("DA_TT_Share.Models.Voucher", b =>
                {
                    b.Navigation("DonHangs");

                    b.Navigation("GioHangs");

                    b.Navigation("KhoVouCher");
                });
#pragma warning restore 612, 618
        }
    }
}
