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
	public class CouponConfig : IEntityTypeConfiguration<Coupon>
	{
		public void Configure(EntityTypeBuilder<Coupon> builder)
		{
			builder.ToTable("KhuyenMai");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.PhanTramGiam).HasColumnType("int").IsRequired();
			builder.Property(x => x.TenCoupon).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x => x.NgayBatDau).HasColumnType("Date").IsRequired();
			builder.Property(x => x.NgayKetThuc).HasColumnType("Date").IsRequired();
			builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
		}
	}
}
