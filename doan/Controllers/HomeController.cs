using System.Diagnostics;
using doan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User)) // Kiểm tra nếu đã đăng nhập
            {
                var user = await _userManager.GetUserAsync(User);
                ViewBag.UserMessage = " Đã đăng nhập với tài khoản: " + (user?.UserName ?? "Không xác định");
            }
            else
            {
                ViewBag.UserMessage = " Chưa đăng nhập!";
            }

            return View();
        }

        public IActionResult ChonLevel()
        {
            _logger.LogInformation("Người dùng đã vào trang Chọn Level.");
            return View();
        }

        public IActionResult MiniTest()
        {
            _logger.LogInformation("Người dùng đã vào trang Mini Test.");
            return View();
        }

        public IActionResult N5_Bai01()
        {
            return View();
        }

        public IActionResult N5_Bai02()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
