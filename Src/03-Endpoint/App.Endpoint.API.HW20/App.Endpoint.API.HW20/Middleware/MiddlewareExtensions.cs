using Microsoft.AspNetCore.Builder;

namespace App.Endpoints.API.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
