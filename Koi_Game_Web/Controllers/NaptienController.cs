using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class NaptienController : Controller
    {
        private readonly INapTienService _napTienService;
        public NaptienController(INapTienService napTienService)
        {
            _napTienService = napTienService;
        }
        [HttpGet]
        public IActionResult Naptien()
        {
            return View("~/Views/Donate/Naptien.cshtml");
        }
        [HttpPost]
        public IActionResult Naptien(NaptheViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_napTienService.napTien(model.Account, model.Amount, model.SerialNumber))
                {
                    TempData["SuccessMessage"] = "nạp thành công";
                    return RedirectToAction("Naptien");

                }
                ViewBag.ErrorMessage = "nạp tiền thất bại";
            }
            return View("~/Views/Donate/Naptien.cshtml", model);
        }
    }
}
