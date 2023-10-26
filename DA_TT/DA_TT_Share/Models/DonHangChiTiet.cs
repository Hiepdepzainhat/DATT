using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class DonHangChiTiet
    {
        [Key]
        public Guid Id { get; set; }
		public Guid? IdDonHang { get; set; }
		public Guid? IdSanPham { get; set; }
		public int? Soluong { get; set; }
		public decimal? DonGia { get; set; } 
		public decimal? TongTien { get; set; } 
        public virtual DonHang? DonHang { get; set; }
        public virtual SanPham? SanPham { get; set; } 
    }
}
