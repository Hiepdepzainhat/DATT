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
	public class ChucVuConfig : IEntityTypeConfiguration<ChucVu>
	{
		public void Configure(EntityTypeBuilder<ChucVu> builder)
		{
			builder.ToTable("ChucVu");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.TenChucVu).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x => x.TrangThai).HasColumnType("int");
		}
	}
}
