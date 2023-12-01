namespace Day4_Security.Middleware
{
    public class AuthenticationMiddle
    {
        private readonly RequestDelegate next;

        public AuthenticationMiddle(RequestDelegate next)
        {
            this.next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            if (path != null && path.Value.StartsWith("/admin"))
            {
                if (context.Session.GetString("username") == null)
                {
                    context.Response.Redirect("/login");
                }
            }
            //nếu không có j thì xử lý tiếp theo như bình thường
            return next(context);
        }
    }
    //tạo exetension method để thêm middleware này vào luồng xử lý của http request
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthenticationMiddle>();
        }
    }
}
