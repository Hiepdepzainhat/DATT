using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class DonHang
	{
        [Key]
        public Guid Id { get; set; }
        public string? DiaChiNhan { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public DateTime? NgayGiaoHang { get; set; }
        public DateTime? NgayNhanHang { get; set; }
        public string? SDTNhanHang { get; set; }
        public decimal? TienShip { get; set; }
        public decimal? TongTien { get; set; }
        public int? TrangThai { get; set; }
        public Guid? IdNguoiNhan { get; set; }
        public Guid? IdShipper { get; set; }    
        public Guid? IdVoucher { get; set; }
        public virtual NguoiDung? NguoiDat { get; set; }
        public virtual NguoiDung? NguoiShip {  get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual List<DonHangChiTiet>? DonHangChiTiets { get; set; }

    }
}
