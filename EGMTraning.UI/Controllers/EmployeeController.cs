using EGMTraning.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EGMTraning.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            EmployeeList model = new EmployeeList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(EmployeeList model)
        {
            if (ModelState.IsValid)
            {

            }
            var state = ModelState.ToList();
            return View();
        }
    }
}
