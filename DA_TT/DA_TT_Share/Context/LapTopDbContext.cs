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
		public virtual GioHangItem GioHangItem { get; set; }
		public virtual DonHangChiTiet ChiTietDonHang { get; set; }
		public virtual DanhMuc DanhMuc { get; set; }
		public virtual NguoiDung NguoiDung { get; set; }
		public virtual GioHang GioHang { get; set; }
		public virtual SanPham SanPham { get; set; }
		public virtual LienHe LienHe { get; set; }
		public virtual Voucher Voucher { get; set; }
		public virtual DonHang DonHang { get; set; }
		public virtual HangSanXuat HangSanXuat { get; set; }
		public virtual ChucVu ChucVu { get; set; }
		public virtual Voucher_NguoiDung Voucher_NguoiDung { get; set; }
		public virtual Coupon Coupon { get; set; }	

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
