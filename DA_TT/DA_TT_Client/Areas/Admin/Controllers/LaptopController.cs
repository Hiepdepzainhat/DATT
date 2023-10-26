using DA_TT_Share.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DA_TT_Client.Areas.Admin.Controllers
{
    public class LaptopController : Controller
    {
        private readonly HttpClient _httpClient;
        public LaptopController()
        {
            _httpClient = new HttpClient();
        }
        
        public int pageSize = 1;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DanhSachLapTop(string txtSearch,int? page)
        {
            string urlAPI = $"https://localhost:7290/api/SanPham/GetAllSanPham";
            var responSP = await _httpClient.GetAsync(urlAPI);    
            string dataAPI = await responSP.Content.ReadAsStringAsync();
            var lstSp = JsonConvert.DeserializeObject<List<SanPham>>(dataAPI);

            string urlAPIDanhMuc = $"https://localhost:7290/api/DanhMuc/GetAllDanhMuc";
            var responDM = await _httpClient.GetAsync(urlAPIDanhMuc);
            string dataAPIDM = await responDM.Content.ReadAsStringAsync();
            var lstDM = JsonConvert.DeserializeObject<List<DanhMuc>>(dataAPIDM);

            ViewBag.ListDanhMuc = lstDM;

            if (lstSp == null)
            {
                return BadRequest();
            }
            var data = (from s in  lstSp select s);
            if (!string.IsNullOrEmpty(txtSearch))
            {
                ViewBag.txtSearch = txtSearch;
                data = data.Where(s => s.TenSanPham.Contains(txtSearch)).ToList();
            }
            if(page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int start = (int)(page - 1) * pageSize;
            ViewBag.pageCurrent = page;
            int totalPage = data.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.sanPhams = data.OrderByDescending(x => x.Id).Skip(start).Take(pageSize);
            return View();
        }
    }
}
