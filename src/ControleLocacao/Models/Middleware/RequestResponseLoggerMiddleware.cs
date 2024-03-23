using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System;
using Serilog;

namespace ControleLocacao.Api.Models.Middleware
{
    public class RequestResponseLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly bool _isRequestResponseLoggingEnabled;
        private readonly ILogger<RequestResponseLoggerMiddleware> _logger;

        public RequestResponseLoggerMiddleware(RequestDelegate next, IConfiguration config, ILogger<RequestResponseLoggerMiddleware> logger)
        {
            _next = next;
            // _isRequestResponseLoggingEnabled = config.GetValue<bool>("EnableRequestResponseLogging", false);
            _isRequestResponseLoggingEnabled = true;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // Middleware is enabled only when the EnableRequestResponseLogging config value is set.
            if (_isRequestResponseLoggingEnabled)
            {

                _logger.LogInformation
                (
                    "HTTP REQUEST INFORMATION:\n" +
                    "\tMethod: {RequestMethod} \n" +
                    "\tPath: {Path}\n" +
                    "\tQueryString: {QueryString}\n" +
                    "\tHeaders: {Headers}\n" +
                    "\tSchema: {Scheme}\n" +
                    "\tHost: {Host}\n" +
                    "\tBody: {Body}",
                    httpContext.Request.Method,
                    httpContext.Request.Path,
                    httpContext.Request.QueryString,
                    FormatHeaders(httpContext.Request.Headers),
                    httpContext.Request.Scheme,
                    httpContext.Request.Host,
                    await ReadBodyFromRequest(httpContext.Request)
                );

                // Temporarily replace the HttpResponseStream, which is a write-only stream, with a MemoryStream to capture it's value in-flight.
                var originalResponseBody = httpContext.Response.Body;
                using var newResponseBody = new MemoryStream();
                httpContext.Response.Body = newResponseBody;

                // Call the next middleware in the pipeline
                await _next(httpContext);

                newResponseBody.Seek(0, SeekOrigin.Begin);
                var responseBodyText = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();

                _logger.LogInformation
                (
                    "HTTP RESPONSE INFORMATION:\n" +
                    "\tStatusCode: {StatusCode}\n" +
                    "\tContentType: {ContentType}\n" +
                    "\tHeaders: {Headers}\n" +
                    "\tBody: {Body}",
                    httpContext.Response.StatusCode,
                    httpContext.Response.ContentType,
                    FormatHeaders(httpContext.Response.Headers),
                    responseBodyText
                );

                newResponseBody.Seek(0, SeekOrigin.Begin);
                await newResponseBody.CopyToAsync(originalResponseBody);
            }
            else
            {
                await _next(httpContext);
            }
        }

        private static string FormatHeaders(IHeaderDictionary headers) => string.Join(", ", headers.Select(kvp => $"{{{kvp.Key}: {string.Join(", ", kvp.Value)}}}"));

        private static async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            // Ensure the request's body can be read multiple times (for the next middlewares in the pipeline).
            request.EnableBuffering();

            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();

            // Reset the request's body stream position for next middleware in the pipeline.
            request.Body.Position = 0;
            return requestBody;
        }
    }
}