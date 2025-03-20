using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using doan.Models;  // 

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Hiển thị danh sách từ vựng
    public IActionResult N5_Bai01()
    {
        var tuVungList = _context.Bai01.ToList();
        return View(tuVungList);
    }

    // Hiển thị form tạo từ vựng
    public IActionResult Create()
    {
        return View();
    }

    // Xử lý khi submit form tạo từ vựng
    [HttpPost]
    public IActionResult Create(Bai01Model model)
    {
        if (ModelState.IsValid)
        {
            _context.Bai01.Add(model);
            _context.SaveChanges();
            return RedirectToAction("N5_Bai01");
        }
        return View(model);
    }
}
