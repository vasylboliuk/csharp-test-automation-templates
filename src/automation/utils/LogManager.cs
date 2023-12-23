using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_automation_dotnet_template.src.automation.utils
{
    internal sealed class LogManager
    {
        private LogManager() { }

        private static LogManager _instance;

        public static LogManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LogManager();
            }
            return _instance;
        }

        public void GetLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .WriteTo.Console(outputTemplate: "[{Level}] {Timestamp:yyyy-MM-dd HH:mm:ss.ms} [{ThreadId}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }

        public int SomeInt() { return 100; }



    }
}
