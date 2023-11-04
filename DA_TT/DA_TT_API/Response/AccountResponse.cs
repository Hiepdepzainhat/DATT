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
			
				var lstRole = await _context.ChucVu.ToListAsync();
				var roleCus = lstRole.FirstOrDefault(x => x.TenChucVu == "Customer");
				if(roleCus == null)
				{
					return false;
				}
				var lstUser = await _context.NguoiDung.ToListAsync();
				var user = lstUser.FirstOrDefault(x => x.Email == Email);
				if (user != null)
				{
					return false;
				}
				NguoiDung nd = new NguoiDung();
				nd.Id = Guid.NewGuid();
				nd.IdChucVu = roleCus.Id;
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
		public async Task<bool> RegisterShipper(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh)
		{
			try
			{
                var lstRole = await _context.ChucVu.ToListAsync();
                var roleShip = lstRole.FirstOrDefault(x => x.TenChucVu == "Shipper");
                var lstUser = await _context.NguoiDung.ToListAsync();
				var user = lstUser.FirstOrDefault(x => x.Email == Email);
				if (user != null)
				{
					return false;
				}
				NguoiDung nd = new NguoiDung();
				nd.Id = Guid.NewGuid();
				nd.IdChucVu = roleShip.Id;
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
                var lstRole = await _context.ChucVu.ToListAsync();
                var roleAdmin = lstRole.FirstOrDefault(x => x.TenChucVu == "Admin");
                var lstUser = await _context.NguoiDung.ToListAsync();
                var user = lstUser.FirstOrDefault(x => x.Email == Email);
                if (user != null)
                {
                    return false;
                }
                NguoiDung nd = new NguoiDung();
                nd.Id = Guid.NewGuid();
                nd.IdChucVu = roleAdmin.Id;
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
        public async Task<bool> RegisterEmployee(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh)
        {
            try
            {
                var lstRole = await _context.ChucVu.ToListAsync();
                var roleEmployee = lstRole.FirstOrDefault(x => x.TenChucVu == "Employee");
                var lstUser = await _context.NguoiDung.ToListAsync();
                var user = lstUser.FirstOrDefault(x => x.Email == Email);
                if (user != null)
                {
                    return false;
                }
                NguoiDung nd = new NguoiDung();
                nd.Id = Guid.NewGuid();
                nd.IdChucVu = roleEmployee.Id;
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
