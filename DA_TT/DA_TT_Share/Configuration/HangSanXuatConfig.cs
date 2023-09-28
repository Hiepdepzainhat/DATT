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
	public class HangSanXuatConfig : IEntityTypeConfiguration<HangSanXuat>
	{
		public void Configure(EntityTypeBuilder<HangSanXuat> builder)
		{
			builder.ToTable("HangSanXuat");
			builder.HasKey(x => x.Id);
			builder.Property(X => X.TenHangSanXuat).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x => x.Desciption).HasColumnType("nvarchar(1000)");
			builder.Property(x => x.TrangThai).HasColumnType("int");
		}
	}
}
