using System.ComponentModel.DataAnnotations;

namespace DA_TT_Client.ViewModels
{
	public class RegisterViewModels
	{
		public string hoTen { get; set; }
		[Required]
		public string SDT { get; set; }
        [Required]
		public string Image { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MatKhau { get; set; }
		[Required]
		public int GioiTinh { get; set; }
		public DateTime NgaySinh {  get; set; }
    }
}
