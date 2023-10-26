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
	public class DonHangConfig : IEntityTypeConfiguration<DonHang>
	{
		public void Configure(EntityTypeBuilder<DonHang> builder)
		{
			builder.ToTable("DonHang");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.DiaChiNhan).HasColumnType("nvarchar(150)").IsRequired();
			builder.Property(x => x.GhiChu).HasColumnType("nvarchar(150)").IsRequired();
			builder.Property(x => x.NgayDatHang).HasColumnType("Date").IsRequired();
			builder.Property(x => x.NgayGiaoHang).HasColumnType("Date").IsRequired();
			builder.Property(x => x.NgayNhanHang).HasColumnType("Date").IsRequired();
			builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
			builder.Property(x => x.TienShip).HasColumnType("decimal(8,0)").IsRequired();
			builder.Property(x => x.TongTien).HasColumnType("decimal(8,0)").IsRequired();

			builder.HasOne(x => x.Voucher).WithMany(x => x.DonHangs).HasForeignKey(x => x.IdVoucher);
			builder.HasOne(x => x.NguoiDat).WithMany(x => x.DonHangNguoiDats).HasForeignKey(x => x.IdNguoiNhan);
			builder.HasOne(x => x.NguoiShip).WithMany(x => x.DonHangNguoiShips).HasForeignKey(x => x.IdShipper);
		}
	}
}
