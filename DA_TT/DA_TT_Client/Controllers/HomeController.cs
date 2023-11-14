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
        public List<GioHangItem> gioHangItems { get; set; } = new List<GioHangItem>();
		public HomeController()
		{
			_httpClient =  new HttpClient();
		}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);
            if (lstDM == null)
            {
                return NotFound();
            }
            var DMGaming = lstDM.FirstOrDefault(x => x.Ten == "Laptop Gaming");
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if (lstSpOk == null)
            {
                return NotFound();
            }
            var lstSPselectNew = lstSpOk.OrderByDescending(x => x.NgayNhap).Take(6).ToList();
            ViewBag.lstSPselectNew = lstSPselectNew;
            var lstSPselectSLdaban = lstSpOk.OrderByDescending(x => x.SoLuongDaBan).Take(8).ToList();
            ViewBag.lstSPselectSLdaban = lstSPselectSLdaban;
            if (DMGaming != null)
            {
                var lstSpGaming = lstSpOk.Where(x => x.IdDanhMuc == DMGaming.Id);
                ViewBag.lstSpGaming = lstSpGaming;
            }

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
                        string updatedJson = JsonConvert.SerializeObject(nd);
                        Response.Cookies.Append("User", updatedJson);
                        return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
					}
					else if (nd.IdChucVu == cvCustomer.Id)
					{
                        string updatedJson = JsonConvert.SerializeObject(nd);
                        Response.Cookies.Append("User", updatedJson);
                        return RedirectToAction("Index", "CustomerHome", new {area = "Customer"});
					}
					else if (nd.IdChucVu == cvShipper.Id)
					{
                        string updatedJson = JsonConvert.SerializeObject(nd);
                        Response.Cookies.Append("User", updatedJson);
                        return RedirectToAction("Index","ShipperHome",new {area = "Shipper"});
                    }
                    else if (nd.IdChucVu == cvEmployee.Id)
                    {
                        string updatedJson = JsonConvert.SerializeObject(nd);
                        Response.Cookies.Append("User", updatedJson);
                        return RedirectToAction("Index", "EmployeeHome", new { area = "Employee" });
                    }
					else
					{
                        TempData["Login Sai"] = "Bạn đã đăng nhập Sai";
						return View();
                    }
                }
				
			}
		}
        [HttpGet]
        public async Task<IActionResult> Detail(Guid Id)
        {
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            if(lstSp == null)
            {
                return NotFound();
            }
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if (lstSpOk == null)
            {
                return NotFound();
            }
            var laptop = lstSpOk.FirstOrDefault(x => x.Id == Id);
            if (laptop == null)
            {
                return NotFound();
            }
            ViewBag.laptop = laptop;
            return View(laptop);
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
        public IActionResult Logout()
        {
            Response.Cookies.Delete("User");
            return RedirectToAction("Index","Home");
        }
        public IActionResult Checkout()
        {
            return View();
        }


        public async Task<IActionResult> AddToCart(Guid id)
        {
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if (lstSpOk == null)
            {
                return NotFound();
            }
            var laptop = lstSpOk.FirstOrDefault(x => x.Id == id);
            if(laptop == null)
            {
                return NotFound("Sản Phẩm Đã hết hàng");
            }
            string json = Request.Cookies["MyCart"];
            List<GioHangItem> myListCartItem = new List<GioHangItem>();
            if (json != null)
            {
                myListCartItem = JsonConvert.DeserializeObject<List<GioHangItem>>(json);
            }
            GioHangItem item = new GioHangItem();
            item.ID = Guid.NewGuid();
            item.IdSanPham = laptop.Id;
            item.IdGioHang = null;
            item.ItemName = laptop.TenSanPham;
            item.DonGia = laptop.GiaBan;
            item.Image = laptop.Image;
            item.Soluong = 1;
            item.ThanhTien = item.DonGia * item.Soluong;

            myListCartItem.Add(item);

            string updateJson = JsonConvert.SerializeObject(myListCartItem);
            Response.Cookies.Append("MyCart", updateJson);
            return RedirectToAction("MyCart", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> MyCart()
        {
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            if(lstSp == null)
            {
                return NotFound();
            }
            var lstSpOk = lstSp.Where(x => x.TrangThai == 1).ToList();
            if (lstSpOk == null)
            {
                return NotFound();
            }
            ViewBag.lstLapTop = lstSpOk;
            string json = Request.Cookies["MyCart"];
            if(json != null)
            {
                List<GioHangItem> myListCartItem = JsonConvert.DeserializeObject<List<GioHangItem>>(json);
                ViewBag.myListCartItem = myListCartItem;
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}