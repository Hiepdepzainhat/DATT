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
	public class NguoiDungConfig : IEntityTypeConfiguration<NguoiDung>
	{
		public void Configure(EntityTypeBuilder<NguoiDung> builder)
		{
			builder.ToTable("NguoiDung");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.HoTen).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x => x.Image).HasColumnType("nvarchar(100)");
			builder.Property(x => x.GioiTinh).HasColumnType("int").IsRequired();
			builder.Property(x => x.Email).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x => x.SoDienThoai).HasColumnType("nvarchar(10)").IsRequired();
			builder.Property(x => x.NgaySinh).HasColumnType("Date").IsRequired();
			builder.Property(x => x.MatKhau).HasColumnType("nvarchar(25)").IsRequired();
			builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();

			builder.HasOne(x => x.ChucVu).WithMany(x => x.NguoiDungs).HasForeignKey(x => x.IdChucVu);
		}
	}
}
