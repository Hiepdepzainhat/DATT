using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/DonHangChiTiet")]
	[ApiController]
	public class DonHangChiTietController : ControllerBase
	{
		private readonly IAllResponsitories<DonHangChiTiet> irespon;
		LapTopDbContext context = new LapTopDbContext();
        public DonHangChiTietController()
        {
            irespon = new AllResponsitories<DonHangChiTiet>(context,context.ChiTietDonHang);
        }
		[HttpGet("[Action]")]
		public async Task<List<DonHangChiTiet>> GetAllDonHangChiTiet()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateDonHangChiTiet(Guid? Iddonhang, Guid? idSanPham, int? soluong, decimal? dongia,decimal? tongtien)
		{
			DonHangChiTiet dhct = new DonHangChiTiet();
			dhct.Id = Guid.NewGuid();
			dhct.IdDonHang = Iddonhang;
			dhct.IdSanPham = idSanPham;
			dhct.Soluong = soluong;
			dhct.DonGia = dongia;
			dhct.TongTien = tongtien;
			await irespon.CreateItem(dhct);
			return true;
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateDonHangChiTiet(Guid id, [FromBody] DonHangChiTiet t)
		{
			var lstdhct = await irespon.GetAll();
			var dhct = lstdhct.FirstOrDefault(x => x.Id == id);	
			if(dhct == null)
			{
				return false;
			}
			else
			{
				dhct.IdDonHang = t.IdDonHang;
				dhct.IdSanPham = t.IdSanPham;
				dhct.Soluong = t.Soluong;
				dhct.DonGia = t.DonGia;
				dhct.TongTien = t.TongTien;
				await irespon.UpdateItem(dhct);
				return true;
			}
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteDonHangChiTiet(Guid id)
		{
			var lstdhct = await irespon.GetAll();
			var dhct = lstdhct.FirstOrDefault(x => x.Id == id);
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
