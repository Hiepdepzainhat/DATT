using DA_TT_Client.Models;
using DA_TT_Client.ViewModels;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace DA_TT_Client.Controllers
{
	public class HomeController : Controller
	{
		private  HttpClient _httpClient;

		public HomeController()
		{
			_httpClient =  new HttpClient();
		}

		public IActionResult Index()
		{
			return View();
		}
		public  IActionResult Login()
		{
			 return  View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModels lgvm)
		 {
			//var lstnd = await _httpClient.GetFromJsonAsync<List<NguoiDung>>("api/NguoiDung/GetAllNguoiDung");
			var url = $"https://localhost:7290/api/NguoiDung/GetAllNguoiDung";
			var responND = await _httpClient.GetAsync(url);
			string apiData = await responND.Content.ReadAsStringAsync();
			var lstnd = JsonConvert.DeserializeObject<List<NguoiDung>>(apiData);
            string urlCV = $"https://localhost:7290/api/ChucVu/GetAllChucVu";
            var responCV = await _httpClient.GetAsync(urlCV);
            string dataCV = await responCV.Content.ReadAsStringAsync();
            var lstcv = JsonConvert.DeserializeObject<List<ChucVu>>(dataCV);
            var cvCustomer = lstcv.FirstOrDefault(x => x.TenChucVu == "Customer");
            var cvAdmin = lstcv.FirstOrDefault(x => x.TenChucVu == "Admin");
            var cvEmployee = lstcv.FirstOrDefault(x => x.TenChucVu == "Employee");
            var cvShipper = lstcv.FirstOrDefault(x => x.TenChucVu == "Shipper");
            if (lstnd == null)
			{
				TempData["Đéo ổn"] = "Danh Sách Người Dùng Méo Có Ai";
				return NotFound();
			}
			else
			{
				var nd = lstnd.FirstOrDefault(x => x.Email == lgvm.Email && x.MatKhau == lgvm.Password);
				if(nd == null)
				{
					TempData["Login Sai"] = "Tài Khoản hoặc mật khẩu không khớp, Vui Lòng thử lại sau !";
					return View();
				}
				else
				{
					if(nd.TrangThai != 1)
					{
                        TempData["Login False KhoaTK"] = "Tài Khoản của bạn đã bị khóa, vui lòng liên hệ Admin hoặc nhân viên để biết thêm thông tin chi tiết";
                        return View();
					}
				 	if (nd.IdChucVu == cvAdmin.Id)
					{
						return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
					}
					else if (nd.IdChucVu == cvCustomer.Id)
					{
						
						return RedirectToAction("Index", "CustomerHome", new {area = "Customer"});
					}
					else if (nd.IdChucVu == cvShipper.Id)
					{
                        
						return RedirectToAction("Index","ShipperHome",new {area = "Shipper"});
                    }
                    else if (nd.IdChucVu == cvEmployee.Id)
                    {
                        
                        return RedirectToAction("Index", "EmployeeHome", new { area = "Employee" });
                    }
					else
					{
                        TempData["Login Sai"] = "Bạn đã đăng nhập bằng tài khoản Nhân Viên";
						return View();
                    }
                }
				
			}
		}
		
		public IActionResult RegisterCustomer()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> RegisterCustomer(RegisterViewModels rgt )
		{
           
            string urlCV = $"https://localhost:7290/api/ChucVu/GetAllChucVu";
            var responCV = await _httpClient.GetAsync(urlCV);
            string dataCV = await responCV.Content.ReadAsStringAsync();
            var lstcv = JsonConvert.DeserializeObject<List<ChucVu>>(dataCV);
            var cvCustomer = lstcv.FirstOrDefault(x => x.TenChucVu == "Customer");
			rgt.Image = "user1.jpg";
			string urlAPI = $"https://localhost:7290/api/NguoiDung/RegisterCustomer?hoten={rgt.hoTen}&image={rgt.Image}&gioitinh={rgt.GioiTinh}&Email={rgt.Email}&matkhau={rgt.MatKhau}&sdt={rgt.SDT}&ngaysinh={rgt.NgaySinh}";
            var content = new StringContent(JsonConvert.SerializeObject(rgt), Encoding.UTF8, "application/json");
            var respon = await _httpClient.PostAsync(urlAPI, content);
            if (!respon.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return RedirectToAction("Login", "Home");
        }
		public IActionResult RegisterShipper()
		{
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}