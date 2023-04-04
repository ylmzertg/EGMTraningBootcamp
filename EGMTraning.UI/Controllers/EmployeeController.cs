using EGMTraning.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            var data = new List<EmployeeList>
            {
                new EmployeeList
                {
                    Name = "Ertug"
                },
                new EmployeeList
                {
                    Name = "Yilmaz"
                }
            };

            var jsonString  = JsonSerializer.Serialize(data);

            return RedirectToAction("Index2", new { name = jsonString });
           //return new JsonResult(Ok(name));
        }

        public IActionResult Index2(string name)
        {

            var data = JsonSerializer.Deserialize<List<EmployeeList>>(name);
            return View(data);
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
