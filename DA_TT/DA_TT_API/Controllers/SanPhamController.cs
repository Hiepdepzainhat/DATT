using DA_TT_API.IResponsitories;
using DA_TT_API.Responsitories;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;

namespace DA_TT_API.Controllers
{
	[Route("api/SanPham")]
	[ApiController]
	public class SanPhamController : ControllerBase
	{
		private readonly IAllResponsitories<SanPham> irespon;
		LapTopDbContext context = new LapTopDbContext();
        public SanPhamController()
        {
            irespon = new AllResponsitories<SanPham>(context,context.SanPham);	
        }
		[HttpGet("[Action]")]
		public async Task<List<SanPham>> GetAllSanPham()
		{
			return await irespon.GetAll();
		}
		[HttpPost("[Action]")]
		public async Task<bool> CreateSanPham(Guid? IdDanhMuc,Guid? IdHangSX, Guid?IdCoupon,string? tenSanPham,string? CPU,decimal? giaNhap,decimal? giaBan,int? dungLuongPin,int? HeDieuHanh, string? manHinh,int? ram,int? tongSoLuong,int? soLuongDaBan,string? thongTinBH)
		{
			var lstsp = await irespon.GetAll();
			var sp = lstsp.FirstOrDefault(x => x.TenSanPham == tenSanPham);
			if(sp != null)
			{
				return false;
			}
			else
			{
				SanPham nsp = new SanPham();
				nsp.Id = Guid.NewGuid();
				nsp.IdDanhMuc = IdDanhMuc;
				nsp.IdHangSX = IdHangSX;
				nsp.IdCoupon = IdCoupon;
				nsp.TenSanPham = tenSanPham;
				nsp.CPU = CPU;
				nsp.GiaNhap = giaNhap;
				nsp.GiaBan = giaBan;
				nsp.DungLuongPin = dungLuongPin;	
				nsp.HeDieuHanh = HeDieuHanh;
				nsp.ManHinh = manHinh;
				nsp.Ram = ram;
				nsp.TongSoLuong = tongSoLuong;
				nsp.SoLuongDaBan = soLuongDaBan;
				nsp.SoLuongTon = tongSoLuong - soLuongDaBan;
				nsp.ThongTinBaoHanh = thongTinBH;
				nsp.TrangThai = 1;
				await irespon.CreateItem(nsp);
				return true;
			}

		}
		[HttpPut("[Action]/{id}")]
		public async Task<bool> UpdateSanPham(Guid id, [FromBody] SanPham pham)
		{
			var lstsp = await irespon.GetAll();
			var nsp = lstsp.FirstOrDefault(x => x.Id == id);
			if(nsp == null)
			{
				return false;
			}
			else
			{
				nsp.IdDanhMuc = pham.IdDanhMuc;
				nsp.IdHangSX = pham.IdHangSX;
				nsp.IdCoupon = pham.IdCoupon;
				nsp.TenSanPham = pham.TenSanPham;
				nsp.CPU = pham.CPU;
				nsp.GiaNhap = pham.GiaNhap;
				nsp.GiaBan = pham.GiaBan;
				nsp.DungLuongPin = pham.DungLuongPin;
				nsp.HeDieuHanh = pham.HeDieuHanh;
				nsp.ManHinh = pham.ManHinh;
				nsp.Ram = pham.Ram;
				nsp.TongSoLuong = pham.TongSoLuong;
				nsp.SoLuongDaBan = pham.SoLuongDaBan;
				nsp.SoLuongTon = pham.TongSoLuong - pham.SoLuongDaBan;
				nsp.ThongTinBaoHanh = pham.ThongTinBaoHanh;
				nsp.TrangThai = pham.TrangThai;
				await irespon.UpdateItem(nsp);
				return true;
			}
		}
		[HttpDelete("[Action]/{id}")]
		public async Task<bool> DeleteSanPham(Guid id)
		{
			var lstsp = await irespon.GetAll();
			var nsp = lstsp.FirstOrDefault(x => x.Id == id);
			if (nsp == null)
			{
				return false;
			}
			else
			{
				await irespon.DeleteItem(nsp);
				return true;
			}
		}
    }
}
