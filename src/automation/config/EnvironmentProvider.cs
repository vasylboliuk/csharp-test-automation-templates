using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using test_automation_dotnet_template.src.automation.utils;
using test_automation_dotnet_template.src.automation.models.configuration;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.Runtime.CompilerServices;

namespace test_automation_dotnet_template.src.automation.config
{
    internal class EnvironmentProvider
    {

        private static string ENVIRONMENT_PATH = "src\\resources\\environment";

        private static string ENVIRONMENT_FILE = "web_service_config.json";

        private Dictionary<String, EnvironmentConfigDto> ServiceSetting;


        private static readonly Lazy<EnvironmentProvider> _mySingleton = new Lazy<EnvironmentProvider>(() => new EnvironmentProvider());

        private EnvironmentProvider()
        {
            LoadEnvironmentProperties();
        }

        public static EnvironmentProvider Instance => _mySingleton.Value;

        public static EnvironmentProvider ProvideEnvironment()
        {
            Instance.LoadEnvironmentProperties();
            return Instance;
        }

        private void LoadEnvironmentProperties()
        {
            var environment = String.Empty; // here need to add get ExecutionEnvironment Property
            if (String.IsNullOrEmpty(environment))
            {
                environment = "dev";
            }
            var envName = environment.ToUpper();
            Log.Information("Automation tests run on Environment: [{@envName}]");
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string environmentFile = $"{projectDirectory}\\{ENVIRONMENT_PATH}\\{environment}\\{ENVIRONMENT_FILE}";
            Log.Information("Read environments file from resources: [{@environmentFile}]");
            ServiceSetting = DtoConverter.JsonFileToDto<Dictionary<String, EnvironmentConfigDto>>(environmentFile);
            if (ServiceSetting == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static EnvironmentConfigDto GetSettings(string settingName)
        {
            return Instance.ServiceSetting[settingName];
        }


        /*        private string GetExecutionEnvironmentProp()
                {
                    var configurationLocation = Assembly.GetEntryAssembly()
                .GetCustomAttribute<ConfigurationLocationAttribute>()
                .ConfigurationLocation;
                    Console.WriteLine($"Should get config from {configurationLocation}");
                }*/







    }
}
