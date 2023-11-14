using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/GioHangItem")]
	[ApiController]
	public class GioHangItemController : ControllerBase
	{
		private readonly IAllResponsitories<GioHangItem> irespon;
		LapTopDbContext context = new LapTopDbContext();
        public GioHangItemController()
        {
            irespon = new AllResponsitories<GioHangItem>(context,context.GioHangItem);
        }
		[HttpGet("[Action]")]
		public async Task<List<GioHangItem>> GetAllGioHangItem()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateGioHangItem(Guid? idgioHang, Guid? idSanPham,string? ItemName,decimal? DonGia, int? soluong)
		{
			GioHangItem git = new GioHangItem();
			git.ID = Guid.NewGuid();
			git.IdGioHang = idgioHang;
			git.IdSanPham = idSanPham;
            git.ItemName = ItemName;
			git.DonGia = DonGia;
            git.Soluong = soluong;
			git.ThanhTien = git.DonGia * git.Soluong;
			await irespon.CreateItem(git);
			return true;
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateGioHangItem(Guid id, [FromBody] GioHangItem? t)
		{
			var lstgit = await irespon.GetAll();
			var git = lstgit.FirstOrDefault(x => x.ID == id);
			if (git == null)
			{
				return false;
			}
			else
			{
				git.IdGioHang = t.IdGioHang;
				git.IdSanPham = t.IdSanPham;
				git.Soluong = t.Soluong;
				git.ThanhTien = t.ThanhTien;
				await irespon.UpdateItem(git);
				return true;
			}
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteGioHangItem(Guid id)
		{
			var lstdhct = await irespon.GetAll();
			var dhct = lstdhct.FirstOrDefault(x => x.ID == id);
			if (dhct == null)
			{
				return false;
			}
			else
			{

				await irespon.DeleteItem(dhct);
				return true;
			}

		}
	}
}
