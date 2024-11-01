using Koi_Game_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Koi_Game_Web.Models; // Thay YourNamespace thành namespace thực tế của bạn

public class AccountController : Controller
{
    private readonly ILoginService _loginService;

    public AccountController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var player = _loginService.Login(model.Username, model.Password);
            if (player!=null)
            {
                HttpContext.Session.SetInt32("playerId", player.PlayerId);
                HttpContext.Session.SetString("userName", player.UserName);
              //  HttpContext.Session.SetInt32("coin", (int)(player.Coin ?? 0));
                HttpContext.Session.SetString("name", player.Name);


                return RedirectToAction("Index","Home"); // Điều hướng đến trang Home/Index khi đăng nhập thành công
            }
            //ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không đúng.");
            ViewBag.ErrorMessage = "Tên người dùng hoặc mật khẩu không đúng.";
        }
        //    ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không đúng.");
        return View("Login", model); // Trả về trang đăng nhập khi đăng nhập không thành công
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View("Register");
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {

            // var isRegistered = _loginService.Register(model.Username, model.Password, model.Name, model.ConfirmPassword);
            if (_loginService.Register(model.Username, model.Password, model.Name, model.ConfirmPassword))
            {
                return RedirectToAction("~/Views/Account/Login.cshtml"); // Điều hướng về trang đăng nhập khi đăng ký thành công
            }
            else
            {
                ViewBag.ErrorMessage = "Đăng ký không thành công. Tài khoản có thể đã tồn tại Hoặc xác nhận mật khẩu không đúng";
            }

            //ViewBag.ErrorMessage = "Xác nhận mật khẩu không khớp.";
        }
        return View("Register", model); // Trả về trang đăng ký với thông báo lỗi
    }
}
