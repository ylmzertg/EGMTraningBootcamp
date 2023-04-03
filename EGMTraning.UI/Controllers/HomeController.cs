using EGMTraning.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EGMTraning.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Nihal"] = "Ana sayfa";
            ViewBag.Berat="Ertuğrul Yılmaz";
            TempData["EGM Eğitim"]="EGM Eğitim";

            return RedirectToAction("EGMView");

           // return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult EGMView()
        {
            var data = TempData["EGM Eğitim"];
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}