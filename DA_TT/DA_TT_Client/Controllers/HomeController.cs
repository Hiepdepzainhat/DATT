using DA_TT_Client.Models;
using DA_TT_Client.ViewModels;
using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

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
			if(lstnd == null)
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
					if (nd.IdChucVu == Guid.Parse("F1260239-2A91-47D1-A4F4-F7B354C3E670"))
					{
						return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
					}
					else if (nd.IdChucVu == Guid.Parse("303053A2-9BA0-4A31-926A-9CFF1F0DD132"))
					{
						TempData["Login Sai"] = "Bạn đã đăng nhập bằng tài khoản User";
						return RedirectToAction("Index", "CustomerHome", new {area = "Customer"});
					}
					else if (nd.IdChucVu == Guid.Parse("37A44A14-BB52-40C1-BE65-ED05B5283364"))
					{
                        TempData["Login Sai"] = "Bạn đã đăng nhập bằng tài khoản Shipper";
						return RedirectToAction("Index","ShipperHome",new {area = "Shipper"});
                    }
                    else if (nd.IdChucVu == Guid.Parse("D3A4193C-2FB9-4ED4-89EE-0E7216099FF8"))
                    {
                        TempData["Login Sai"] = "Bạn đã đăng nhập bằng tài khoản Nhân Viên";
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
		public IActionResult Register()
		{
			return View();
		}
		public IActionResult RegisterCustomer()
		{
			return View();
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