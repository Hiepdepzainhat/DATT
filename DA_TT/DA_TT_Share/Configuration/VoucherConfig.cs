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
	public class VoucherConfig : IEntityTypeConfiguration<Voucher>
	{
		public void Configure(EntityTypeBuilder<Voucher> builder)
		{
			builder.ToTable("VouCher");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.TienGiam).HasColumnType("decimal(8,0)").IsRequired();
			builder.Property(x => x.TenVouCher).HasColumnType("nvarchar(45)").IsRequired();
			builder.Property(x => x.DieuKienDonHang).HasColumnType("decimal(8,0)").IsRequired();
			builder.Property(x => x.SoLuong).HasColumnType("int").IsRequired();
			builder.Property(x => x.NgayBatDau).HasColumnType("Date").IsRequired();
			builder.Property(x => x.NgayKetThuc).HasColumnType("Date").IsRequired();
			builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
		}
	}
}
