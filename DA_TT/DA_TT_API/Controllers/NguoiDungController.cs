using DA_TT_API.IResponse;
using DA_TT_API.IResponsitories;
using DA_TT_API.Response;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/NguoiDung")]
	[ApiController]
	public class NguoiDungController : ControllerBase
	{
		private readonly IAllResponsitories<NguoiDung> irespon;
		private readonly IAccountRespon response;
		LapTopDbContext context = new LapTopDbContext();
        public NguoiDungController()
        {
			irespon = new AllResponsitories<NguoiDung>(context, context.NguoiDung);
			response = new AccountResponse();
        }
		[HttpGet("[Action]")]
		public async Task<List<NguoiDung>> GetAllNguoiDung()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> RegisterCustomer(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh)
		{
			return await response.RegisterCustomer(hoten, image, gioitinh, Email, matkhau, sdt, ngaysinh);
		}
		[HttpPost("[Action]")]
		public async Task<bool> RegisterShipper(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh)
		{
			return await response.RegisterShipper(hoten, image, gioitinh, Email, matkhau, sdt, ngaysinh);
		}
        [HttpPost("[Action]")]
        public async Task<bool> RegisterAdmin(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh)
        {
            return await response.RegisterAdmin(hoten, image, gioitinh, Email, matkhau, sdt, ngaysinh);
        }
        [HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateThongTinCustomer(Guid id,[FromBody] NguoiDung nd)
		{
			var lstNguoiDung = await irespon.GetAll();
			var nguoidung =  lstNguoiDung.FirstOrDefault(x => x.Id == id);
			if(nguoidung == null)
			{
				return false;
			}
			else
			{
				nguoidung.HoTen = nd.HoTen;
				nguoidung.IdChucVu = Guid.Parse("303053A2-9BA0-4A31-926A-9CFF1F0DD132");
				nguoidung.Image = nd.Image;
				nguoidung.GioiTinh = nd.GioiTinh;
				nguoidung.Email = nguoidung.Email;
				nguoidung.MatKhau = nd.MatKhau;
				nguoidung.SoDienThoai = nd.SoDienThoai;
				nguoidung.NgaySinh = nd.NgaySinh;
				nguoidung.TrangThai = nd.TrangThai;
				return await irespon.UpdateItem(nguoidung);
			}
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateThongTinShipper(Guid id, [FromBody] NguoiDung nd)
		{
			var lstNguoiDung = await irespon.GetAll();
			var nguoidung = lstNguoiDung.FirstOrDefault(x => x.Id == id);
			if (nguoidung == null)
			{
				return false;
			}
			else
			{
				nguoidung.HoTen = nd.HoTen;
				nguoidung.IdChucVu = Guid.Parse("37A44A14-BB52-40C1-BE65-ED05B5283364");
				nguoidung.Image = nd.Image;
				nguoidung.GioiTinh = nd.GioiTinh;
				nguoidung.Email = nguoidung.Email;
				nguoidung.MatKhau = nd.MatKhau;
				nguoidung.SoDienThoai = nd.SoDienThoai;
				nguoidung.NgaySinh = nd.NgaySinh;
				nguoidung.TrangThai = nd.TrangThai;
				return await irespon.UpdateItem(nguoidung);
			}
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteNguoiDung(Guid id)
		{
			var lstnd = await irespon.GetAll();
			var nd = lstnd.FirstOrDefault(x => x.Id == id);
			if (nd == null)
			{
				return false;
			}
			else
			{
				return await irespon.DeleteItem(nd);
			}

		}
		[HttpGet("[Action]/{id}")]
		public async Task<NguoiDung> Login(string email, string pass)
		{
			return await response.Login(email, pass);
		}
	}
}
