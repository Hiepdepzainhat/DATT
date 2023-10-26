using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DA_TT_API.Controllers
{
	[Route("api/LienHe")]
	[ApiController]
	public class LienHeController : ControllerBase
	{
		private readonly IAllResponsitories<LienHe> irespon;
		LapTopDbContext context = new LapTopDbContext();
        public LienHeController()
        {
            irespon = new AllResponsitories<LienHe>(context, context.LienHe);
        }
		[HttpGet("[Action]")]
		public async Task<List<LienHe>> GetAllLienHe()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateLienHe(Guid? idSanPham, Guid? idnguoidung, Guid? idnguoitraloi, string? noidungLienhe,DateTime? ngaylienhe, string? noidungtraloi,DateTime? ngaytraloi)
		{
			LienHe lh = new LienHe();
			lh.Id = Guid.NewGuid();
			lh.IdSanPham = idSanPham;
			lh.IdNguoiDung = idnguoidung;
			lh.IdNguoiTrLoi = idnguoitraloi;
			lh.NoiDungLienHe = noidungLienhe;
			lh.NgayLienHe = ngaylienhe;
			lh.NoiDungTraLoi = noidungtraloi;
			lh.NgayTraLoi = ngaytraloi;
			lh.TrangThai = 1;
			await irespon.CreateItem(lh);
			return true;
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateLienHe(Guid id, [FromBody] LienHe lienhe)
		{
			var lstlh = await irespon.GetAll();
			var lh = lstlh.FirstOrDefault(x => x.Id == id);
			if(lh == null)
			{
				return false;
			}
			else
			{
				lh.IdSanPham = lienhe.IdSanPham;
				lh.IdNguoiDung = lienhe.IdNguoiDung;
				lh.IdNguoiTrLoi = lienhe.IdNguoiTrLoi;
				lh.NoiDungLienHe = lienhe.NoiDungLienHe;
				lh.NgayLienHe = lienhe.NgayLienHe;
				lh.NoiDungTraLoi = lienhe.NoiDungTraLoi;
				lh.NgayTraLoi = lienhe.NgayTraLoi;
				lh.TrangThai = lienhe.TrangThai;
				await irespon.UpdateItem(lh);
				return true;
			}
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteLienHe(Guid id)
		{
			var lstlh = await irespon.GetAll();
			var lh = lstlh.FirstOrDefault(x => x.Id == id);
			if (lh == null)
			{
				return false;
			}
			else
			{
				await irespon.DeleteItem(lh);
				return true;
			}
		}
    }
}
