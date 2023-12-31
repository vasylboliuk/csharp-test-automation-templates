using fw_webui_selenium_nunit.src.automation.config;
using fw_webui_selenium_nunit.src.automation.models.configuration;
using OpenQA.Selenium;

namespace fw_webui_selenium_nunit.automation.webui.webdriver.drivers;

public abstract class WebDriverImpl
{
       protected WebUiConfigDto _webUiConfigDto;

       protected WebDriverImpl()
       {
       }

       public IWebDriver Create()
       {
              if (_webUiConfigDto == null)
              {
                     _webUiConfigDto = WebUiConfigLoader.Instance.WebUiConfigDto;
              }
              return SetupDriver();
       }

       protected abstract IWebDriver SetupDriver();

       
}