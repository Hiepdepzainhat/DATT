using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DA_TT_Client.Areas.Admin.Controllers
{
    public class DonHangAdminController : Controller
    {
        private readonly HttpClient _httpClient;
        public DonHangAdminController()
        {
            _httpClient = new HttpClient();
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DanhSachDonHang()
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/DonHang/GetAllDonHang";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DonHang>>(dataAPIDM);
            return View(lstDM);
        }
    }
}
