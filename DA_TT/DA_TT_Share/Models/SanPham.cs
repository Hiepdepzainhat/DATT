using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class SanPham
	{
        [Key]
        public Guid Id { get; set; }
		public Guid? IdDanhMuc { get; set; }
		public Guid? IdHangSX { get; set; }
        public Guid? IdCoupon { get; set; }
		public string? TenSanPham { get; set; }
        public string? Image { get; set; }
		public string? CPU { get; set; }
        public decimal? GiaNhap { get; set; }
        public DateTime? NgayNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public int? DungLuongPin { get; set; }
        public int? HeDieuHanh { get; set; }
        public string? ManHinh { get; set; }
        public int? Ram { get; set; }
        public int? TongSoLuong { get; set; }
        public int? SoLuongDaBan { get; set; }
        public int? SoLuongTon { get; set; }
        public string? ThongTinBaoHanh { get; set; }
        public int? TrangThai { get; set; }
        public virtual DanhMuc? DanhMuc { get; set; }
        public virtual HangSanXuat? HangSanXuat { get; set; }
        public virtual Coupon? Coupon { get; set; }
        public virtual List<GioHangItem>? GioHangItems { get; set; }
        public virtual List<DonHangChiTiet>? ChiTietDonHangs { get; set; }
        public virtual List<LienHe>? LienHes { get; set; }
    }
}
