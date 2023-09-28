using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class GioHang
	{
		[Key]
        public Guid Id { get; set; }
        public decimal? TongTien { get; set; }
        public Guid? IdNguoiDung { get; set; }
        public Guid? IdVoucher { get; set; }
        public int TrangThai { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual List<GioHangItem>? GioHangItems { get; set; }
    }
}
