using EGMTraning.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EGMTraning.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(string name)
        {           
            return View();
        }

        [HttpGet]
        public JsonResult GetNames()
        {
            var names = new string[3]
            {
                "Ertuğ",
                "Kürşat",
                "Nihal"
            };
            return new JsonResult(Ok(names));
        }

        public IActionResult PostName(string name)
        {
            return RedirectToAction("Index2", new { name = name  });
           //return new JsonResult(Ok(name));
        }

        public IActionResult Index2(string name)
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(EmployeeList model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    var state = ModelState.ToList();
        //    return View();
        //}
    }
}
