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
	public class VoucherNguoiDungConfig : IEntityTypeConfiguration<Voucher_NguoiDung>
	{
		public void Configure(EntityTypeBuilder<Voucher_NguoiDung> builder)
		{
			builder.ToTable("KhoVoucher_NguoiDung");
			builder.HasKey(x => new { x.IDNguoiDung, x.IDVoucher});
			builder.Property(x => x.SoLuong).HasColumnType("int");
			builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();

			builder.HasOne(x => x.NguoiDung).WithMany(x => x.MyVoucher).HasForeignKey(x => x.IDNguoiDung);
			builder.HasOne(x => x.Voucher).WithMany(x => x.KhoVouCher).HasForeignKey(x => x.IDVoucher);
		}
	}
}
