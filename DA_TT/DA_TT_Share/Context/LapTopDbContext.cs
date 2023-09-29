using DA_TT_Share.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Context
{
	public class LapTopDbContext : DbContext
	{
        public LapTopDbContext()
        {
            
        }
        public LapTopDbContext(DbContextOptions options) : base(options)
		{
		}
		public virtual DbSet<GioHangItem> GioHangItem { get; set; }
		public virtual DbSet<DonHangChiTiet> ChiTietDonHang { get; set; }
		public virtual DbSet<DanhMuc> DanhMuc { get; set; }
		public virtual DbSet<NguoiDung> NguoiDung { get; set; }
		public virtual DbSet<GioHang> GioHang { get; set; }
		public virtual DbSet<SanPham> SanPham { get; set; }
		public virtual DbSet<LienHe> LienHe { get; set; }
		public virtual DbSet<Voucher> Voucher { get; set; }
		public virtual DbSet<DonHang> DonHang { get; set; }
		public virtual DbSet<HangSanXuat> HangSanXuat { get; set; } = null;
		public virtual DbSet<ChucVu> ChucVu { get; set; }
		public virtual DbSet<Voucher_NguoiDung> Voucher_NguoiDung { get; set; }
		public virtual DbSet<Coupon> Coupon { get; set; }	

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LAPTOP-DAV1LO0Q\\SQLEXPRESS;Initial Catalog=ShopLapTop;Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
