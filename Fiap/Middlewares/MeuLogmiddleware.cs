using Fiap.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Middlewares
{
    public class MeuLogMiddleware
    {
        private RequestDelegate _next;
        private ILogCred _log;

        public MeuLogMiddleware(RequestDelegate next, ILogCred log)
        {
            _next = next;
            _log = log;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            //logica antes
            httpContext.Request.EnableRewind();

            var request = await FormatRequest(httpContext.Request);
            _log.Log(request);

            httpContext.Request.Body.Position = 0;




            await _next(httpContext);
            //logica depois
        }


        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            var messageObjToLog = new { scheme = request.Scheme, host = request.Host, path = request.Path, queryString = request.Query, requestBody = bodyAsText };

            return JsonConvert.SerializeObject(messageObjToLog);
        }

    }
}
