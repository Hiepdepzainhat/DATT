using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA_TT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CouponController : ControllerBase
	{
		private readonly IAllResponsitories<Coupon> irespon;
		LapTopDbContext context = new LapTopDbContext();
		public CouponController()
		{
			irespon = new AllResponsitories<Coupon>(context, context.Coupon);
		}
		[HttpGet("[Action]")]
		public async Task<List<Coupon>> GetAllCoupon()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateCoupon(string ten, int phantramgiam, DateTime ngaydb, DateTime ngaykt)
		{
			var lstCoupon = await irespon.GetAll();
			var CouponCheck = lstCoupon.FirstOrDefault(x => x.TenCoupon == ten);
			if (CouponCheck != null)
			{
				return false;
			}
			Coupon Coupon = new Coupon();
			Coupon.Id = Guid.NewGuid();
			Coupon.TenCoupon = ten;
			Coupon.PhanTramGiam = phantramgiam;
			Coupon.NgayBatDau = ngaydb;
			Coupon.NgayKetThuc = ngaykt;
			Coupon.TrangThai = 1;
			return await irespon.CreateItem(Coupon);
		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateCoupon(Guid id, [FromBody] Coupon cp)
		{
			var lstCoupon = await irespon.GetAll();
			var Coupon = lstCoupon.FirstOrDefault(x => x.Id == id);
			if (Coupon == null)
			{
				return false;
			}
			else
			{
				Coupon.TenCoupon = cp.TenCoupon;
				Coupon.PhanTramGiam = cp.PhanTramGiam;
				Coupon.NgayBatDau = cp.NgayBatDau;
				Coupon.NgayKetThuc = cp.NgayKetThuc;
				Coupon.TrangThai = cp.TrangThai;
			}
			return await irespon.UpdateItem(Coupon);
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteCoupon(Guid id)
		{
			var lstCoupon = await irespon.GetAll();
			var Coupon = lstCoupon.FirstOrDefault(x => x.Id == id);
			if (Coupon == null)
			{
				return false;
			}
			else
			{
				return await irespon.DeleteItem(Coupon);
			}

		}
	}
}
