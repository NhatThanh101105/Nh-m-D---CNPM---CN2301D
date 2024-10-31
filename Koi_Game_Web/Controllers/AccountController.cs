﻿using Koi_Game_Services.Interfaces;
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
            if (_loginService.Login(model.Username, model.Password))
            {
                return RedirectToAction("Privacy", "Home"); // Điều hướng đến trang Home/Index khi đăng nhập thành công
            }
            ViewBag.ErrorMessage = "Tên người dùng hoặc mật khẩu không đúng.";
        }
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
            if (_loginService.Register(model.Username, model.Password, model.Name, model.ConfirmPassword))
            {
                return RedirectToAction("Login", "Account"); // Điều hướng về trang đăng nhập khi đăng ký thành công
            }
            else
            {
                ViewBag.ErrorMessage = "Đăng ký không thành công. Tài khoản có thể đã tồn tại.";
            }
        }
        return View("Register", model); // Trả về trang đăng ký với thông báo lỗi
    }

    // Thêm action mới để chuyển đến trang Nạp tiền
    [HttpGet]
    public IActionResult Donate()
    {
        return View("Naptien"); // Trả về view nạp tiền
    }
}
