using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class Voucher_NguoiDung
	{
        [Key]
        public Guid IDNguoiDung { get; set; }
        [Key]
        public Guid IDVoucher { get; set; }
        public int? SoLuong { get; set; }
        public int? TrangThai { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public virtual Voucher? Voucher { get; set; }

    }
}
