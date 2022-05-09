using BookManagment.Application.Interfaces.Context;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;


namespace BookManagment.Application.Common.Logging
{
    public  class RequestResponseLogging
    {
        private readonly RequestDelegate _next;

        public RequestResponseLogging(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,IBookDBContext _db)
        {
            var request = await FormatRequest(context.Request);

            var BodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                var startDate = DateTime.Now;  
                await _next(context);
                var endDate = DateTime.Now;
           
                var response = await FormatResponse(context.Response);
                _db.RequestResponseLogs.Add(new Domain.Log.RequestResponseLog
                {
                    Start = startDate.ToString(),
                    End = endDate.ToString(),
                    EventType = context.Request.Path.Value,
                    Ip = context.Connection.RemoteIpAddress.ToString(),
                    RequestInfo = request,
                    ResponseInfo = response,
                    UserId="1"
                });
                await _db.SaveChangesAsync();
                await responseBody.CopyToAsync(BodyStream);
            }

        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return $"{response.StatusCode}: {text}";
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            //request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer,0,buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;
            return $"{request.Scheme}{request.Host}{request.Path}{request.Query} {bodyAsText}";
        }
    }
}
