using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class Voucher
	{
        public  Guid Id { get; set; }
        public string? TenVouCher { get; set; }
        public decimal? TienGiam { get; set; }
        public decimal? DieuKienDonHang { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? TrangThai { get; set; }
        public virtual List<GioHang>? GioHangs { get; set; }
        public virtual List<DonHang>? DonHangs { get; set; }
        public virtual List<Voucher_NguoiDung>? KhoVouCher { get; set; }
    }
}
