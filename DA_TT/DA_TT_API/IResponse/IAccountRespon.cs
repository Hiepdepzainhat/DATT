using DA_TT_Share.Models;

namespace DA_TT_API.IResponse
{
	public interface IAccountRespon
	{
		Task<bool> RegisterCustomer(string hoten,string image, int gioitinh, string Email, string matkhau,string sdt, DateTime ngaysinh);
		Task<bool> RegisterShipper(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh);
        Task<bool> RegisterAdmin(string hoten, string image, int gioitinh, string Email, string matkhau, string sdt, DateTime ngaysinh);
        Task<NguoiDung> Login(string Email, string matkhau);
	}
}
