using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/DanhMuc")]
	[ApiController]
	public class DanhMucController : ControllerBase
	{
		private readonly IAllResponsitories<DanhMuc> irespon;
		LapTopDbContext context = new LapTopDbContext();
		public DanhMucController()
		{
			irespon = new AllResponsitories<DanhMuc>(context, context.DanhMuc);
		}
		[HttpGet("[Action]")]
		public async Task<List<DanhMuc>> GetAllDanhMuc() 
		{ 
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateHangSX(string ten, string mota)
		{
			var lstDanhMuc = await irespon.GetAll();
			var danhmucCheck = lstDanhMuc.FirstOrDefault(x => x.Ten == ten);
			if (danhmucCheck != null)
			{
				return false;
			}
			DanhMuc danhmuc = new DanhMuc();
			danhmuc.Id = Guid.NewGuid();
			danhmuc.Ten = ten;
			danhmuc.Mota = mota;
			danhmuc.TrangThai = 1;
			return await irespon.CreateItem(danhmuc);
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateHangSX(Guid id, [FromBody] DanhMuc dm)
		{
			var lstdanhmuc = await irespon.GetAll();
			var danhmuc = lstdanhmuc.FirstOrDefault(x => x.Id == id);
			if (danhmuc == null)
			{
				return false;
			}
			else
			{
				danhmuc.Ten = dm.Ten;
				danhmuc.Mota = dm.Mota;
				danhmuc.TrangThai = dm.TrangThai;
			}
			return await irespon.UpdateItem(danhmuc);
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteHangSX(Guid id)
		{
			var lstdanhmuc = await irespon.GetAll();
			var danhmuc = lstdanhmuc.FirstOrDefault(x => x.Id == id);
			if (danhmuc == null)
			{
				return false;
			}
			else
			{
				return await irespon.DeleteItem(danhmuc);
			}

		}
	}
}
