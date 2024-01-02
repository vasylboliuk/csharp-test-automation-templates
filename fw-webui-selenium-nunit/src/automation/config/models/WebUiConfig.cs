using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fw_webui_selenium_nunit.src.automation.models.configuration
{
    [DataContract]
    public class WebUiConfig
    {
        [DataMember(Name = "BaseURL")]
        public string BaseURL { get; set; }
        
        [DataMember(Name = "WebDriverConfig")]
        public WebDriverConfig WebDriverConfig { get; set; }

    }

    public class WebDriverConfig
    {
        [DataMember(Name = "Browser")]
        public string Browser { get; set; } // Possible Values: Chrome, Firefox
        
        [DataMember(Name = "HeadlessMode")]
        public string HeadlessMode { get; set; } // Possible Values: No, Yes, New
        
        [DataMember(Name = "DefaultImplicitWait")]
        public int DefaultImplicitWait { get; set; }
        
        [DataMember(Name = "DefaultExplicitWait")]
        public int DefaultExplicitWait { get; set; }
        
        [DataMember(Name = "WindowSize")]
        public string WindowSize { get; set; }
        
    }
}
