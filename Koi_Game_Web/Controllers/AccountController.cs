using Koi_Game_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Koi_Game_Web.Models; // Thay YourNamespace thành namespace thực tế của bạn

public class AccountController : Controller
{
    private readonly ILoginService _loginService;
    //private readonly IXuLiNhanCaLanDau _xuLiNhanCaLanDau;
    private readonly IGameStatusService _gameStatusService;
    private readonly IPlayerService _playerService;
    public AccountController(ILoginService loginService, IGameStatusService gameStatusService, IPlayerService playerService)
    {
        _loginService = loginService;
        _gameStatusService = gameStatusService;
        _playerService = playerService;
        //_xuLiNhanCaLanDau= xuLiNhanCaLanDau;
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
            if (player != null)
            {
                // su dung session ddeer luu cac ddang nhapj
                HttpContext.Session.SetInt32("playerId", player.PlayerId);
                HttpContext.Session.SetString("username", player.UserName);
                //  HttpContext.Session.SetInt32("coin", (int)(player.Coin ?? 0));
                HttpContext.Session.SetString("name", player.Name);
                return RedirectToAction("Status", "Status"); // Điều hướng đến trang Home/Index khi đăng nhập thành công
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
                return RedirectToAction("Login","Account"); // Điều hướng về trang đăng nhập khi đăng ký thành công
            }
            else
            {
                ViewBag.ErrorMessage = "Đăng ký không thành công. Tài khoản có thể đã tồn tại Hoặc xác nhận mật khẩu không đúng";
            }

            //ViewBag.ErrorMessage = "Xác nhận mật khẩu không khớp.";
        }
        return View("Register", model); // Trả về trang đăng ký với thông báo lỗi
    }

    public IActionResult Logout()
    {
        var idplayer = HttpContext.Session.GetInt32("playerId");
        var pondId = HttpContext.Session.GetInt32("pondId");
        var playerPondId = HttpContext.Session.GetInt32("playerPondId");
        if (idplayer.HasValue)
        {
            _gameStatusService.saveGame(idplayer.Value, pondId.Value, playerPondId.Value);
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        return RedirectToAction("KoiGame", "Game");
    }

    [HttpGet]
    public IActionResult CheckAcc()
    {
        return View("QuenMatKhau");
    }

    [HttpPost]
    public IActionResult CheckAcc(QuenMatKhauViewModel model)
    {
        var player = _loginService.getPlayerByUsername(model.username);
        if (player == null)
        {
            ViewBag.ErrorMessage = "Tài khoản không tồn tại.";
            return View("QuenMatKhau", model);
        }

        return View("NewPassword", model);
    }

    [HttpGet]
    public IActionResult QuenMatKhau()
    {
        return View("NewPassword");
    }
    [HttpPost]
    public IActionResult QuenMatKhau(QuenMatKhauViewModel model)
    {
        Console.WriteLine("cccc");
        if (ModelState.IsValid)
        {
            Console.WriteLine("đâsdasdasd");
            if (_loginService.QuenMatKhau(model.username,model.otp,model.newpass,model.confirmpass))
            {
                return RedirectToAction("Login", "Account"); 
            }
            else
            {
                ViewBag.ErrorMessage = "kiểm tra lại otp hoặc xác nhận mật khẩu";
            }
        }
        return View("NewPassword", model);
    }
}
