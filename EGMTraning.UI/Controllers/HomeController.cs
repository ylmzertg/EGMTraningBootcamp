﻿using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.UI.ActionFilters;
using EGMTraning.UI.Helpers;
using EGMTraning.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;

namespace EGMTraning.UI.Controllers
{
    //[Authorize]
    // [Route("[controller]")]
    //  [MySampleActionFilterAttribute]
    //[ExceptionlogFilter]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILanguageBusinessEngine languageService, IStringResourceBusinessEngine stringResourceBusinessEngine) : base(languageService, stringResourceBusinessEngine)
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

        //public IActionResult Index([Bind(nameof(EmployeeList.Name))] EmployeeList emp)
        //{
        //    //ViewData["Nihal"] = "Ana sayfa";
        //    //ViewBag.Berat="Ertuğrul Yılmaz";
        //    //TempData["EGM Eğitim"]="EGM Eğitim";
        //    //int a = 5;
        //    //int b = 0;
        //    //int c = a/b;
        //    // return RedirectToAction("EGMView");

        //    return View();
        //}

        public IActionResult Index(int? id = null)
        {
            #region Traning_1
            //HttpContext.Session.SetString("sessionKey", "Egm Traning");
            //HttpContext.Session.SetInt32("sessionIntValue", 10);

            //var data1 = HttpContext.Session.GetString("sessionKey");
            //var data2 = HttpContext.Session.GetInt32("sessionIntValue");

            //if (id.HasValue)
            //{
            //    if (id==1)
            //        throw new FileNotFoundException("File not found Exception thrown in index");
            //    if (id==2)
            //        return StatusCode(500);
            //    if (id==3)
            //        return StatusCode(401);
            //} 
            #endregion

            //ViewData["titleChangedLanguage"] =LangHelper.Localize("Hello");
              ViewData["titleChangedLanguage"] =Localize("Hello");

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

        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Security()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"]=returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            if (username=="Ertuğ" && password=="12345")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, "Nihal Ateş"));
                //claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(claimPrincipal);
                return Redirect(returnUrl);
            }
            return BadRequest();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
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

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1)
                });
            return LocalRedirect(returnUrl);
        }
    }
}