using Microsoft.AspNetCore.Mvc.Filters;

namespace EGMTraning.UI.ActionFilters
{
    public class MySampleFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted");
        }

       
    }
}
