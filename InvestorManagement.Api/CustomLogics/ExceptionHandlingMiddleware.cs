using System.Net;
using System.Text.Json;

namespace InvestorManagement.Api.CustomLogics
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlingMiddleware> _logger;
		public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context); // Call the next middleware in the pipeline
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An unexpected error occurred.");
				await HandleExceptionAsync(context, ex);
			}
		}
		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var statusCode = HttpStatusCode.InternalServerError; // Default to 500
			var result = JsonSerializer.Serialize(new { error = exception.Message });

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)statusCode;

			return context.Response.WriteAsync(result);
		}
	}
}
