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
	public class DanhMucConfig : IEntityTypeConfiguration<DanhMuc>
	{
		public void Configure(EntityTypeBuilder<DanhMuc> builder)
		{
			builder.ToTable("DanhMuc");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Ten).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x => x.TrangThai).HasColumnType("int");
		}
	}
}
