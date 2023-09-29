using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/ChucVu")]
	[ApiController]
	public class ChucVuController : ControllerBase
	{
		private readonly IAllResponsitories<ChucVu> irespon;
		LapTopDbContext context = new LapTopDbContext();
		public ChucVuController()
		{
			irespon = new AllResponsitories<ChucVu>(context, context.ChucVu);
		}
		[HttpGet("[Action]")]
		public async Task<List<ChucVu>> GetAllChucVu()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateHangSX(string ten, string mota)
		{
			var lstChucVu = await irespon.GetAll();
			var ChucVuCheck = lstChucVu.FirstOrDefault(x => x.TenChucVu == ten);
			if (ChucVuCheck != null)
			{
				return false;
			}
			ChucVu ChucVu = new ChucVu();
			ChucVu.Id = Guid.NewGuid();
			ChucVu.TenChucVu = ten;
			ChucVu.Mota = mota;
			ChucVu.TrangThai = 1;
			return await irespon.CreateItem(ChucVu);
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateHangSX(Guid id, [FromBody] ChucVu dm)
		{
			var lstChucVu = await irespon.GetAll();
			var ChucVu = lstChucVu.FirstOrDefault(x => x.Id == id);
			if (ChucVu == null)
			{
				return false;
			}
			else
			{
				ChucVu.TenChucVu = dm.TenChucVu;
				ChucVu.Mota = dm.Mota;
				ChucVu.TrangThai = dm.TrangThai;
			}
			return await irespon.UpdateItem(ChucVu);
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteHangSX(Guid id)
		{
			var lstChucVu = await irespon.GetAll();
			var ChucVu = lstChucVu.FirstOrDefault(x => x.Id == id);
			if (ChucVu == null)
			{
				return false;
			}
			else
			{
				return await irespon.DeleteItem(ChucVu);
			}

		}
	}
}
