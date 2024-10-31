using Koi_Game_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Koi_Game_Web.Models; // Đảm bảo NaptheViewModel được định nghĩa ở đây

public class DonateController : Controller
{
    private readonly INapTienService _napTienService;

    public DonateController(INapTienService napTienService)
    {
        _napTienService = napTienService;
    }

    [HttpGet]
    public IActionResult Naptien()
    {
        return View("~/Views/Donate/Naptien.cshtml"); // Trả về view nạp tiền
    }

    [HttpPost]
    public IActionResult Naptien(NaptheViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Logic xử lý nạp tiền
            bool success = _napTienService.napTien(model.Account, model.Amount); // Gọi dịch vụ nạp tiền

            if (success)
            {
                TempData["SuccessMessage"] = "Nạp tiền thành công!";
                return RedirectToAction("Naptien"); // Quay lại trang nạp tiền
            }
            else
            {
                ViewBag.ErrorMessage = "Nạp tiền không thành công. Vui lòng kiểm tra lại.";
            }
        }
        return View("~/Views/Donate/Naptien.cshtml", model); // Trả về trang nạp tiền với thông báo lỗi
    }
}
