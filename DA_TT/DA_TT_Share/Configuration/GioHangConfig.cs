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
	public class GioHangConfig : IEntityTypeConfiguration<GioHang>
	{
		public void Configure(EntityTypeBuilder<GioHang> builder)
		{
			builder.ToTable("GioHang");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.TongTien).HasColumnType("decimal(8,0)");
			builder.Property(x => x.TrangThai).HasColumnType("int");

			builder.HasOne(x => x.Voucher).WithMany(x => x.GioHangs).HasForeignKey(x => x.IdVoucher);
			builder.HasOne(x => x.NguoiDung).WithMany(x => x.GioHangs).HasForeignKey(x => x.IdNguoiDung);
		}
	}
}
