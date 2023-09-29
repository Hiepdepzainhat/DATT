using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/HanSanXuat")]
	[ApiController]
	public class HangSanXuatController : ControllerBase
	{
		private readonly IAllResponsitories<HangSanXuat> irespon;
		LapTopDbContext context = new LapTopDbContext();
        public HangSanXuatController()
        {
            irespon = new AllResponsitories<HangSanXuat>(context,context.HangSanXuat);
        }
		[HttpGet("[Action]")]
		public async Task<List<HangSanXuat>> GetAllHangSX()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateHangSX(string ten, string mota)
		{	
			var lstHangSX = await irespon.GetAll();
			var hangsxCheck = lstHangSX.FirstOrDefault(x => x.TenHangSanXuat == ten);
			if(hangsxCheck != null)
			{
				return false;
			}
			HangSanXuat hangsx = new HangSanXuat();
			hangsx.Id = Guid.NewGuid();
			hangsx.TenHangSanXuat = ten;
			hangsx.Desciption = mota;
			hangsx.TrangThai = 1;
			return await irespon.CreateItem(hangsx);
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateHangSX(Guid id, [FromBody] HangSanXuat hsx)
		{
			var lstHangsx = await irespon.GetAll();
			var hangsx =  lstHangsx.FirstOrDefault(x => x.Id == id);
			if(hangsx == null)
			{
				return false;
			}
			else
			{
				hangsx.TenHangSanXuat = hsx.TenHangSanXuat;
				hangsx.Desciption = hsx.Desciption;
				hangsx.TrangThai = hsx.TrangThai;
			}
			return await irespon.UpdateItem(hangsx);
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteHangSX(Guid id)
		{
			var lstHangsx = await irespon.GetAll();
			var hangsx = lstHangsx.FirstOrDefault(x => x.Id == id);
			if (hangsx == null)
			{
				return false;
			}
			else
			{
				return await irespon.DeleteItem(hangsx);
			}
			
		}
    }
}
