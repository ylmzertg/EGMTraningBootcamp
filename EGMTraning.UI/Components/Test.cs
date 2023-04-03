using EGMTraning.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EGMTraning.UI.Components
{
    //[ViewComponent]
    public class Test :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var emp = new List<EmployeeList>
            {
                new EmployeeList
                {
                    Id=1,
                    Name="Jeff"
                },
                new EmployeeList
                {
                    Id=2,
                    Name="Bill"
                }
            };
            return View(emp);
        }
    }
}
