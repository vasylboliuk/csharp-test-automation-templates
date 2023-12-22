using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using test_automation_dotnet_template.src.automation.utils;

namespace test_automation_dotnet_template.src.automation.config
{
    internal class EnvironmentProvider
    {
        //public Log.Logger = new LoggManager().SomeInt();

        private static string ENVIRONMENT_PATH = "/environment/%s/%s";

        private static string ENVIRONMENT_FILE = "web_service_config.json";


        private EnvironmentProvider() 
        {

        }


        

    }
}
