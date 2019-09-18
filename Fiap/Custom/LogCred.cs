using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Custom
{
    public class LogCred : ILogCred
    {
        public LogCred()
        {

        }
        public void Log(string data)
        {
            var log = new LoggerConfiguration()
           .WriteTo.Logentries("b4960246-4e51-49a0-b613-ca3a17fab79d")
           .CreateLogger();
            log.Information($"request {data}");
        }
    }
}
