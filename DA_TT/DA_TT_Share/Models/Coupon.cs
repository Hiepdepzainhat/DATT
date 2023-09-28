using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class Coupon
	{
        [Key]
        public Guid Id { get; set; }
        public int? PhanTramGiam { get; set; }
        public string? TenCoupon { get; set; }
        public DateTime?  NgayBatDau { get; set; }
        public DateTime?  NgayKetThuc { get; set; }
        public int? TrangThai { get; set; }
        public virtual List<SanPham>? SanPhams { get; set; }
    }
}
