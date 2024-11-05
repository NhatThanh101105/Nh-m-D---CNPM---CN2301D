using Microsoft.AspNetCore.Mvc;
using Koi_Game_Services.Interfaces; // Nhập không gian tên cho dịch vụ cá
using Koi_Game_Reposities.Entities; // Nhập không gian tên cho thực thể KoiFish
using System.Collections.Generic; // Nhập không gian tên cho List

namespace KoiBreedingGame.Controllers
{
    public class KoiGameController : Controller
    {
        private readonly IKoiService _koiFishService; // Dịch vụ để lấy thông tin cá koi

        // Constructor
        public KoiGameController(IKoiService koiFishService)
        {
            _koiFishService = koiFishService; // Khởi tạo dịch vụ cá koi
        }

        // GET: KoiGame/Index
        public async Task<IActionResult> Index() // Đổi sang async để gọi dịch vụ bất đồng bộ
        {
            List<KoiFish> koiFishes = await _koiFishService.GetAllKoiFishes(); // Lấy danh sách cá từ dịch vụ
            return View(koiFishes); // Truyền danh sách cá vào View
        }
    }
}
