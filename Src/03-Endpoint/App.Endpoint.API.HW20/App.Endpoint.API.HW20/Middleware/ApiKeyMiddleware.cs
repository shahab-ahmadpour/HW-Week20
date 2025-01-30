using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace App.Endpoints.API.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _apiKey = configuration["AppSettings:ApiKey"];
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString();

            if (path.StartsWith("/api", System.StringComparison.OrdinalIgnoreCase))
            {
                if (!context.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey) || string.IsNullOrEmpty(extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Access Denied: ApiKey is required");
                    return;
                }

                if (extractedApiKey != _apiKey)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Access Denied: Invalid ApiKey");
                    return;
                }
            }

            await _next(context);
        }
    }
}
