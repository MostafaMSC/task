using System.Text;

namespace BookStore
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"dotnet-core\"");
                await context.Response.WriteAsync("Authorization header missing");
                return;
            }

            var authHeader = context.Request.Headers["Authorization"].ToString();
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                var username = decodedUsernamePassword.Split(':')[0];
                var password = decodedUsernamePassword.Split(':')[1];

                if (IsAuthorized(username, password))
                {
                    await _next(context);
                    return;
                }
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"dotnet-core\"");
            await context.Response.WriteAsync("Unauthorized");
        }

        private bool IsAuthorized(string username, string password)
        {
            return username == "admin" && password == "000000";
        }
    }


}
