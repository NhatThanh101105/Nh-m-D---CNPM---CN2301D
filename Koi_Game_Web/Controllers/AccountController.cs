public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        if (_userService.Login(username, password))
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = "Invalid username or password.";
        return View();
    }
}
