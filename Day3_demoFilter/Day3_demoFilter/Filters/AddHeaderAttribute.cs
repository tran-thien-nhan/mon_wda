using Microsoft.AspNetCore.Mvc.Filters;

namespace Day3_demoFilter.Filters
{
    public class AddHeaderAttribute : ResultFilterAttribute
    {
        readonly string name;
        readonly string value;

        public AddHeaderAttribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(name, new string[] { value });
            base.OnResultExecuting(context);
        }
    }
}
