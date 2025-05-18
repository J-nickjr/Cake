using CakeShop.Data; // �[�J using
using CakeShop.Models; // �[�J using
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // �[�J using
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Linq; // �[�J using
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks; // �[�J using

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public  async  Task<IActionResult> Index()
        {
            var carouselCakes = await _context.Cakes
                                              .Where(c => !string.IsNullOrEmpty(c.ImageUrl))
                                              .OrderBy(c => Guid.NewGuid())
                                              .Take(5)
                                              .ToListAsync();

            return View(carouselCakes);
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
