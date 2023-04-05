using EGMTraning.UI.ActionFilters;
using EGMTraning.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace EGMTraning.UI.Controllers
{
    //[Authorize]
    // [Route("[controller]")]
  //  [MySampleActionFilterAttribute]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*
      1. ViewResult: HTML ve Markup sunar 
      2. EmptyResult: Sunumu sonlandırır.
      3. RedirectResult: Sunulan linki yeni bir adrese yönlendirmeye yarar
      4. JsonResult: Java Script Object ‘leri Ajax ile birlikte kullanılabilir bir duruma getirir.
      5. JavaScriptResult: Java Script leri sayfada kullanılabilir biçimde sunar.
      6. ContentResult: Metin içeriği sunar.
      7. FileContentResult: İndirilebilir dosyaları sunar (Binary içerik ile).
      8. FilePathResult: İndirilebilir dosyaları sunar (Dosya yolu ile).
      9. FileStreamResult: İndirilebilir dosyaları sunar (Stream dosyalar için).
       */

        [HttpGet]

        //  [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //  [ProducesResponseType(typeof(EmployeeList), (int)HttpStatusCode.OK)]
        //[Route("/home/[actionName]/{value :int}")]
        public IActionResult Index2()
        {
            //if (true)
            //    return Json(new object());
            //else if (true)
            //    return Content("");
            return View();
        }

        public ViewResult GetTestValues()
        {
            return View();
        }


        public PartialViewResult GetPartialTestValues()
        {
            PartialViewResult result = PartialView();
            return result;
        }

        public JsonResult GetJsonTestValues()
        {
            JsonResult result = Json(new EmployeeList
            {
                Name= "Ertuğ",
                Surname ="Yılmaz"
            });

            return result;
        }

        public IActionResult Index([Bind(nameof(EmployeeList.Name))] EmployeeList emp)
        {
            ViewData["Nihal"] = "Ana sayfa";
            ViewBag.Berat="Ertuğrul Yılmaz";
            TempData["EGM Eğitim"]="EGM Eğitim";
            //int a = 5;
            //int b = 0;
            //int c = a/b;
            // return RedirectToAction("EGMView");

            return View();
        }

       
        [HttpGet]
        [MySampleActionFilterAttribute("Home Controller / Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Privacy(EmployeeList model)
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Privacy([Bind(nameof(EmployeeList.Name))] EmployeeList model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    var state = ModelState.ToList();
        //    return View();
        //}

        public IActionResult EGMView()
        {
            var data = TempData["EGM Eğitim"];
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(EmployeeList model)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}