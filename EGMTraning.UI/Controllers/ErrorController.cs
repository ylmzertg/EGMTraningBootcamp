using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace EGMTraning.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int code)
        {
            if (code == 404)
                ViewBag.ErrorMessage ="The request page not found";
            if (code == (int) HttpStatusCode.Unauthorized)
                ViewBag.ErrorMessage ="Yetkisiz Erişim";
            if (code==(int) HttpStatusCode.InternalServerError)
                ViewBag.ErrorMessage ="My custom 500 error message";
            else
                ViewBag.ErrorMessage ="An error occured while processing your request";

            ViewBag.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ViewBag.ShowRequestId = !string.IsNullOrEmpty(ViewBag.RequestId);
            ViewBag.ErrorStatusCode = code;
            return View();
        }
    }
}
