using Microsoft.AspNetCore.Mvc.Filters;

namespace Day3_demoFilter.Filters
{
    public class exampleFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("--- " + context.ActionDescriptor.DisplayName + " is run");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("--- " + context.ActionDescriptor.DisplayName + " is running");
        }
    }
}
