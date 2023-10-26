using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/GioHang")]
	[ApiController]
	public class GioHangController : ControllerBase
	{
		private readonly IAllResponsitories<GioHang> irespon;
		LapTopDbContext context = new LapTopDbContext();
        public GioHangController()
        {
            irespon = new AllResponsitories<GioHang>(context,context.GioHang);
        }
		[HttpGet("[Action]")]
		public async Task<List<GioHang>> GetAllGioHang()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateGioHang(Guid? idnguoidung, Guid? IdVoucher, decimal? tongtien)
		{
			GioHang giohang = new GioHang();
			giohang.Id = Guid.NewGuid();
			giohang.IdNguoiDung = idnguoidung;
			giohang.IdVoucher = IdVoucher;
			giohang.TongTien = tongtien;
			giohang.TrangThai = 1;
			await irespon.CreateItem(giohang);
			return true;
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateGioHang(Guid id, [FromBody] GioHang gh)
		{
			var lstgh = await irespon.GetAll();
			var giohang = lstgh.FirstOrDefault(x => x.Id == id);
			if (giohang == null)
			{
				return false;
			}
			else
			{
				giohang.IdNguoiDung = gh.IdNguoiDung;
				giohang.IdVoucher = gh.IdVoucher;
				giohang.TongTien = gh.TongTien;
				giohang.TrangThai = gh.TrangThai;
				await irespon.UpdateItem(giohang);
				return true;
			}
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteGioHang(Guid id)
		{
			var lstdh = await irespon.GetAll();
			var donhang = lstdh.FirstOrDefault(x => x.Id == id);
			if (donhang == null)
			{
				return false;
			}
			else
			{
				await irespon.DeleteItem(donhang);
				return true;
			}
		}
	}
}
