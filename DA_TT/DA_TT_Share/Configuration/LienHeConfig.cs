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
	public class LienHeConfig : IEntityTypeConfiguration<LienHe>
	{
		public void Configure(EntityTypeBuilder<LienHe> builder)
		{
			builder.ToTable("LienHe");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.NoiDungLienHe).HasColumnType("nvarchar(1000)");
			builder.Property(x => x.NgayLienHe).HasColumnType("DateTime");
			builder.Property(x => x.NgayTraLoi).HasColumnType("DateTime");
			builder.Property(x => x.NoiDungTraLoi).HasColumnType("nvarchar(1000)");
			builder.Property(x => x.TrangThai).HasColumnType("int");

			builder.HasOne(x => x.SanPham).WithMany(x => x.LienHes).HasForeignKey(x => x.IdSanPham);
			builder.HasOne(x => x.NguoiLienHe).WithMany(x => x.LienHeNguoiDungs).HasForeignKey(x => x.IdNguoiDung);
			builder.HasOne(x => x.NguoiTraLoi).WithMany(x => x.LienHeTraLois).HasForeignKey(x => x.IdNguoiTrLoi);
		}
	}
}
