using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class GioHangItem
	{
        [Key]
        public Guid ID { get; set; }
        public string? ItemName { get; set; }
        public int? Soluong { get; set; }
        public decimal? ThanhTien { get; set; }
        public Guid? IdGioHang { get; set; }
        public Guid? IdSanPham { get; set; }
        public virtual GioHang? GioHang { get; set; }
        public virtual SanPham? SanPham { get; set; }

    }
}
