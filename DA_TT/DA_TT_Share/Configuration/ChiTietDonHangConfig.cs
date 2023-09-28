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
	public class ChiTietDonHangConfig : IEntityTypeConfiguration<DonHangChiTiet>
	{
		public void Configure(EntityTypeBuilder<DonHangChiTiet> builder)
		{
			builder.ToTable("ChiTietDonHang");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.DonGia).HasColumnType("decimal(8,0)").IsRequired();
			builder.Property(x => x.Soluong).HasColumnType("int").IsRequired();

			builder.HasOne(x => x.DonHang).WithMany(x => x.DonHangChiTiets).HasForeignKey(x => x.IdDonHang);
			builder.HasOne(x => x.SanPham).WithMany(x => x.ChiTietDonHangs).HasForeignKey(x => x.IdSanPham);
		}
	}
}
