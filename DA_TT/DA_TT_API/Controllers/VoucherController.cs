using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/Voucher")]
	[ApiController]
	public class VoucherController : ControllerBase
	{
		private readonly IAllResponsitories<Voucher> irespon;
		LapTopDbContext context = new LapTopDbContext();
		public VoucherController()
		{
			irespon = new AllResponsitories<Voucher>(context, context.Voucher);
		}
		[HttpGet("[Action]")]
		public async Task<List<Voucher>> GetAllVoucher()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateVoucher(string ten,decimal tiengiam,decimal dieukiendonhang,int soluong, DateTime ngaydb, DateTime ngaykt)
		{
			var lstVoucher = await irespon.GetAll();
			var VoucherCheck = lstVoucher.FirstOrDefault(x => x.TenVouCher == ten);
			if (VoucherCheck != null)
			{
				return false;
			}
			Voucher Voucher = new Voucher();
			Voucher.Id = Guid.NewGuid();
			Voucher.TenVouCher = ten;
			Voucher.TienGiam = tiengiam;
			Voucher.DieuKienDonHang = dieukiendonhang;
			Voucher.SoLuong = soluong;
			Voucher.NgayBatDau = ngaydb;
			Voucher.NgayKetThuc = ngaykt;
			Voucher.TrangThai = 1;
			return await irespon.CreateItem(Voucher);
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateVoucher(Guid id, [FromBody] Voucher cp)
		{
			var lstVoucher = await irespon.GetAll();
			var Voucher = lstVoucher.FirstOrDefault(x => x.Id == id);
			if (Voucher == null)
			{
				return false;
			}
			else
			{
				Voucher.TenVouCher = cp.TenVouCher;
				Voucher.TienGiam = cp.TienGiam;
				Voucher.DieuKienDonHang = cp.DieuKienDonHang;
				Voucher.SoLuong = cp.SoLuong;
				Voucher.NgayBatDau = cp.NgayBatDau;
				Voucher.NgayKetThuc = cp.NgayKetThuc;
				Voucher.TrangThai = cp.TrangThai;
			}
			return await irespon.UpdateItem(Voucher);
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteVoucher(Guid id)
		{
			var lstVoucher = await irespon.GetAll();
			var Voucher = lstVoucher.FirstOrDefault(x => x.Id == id);
			if (Voucher == null)
			{
				return false;
			}
			else
			{
				return await irespon.DeleteItem(Voucher);
			}

		}
	}
}
