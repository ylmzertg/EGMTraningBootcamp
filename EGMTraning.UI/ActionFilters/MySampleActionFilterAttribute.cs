using Microsoft.AspNetCore.Mvc.Filters;

namespace EGMTraning.UI.ActionFilters
{
    public class MySampleActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly string _name;

        public MySampleActionFilterAttribute(string name)
        {
            _name=name;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"OnActionExecuting Filter Attribute {_name}");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"OnActionExecuting Filter Attribute  {_name}");
        }


    }
}
