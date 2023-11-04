using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DA_TT_Client.Areas.Admin.Controllers
{
    public class LaptopController : Controller
    {
        private readonly HttpClient _httpClient;
        public LaptopController()
        {
            _httpClient = new HttpClient();
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DanhSachLapTop()
        {
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);    
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);

            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);

            ViewBag.ListDM = lstDM;

            string urlAPIHang = $"https://localhost:7290/api/HangSanXuat/GetAllHangSX";
            var responHang = await _httpClient.GetAsync(urlAPIHang);
            string dataAPIHang = await responHang.Content.ReadAsStringAsync();
            var lstHang = JsonConvert.DeserializeObject<List<HangSanXuat>>(dataAPIHang);
            ViewBag.ListHang = lstHang;

            string urlAPICoupon = $"https://localhost:7290/api/Coupon/GetAllCoupon";
            var responCoupon = await _httpClient.GetAsync(urlAPICoupon);
            string dataAPICoupon = await responCoupon.Content.ReadAsStringAsync();
            var lstcoupon = JsonConvert.DeserializeObject<List<Coupon>>(dataAPICoupon);

            ViewBag.ListCoupon = lstcoupon;

            if (lstSp == null)
            {
                return BadRequest();
            }
            ViewBag.ListSP = lstSp;
            
            return View(lstSp);
        }
        public async Task<IActionResult> CreateLapTop()
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);

            ViewBag.ListDM = lstDM;

            string urlAPIHang = $"https://localhost:7290/api/HangSanXuat/GetAllHangSX";
            var responHang = await _httpClient.GetAsync(urlAPIHang);
            string dataAPIHang = await responHang.Content.ReadAsStringAsync();
            var lstHang = JsonConvert.DeserializeObject<List<HangSanXuat>>(dataAPIHang);
            ViewBag.ListHang = lstHang;

            string urlAPICoupon = $"https://localhost:7290/api/Coupon/GetAllCoupon";
            var responCoupon = await _httpClient.GetAsync(urlAPICoupon);
            string dataAPICoupon = await responCoupon.Content.ReadAsStringAsync();
            var lstcoupon = JsonConvert.DeserializeObject<List<Coupon>>(dataAPICoupon);
            ViewBag.ListCoupon = lstcoupon;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLapTop(SanPham sp,IFormFile imageFile)
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);

            ViewBag.ListDM = lstDM;

            string urlAPIHang = $"https://localhost:7290/api/HangSanXuat/GetAllHangSX";
            var responHang = await _httpClient.GetAsync(urlAPIHang);
            string dataAPIHang = await responHang.Content.ReadAsStringAsync();
            var lstHang = JsonConvert.DeserializeObject<List<HangSanXuat>>(dataAPIHang);
            ViewBag.ListHang = lstHang;

            string urlAPICoupon = $"https://localhost:7290/api/Coupon/GetAllCoupon";
            var responCoupon = await _httpClient.GetAsync(urlAPICoupon);
            string dataAPICoupon = await responCoupon.Content.ReadAsStringAsync();
            var lstcoupon = JsonConvert.DeserializeObject<List<Coupon>>(dataAPICoupon);
            ViewBag.ListCoupon = lstcoupon;
            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photoLapTops", imageFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                imageFile.CopyTo(stream);
                sp.Image = imageFile.FileName;
            }
            string urlAPI = $"https://localhost:7290/api/SanPham/CreateSanPham?IdDanhMuc={sp.IdDanhMuc}&IdHangSX={sp.IdHangSX}&IdCoupon={sp.IdCoupon}&tenSanPham={sp.TenSanPham}&image={sp.Image}&CPU={sp.CPU}&giaNhap={sp.GiaNhap}&giaBan={sp.GiaBan}&dungLuongPin={sp.DungLuongPin}&HeDieuHanh={sp.HeDieuHanh}&manHinh={sp.ManHinh}&ram={sp.Ram}&tongSoLuong={sp.TongSoLuong}&soLuongDaBan={sp.SoLuongDaBan}&thongTinBH={sp.ThongTinBaoHanh}";
            var content = new StringContent(JsonConvert.SerializeObject(sp), Encoding.UTF8, "application/json");
            var respon = await _httpClient.PostAsync(urlAPI, content);
            if (!respon.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return RedirectToAction("DanhSachLapTop", "LapTop", new { area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateLapTop(Guid id)
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);

            ViewBag.ListDM = lstDM;

            string urlAPIHang = $"https://localhost:7290/api/HangSanXuat/GetAllHangSX";
            var responHang = await _httpClient.GetAsync(urlAPIHang);
            string dataAPIHang = await responHang.Content.ReadAsStringAsync();
            var lstHang = JsonConvert.DeserializeObject<List<HangSanXuat>>(dataAPIHang);
            ViewBag.ListHang = lstHang;

            string urlAPICoupon = $"https://localhost:7290/api/Coupon/GetAllCoupon";
            var responCoupon = await _httpClient.GetAsync(urlAPICoupon);
            string dataAPICoupon = await responCoupon.Content.ReadAsStringAsync();
            var lstcoupon = JsonConvert.DeserializeObject<List<Coupon>>(dataAPICoupon);
            ViewBag.ListCoupon = lstcoupon;
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);
            var sp = lstSp.FirstOrDefault(x => x.Id == id);
            if (sp == null)
            {
                return NotFound();
            }
            return View(sp);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLapTop(Guid id,SanPham sp)
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);

            ViewBag.ListDM = lstDM;

            string urlAPIHang = $"https://localhost:7290/api/HangSanXuat/GetAllHangSX";
            var responHang = await _httpClient.GetAsync(urlAPIHang);
            string dataAPIHang = await responHang.Content.ReadAsStringAsync();
            var lstHang = JsonConvert.DeserializeObject<List<HangSanXuat>>(dataAPIHang);
            ViewBag.ListHang = lstHang;

            string urlAPICoupon = $"https://localhost:7290/api/Coupon/GetAllCoupon";
            var responCoupon = await _httpClient.GetAsync(urlAPICoupon);
            string dataAPICoupon = await responCoupon.Content.ReadAsStringAsync();
            var lstcoupon = JsonConvert.DeserializeObject<List<Coupon>>(dataAPICoupon);
            ViewBag.ListCoupon = lstcoupon;
            string urlAPI = $"https://localhost:7290/api/SanPham/UpdateSanPham/{id}";
            var content = new StringContent(JsonConvert.SerializeObject(sp), Encoding.UTF8, "application/json");
            var respon = await _httpClient.PutAsync(urlAPI, content);
            if (!respon.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return RedirectToAction("DanhSachLapTop", "LapTop", new { area = "Admin" });
        }

    }
}
