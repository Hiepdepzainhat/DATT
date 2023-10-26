using DA_TT_API.IResponse;
using DA_TT_Share.Context;
using DA_TT_Share.Models;
using Microsoft.EntityFrameworkCore;

namespace DA_TT_API.Response
{
	public class AccountResponse : IAccountRespon
	{
		private readonly LapTopDbContext _context;
        public AccountResponse()
        {
            _context = new LapTopDbContext();
        }
        public async Task<NguoiDung> Login(string Email, string matkhau)
		{
			try
			{
				var acc = await _context.NguoiDung.FirstOrDefaultAsync(x => x.Email == Email && x.MatKhau == matkhau);
				if (acc == null)
				{
					return null;
				}
				else
				{
					return acc;
				}
			}
			catch (Exception)
			{
				return new NguoiDung();	
			}
		}

		public async Task<bool> RegisterCustomer(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh)
		{
			try
			{
				var lstUser = await _context.NguoiDung.ToListAsync();
				var user = lstUser.FirstOrDefault(x => x.Email == Email);
				if (user != null)
				{
					return false;
				}
				NguoiDung nd = new NguoiDung();
				nd.Id = Guid.NewGuid();
				nd.IdChucVu = Guid.Parse("303053A2-9BA0-4A31-926A-9CFF1F0DD132");
				nd.HoTen = hoten;
				nd.Image = image;
				nd.GioiTinh = gioitinh;
				nd.Email = Email;
				nd.MatKhau = matkhau;
				nd.SoDienThoai = sdt;
				nd.NgaySinh = ngaysinh;
				nd.TrangThai = 1;
				await _context.AddAsync(nd);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public async Task<bool> RegisterShipper(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh)
		{
			try
			{
				var lstUser = await _context.NguoiDung.ToListAsync();
				var user = lstUser.FirstOrDefault(x => x.Email == Email);
				if (user != null)
				{
					return false;
				}
				NguoiDung nd = new NguoiDung();
				nd.Id = Guid.NewGuid();
				nd.IdChucVu = Guid.Parse("37A44A14-BB52-40C1-BE65-ED05B5283364");
				nd.HoTen = hoten;
				nd.Image = image;
				nd.GioiTinh = gioitinh;
				nd.Email = Email;
				nd.MatKhau = matkhau;
				nd.SoDienThoai = sdt;
				nd.NgaySinh = ngaysinh;
				nd.TrangThai = 1;
				await _context.AddAsync(nd);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
        public async Task<bool> RegisterAdmin(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh)
        {
            try
            {
                var lstUser = await _context.NguoiDung.ToListAsync();
                var user = lstUser.FirstOrDefault(x => x.Email == Email);
                if (user != null)
                {
                    return false;
                }
                NguoiDung nd = new NguoiDung();
                nd.Id = Guid.NewGuid();
                nd.IdChucVu = Guid.Parse("F1260239-2A91-47D1-A4F4-F7B354C3E670");
                nd.HoTen = hoten;
                nd.Image = image;
                nd.GioiTinh = gioitinh;
                nd.Email = Email;
                nd.MatKhau = matkhau;
                nd.SoDienThoai = sdt;
                nd.NgaySinh = ngaysinh;
                nd.TrangThai = 1;
                await _context.AddAsync(nd);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
