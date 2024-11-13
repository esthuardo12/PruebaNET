using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNET.BL.Clase
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public LogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger(typeof(LogMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            //Este id es para simular un ID que viene del FrontEnd/Container
            //Con el cual mantenemos "trace" de toda la acción del usuario
            //Antes de la request
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            await _next(context);

            //Despues de la request
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            var log = $"[{DateTime.Now}] : La request {context.Request.Path} - {context.Request.Method} ha llevado {elapsedTime} ";
            _logger.LogDebug(log);
            File.AppendAllText("Logs/requestTime.log", log + Environment.NewLine);
        }
    }
}
