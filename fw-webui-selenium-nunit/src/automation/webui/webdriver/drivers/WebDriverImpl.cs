using fw_webui_selenium_nunit.src.automation.config;
using fw_webui_selenium_nunit.src.automation.models.configuration;
using OpenQA.Selenium;

namespace fw_webui_selenium_nunit.automation.webui.webdriver.drivers;

public abstract class WebDriverImpl
{
       protected WebUiConfig _webUiConfig;

       protected WebDriverImpl()
       {
       }

       public IWebDriver Create()
       {
              if (_webUiConfig == null)
              {
                     _webUiConfig = WebUiConfigLoader.Instance.WebUiConfig;
              }
              return SetupDriver();
       }

       protected abstract IWebDriver SetupDriver();

       
}