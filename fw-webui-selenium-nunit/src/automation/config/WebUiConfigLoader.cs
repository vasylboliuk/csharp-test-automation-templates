using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.Runtime.CompilerServices;
using fw_webui_selenium_nunit.src.automation.models.configuration;
using fw_webui_selenium_nunit.src.automation.utils;
using fw_webui_selenium_nunit.src.automation.models.configuration;

namespace fw_webui_selenium_nunit.src.automation.config
{
    internal class WebUiConfigLoader
    {

        private static string ENVIRONMENT_PATH = Path.Combine("src", "resources", "environment");

        private static string WEB_UI_CONFIG_FILE = "web_ui_config.json";

        public WebUiConfigDto WebUiConfigDto { get; set; }


        private static readonly Lazy<WebUiConfigLoader> _mySingleton = new Lazy<WebUiConfigLoader>(() => new WebUiConfigLoader());

        private WebUiConfigLoader()
        {
            LoadWebUiProperties();
        }

        public static WebUiConfigLoader Instance => _mySingleton.Value;

        /*public static WebUiConfigLoader ProvideEnvironment()
        {
            Instance.LoadWebUiProperties();
            return Instance;
        }*/

        private void LoadWebUiProperties()
        {
            var environment = String.Empty; // TODO here need to add get ExecutionEnvironment Property
            if (String.IsNullOrEmpty(environment))
            {
                environment = "dev";
            }
            var envName = environment.ToUpper();
            Log.Information("Automation tests run on Environment: [{@envName}]");
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string environmentFile = Path.Combine(projectDirectory, ENVIRONMENT_PATH, environment, WEB_UI_CONFIG_FILE);
            Log.Information("Read environments file from resources: [{@environmentFile}]");
            WebUiConfigDto = DtoConverter.JsonFileToDto<WebUiConfigDto>(environmentFile);
            if (WebUiConfigDto == null)
            {
                throw new ArgumentNullException("Provided invalid Environment Name");
            }
        }

    }
    
}
