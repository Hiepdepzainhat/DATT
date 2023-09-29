using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_TT_Share.Models
{
	public class ChucVu
	{
		[Key]
        public Guid Id { get; set; }
        public string? TenChucVu { get; set; }
        public string? Mota { get; set; }
        public int? TrangThai { get; set; }
        public virtual List<NguoiDung> ? NguoiDungs {  get; set; }
    }
}
