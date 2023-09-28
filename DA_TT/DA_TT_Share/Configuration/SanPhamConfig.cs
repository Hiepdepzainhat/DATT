using DA_TT_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Configuration
{
	public class SanPhamConfig : IEntityTypeConfiguration<SanPham>
	{
		public void Configure(EntityTypeBuilder<SanPham> builder)
		{
			builder.ToTable("SanPham");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.TenSanPham).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x => x.CPU).HasColumnType("nvarchar(100)");
			builder.Property(x => x.GiaNhap).HasColumnType("decimal(8,0)");
			builder.Property(x => x.GiaBan).HasColumnType("decimal(8,0)");
			builder.Property(x => x.DungLuongPin).HasColumnType("int");
			builder.Property(x => x.ManHinh).HasColumnType("nvarchar(100)");
			builder.Property(x => x.HeDieuHanh).HasColumnType("int");
			builder.Property(x => x.ThongTinBaoHanh).HasColumnType("nvarchar(1000)");
			builder.Property(x => x.Ram).HasColumnType("int");
			builder.Property(x => x.TongSoLuong).HasColumnType("int");
			builder.Property(x => x.SoLuongDaBan).HasColumnType("int");
			builder.Property(x => x.SoLuongTon).HasColumnType("int");
			builder.Property(x => x.TrangThai).HasColumnType("int");

			builder.HasOne(x => x.DanhMuc).WithMany(x => x.SanPhams).HasForeignKey(x => x.IdDanhMuc);
			builder.HasOne(x => x.HangSanXuat).WithMany(x => x.SanPhams).HasForeignKey(x => x.IdHangSX);
			builder.HasOne(x => x.Coupon).WithMany(x => x.SanPhams).HasForeignKey(x => x.IdCoupon);
		}
	}
}
