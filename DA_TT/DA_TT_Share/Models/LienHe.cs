using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class LienHe
	{
        [Key]
        public Guid Id { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdNguoiDung { get; set; }
        public Guid? IdNguoiTrLoi { get; set; }
        public string? NoiDungNguoiDung { get; set; }
        public DateTime? NgayLienHe { get; set; }
        public DateTime? NgayTraLoi { get; set; }
        public string? NoiDungLienHe { get; set; }
        public string? NoiDungTraLoi { get; set; }
        public int? TrangThai { get; set; }  
        public virtual NguoiDung? NguoiTraLoi { get; set; }
        public virtual SanPham? SanPham { get; set; }
        public virtual NguoiDung? NguoiLienHe { get; set; }
    }
}
