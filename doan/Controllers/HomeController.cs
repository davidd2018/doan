using System.Diagnostics;
using doan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using doan.Migrations;

namespace doan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
             ApplicationDbContext context,
            ILogger<HomeController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
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

                return View("Index1");
            }
            else
            {
                ViewBag.UserMessage = " Chưa đăng nhập!";
                return View("Index");
            }
            return View();
        }
        public IActionResult Index1()
        {
            List<Bai01Model> danhSachTuVung = _context.Bai01.ToList(); // Lấy dữ liệu từ DB
            return View(danhSachTuVung); // Truyền danh sách từ vựng vào View
            _logger.LogInformation("Người dùng đã vào trang Chọn Level.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user != null) // User exists in the database
            {
                // Redirect to Index1 if the user is found and login is successful
                var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index1"); // Redirect to Index1 if login is successful
                }
            }
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View("Login");
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Bai01Model model)
        {
            
            if (ModelState.IsValid)
            {
                _context.Bai01.Add(model);  
                _context.SaveChanges();
                // Lưu vào database (giả lập)
                ViewBag.Message = "Dữ liệu đã được lưu thành công!";
               
            }
            //return View(model);
            return RedirectToAction("N5_Bai01");
        }

        public IActionResult N5_Bai02()
        {
            return View();
        }
        public IActionResult N5_Bai03()
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
