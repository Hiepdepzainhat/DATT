using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/DonHang")]
	[ApiController]
	public class DonHangController : ControllerBase
	{
		private readonly IAllResponsitories<DonHang> irespon;
		LapTopDbContext context = new LapTopDbContext();
        public DonHangController()
        {
            irespon = new AllResponsitories<DonHang>(context,context.DonHang);
        }
		[HttpGet("[Action]")]
		public async Task<List<DonHang>> GetAllDonHang()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateDonHang(Guid? IdNguoiNhan,Guid? IdShipper,Guid? IdVoucher,string? diachinhan,DateTime? ngaydathang,DateTime? ngaygiaohang,DateTime? ngaynhanhang,string? sdtnhanhang, decimal? tongtien)
		{
			DonHang donhang = new DonHang();
			donhang.Id = Guid.NewGuid();
			donhang.IdNguoiNhan = IdNguoiNhan;
			donhang.IdShipper = IdShipper;
			donhang.IdVoucher = IdVoucher;
			donhang.DiaChiNhan = diachinhan;
			donhang.NgayDatHang = ngaydathang;
			donhang.NgayGiaoHang = ngaygiaohang;
			donhang.NgayNhanHang = ngaynhanhang;
			donhang.SDTNhanHang = sdtnhanhang;
			donhang.TongTien = tongtien;
			donhang.TrangThai = 1;
			await irespon.CreateItem(donhang);
			return true;
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateDonHang(Guid id, [FromBody] DonHang dh)
		{
			var lstdh = await irespon.GetAll();
			var donhang = lstdh.FirstOrDefault(x => x.Id == id);
			if(donhang == null)
			{
				return false;
			}
			else
			{
				donhang.IdNguoiNhan = dh.IdNguoiNhan;
				donhang.IdShipper = dh.IdShipper;
				donhang.IdVoucher = dh.IdVoucher;
				donhang.DiaChiNhan = dh.DiaChiNhan;
				donhang.NgayDatHang = dh.NgayDatHang;
				donhang.NgayGiaoHang = dh.NgayGiaoHang;
				donhang.NgayNhanHang = dh.NgayNhanHang;
				donhang.SDTNhanHang = dh.SDTNhanHang;
				donhang.TongTien = dh.TongTien;
				donhang.TrangThai = dh.TrangThai;
				await irespon.UpdateItem(donhang);
				return true;
			}
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteDonHang(Guid id)
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
