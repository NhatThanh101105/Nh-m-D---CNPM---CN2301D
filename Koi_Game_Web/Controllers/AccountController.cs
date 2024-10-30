using Koi_Game_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService; // Sử dụng ILoginService

        public AccountController(ILoginService loginService) // Inject ILoginService
        {
            _loginService = loginService;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View("login");
        }


        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (_loginService.Login(username, password)) // Sử dụng Login từ ILoginService
            {
                
                return RedirectToAction("Index","Home");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }
    }
}
