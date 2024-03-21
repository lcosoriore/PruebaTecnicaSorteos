namespace Sorteo.API.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey;

        public ApiKeyMiddleware(RequestDelegate next, string apiKey)
        {
            _next = next;
            _apiKey = apiKey;
        }

        public async Task Invoke(HttpContext context)
        {
            string extractedApiKey = context.Request.Headers["Api-Key"];
            if (string.IsNullOrEmpty(extractedApiKey) || !extractedApiKey.Equals(_apiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized API Key");
                return;
            }

            await _next(context);
        }
    }
}
