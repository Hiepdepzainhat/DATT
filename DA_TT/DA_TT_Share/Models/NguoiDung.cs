using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class NguoiDung
	{
        [Key]
        public Guid Id { get; set; }
        public Guid? IdChucVu { get; set; }
        public string? HoTen { get; set; }
        public string? Image { get; set; }
        public int? GioiTinh { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? MatKhau { get; set; }
        public int? TrangThai { get; set; }
        public virtual ChucVu? ChucVu { get; set; }
        public virtual List<DonHang>? DonHangNguoiDats { get; set; }
        public virtual List<DonHang>? DonHangNguoiShips { get; set; }
        public virtual List<GioHang>? GioHangs { get; set; }
        public virtual List<LienHe>? LienHeNguoiDungs { get; set; }
        public virtual List<LienHe>? LienHeTraLois { get; set; }
        public virtual List<Voucher_NguoiDung>? MyVoucher { get; set; }

    }
}
