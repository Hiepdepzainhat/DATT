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
	internal class GioHangItemConfig : IEntityTypeConfiguration<GioHangItem>
	{
		public void Configure(EntityTypeBuilder<GioHangItem> builder)
		{
			builder.ToTable("GioHangItem");
			builder.HasKey(x => x.ID);
			builder.Property(x => x.ItemName).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x => x.Soluong).HasColumnType("int").IsRequired();
			builder.Property(x => x.ThanhTien).HasColumnType("decimal(8,0)").IsRequired();

			builder.HasOne(x => x.SanPham).WithMany(x => x.GioHangItems).HasForeignKey(x => x.IdSanPham);
			builder.HasOne(x => x.GioHang).WithMany(x => x.GioHangItems).HasForeignKey(x => x.IdGioHang);

		}
	}
}
