using Microsoft.AspNetCore.Mvc;

namespace EGMTraning.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
