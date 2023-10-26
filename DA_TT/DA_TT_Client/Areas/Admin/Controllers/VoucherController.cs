using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Printing;

namespace DA_TT_Client.Areas.Admin.Controllers
{
    public class VoucherController : Controller
    {
        private readonly HttpClient _httpClient;
        public VoucherController()
        {
            _httpClient = new HttpClient();
        }
        public int pageSize = 6;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DanhSachVoucher()
        {
            string urlAPIDanhMuc = $"https://localhost:7290/api/Voucher/GetAllVoucher";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<Voucher>>(dataAPIDM);

            
            return View(lstDM);
        }
    }
}
