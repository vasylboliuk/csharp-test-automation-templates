using fw_webui_selenium_nunit.src.automation.config;
using fw_webui_selenium_nunit.src.automation.models.configuration;
using OpenQA.Selenium;

namespace fw_webui_selenium_nunit.automation.webui.webdriver.drivers;

public abstract class WebDriverImpl
{
       protected readonly WebUiConfig WebUiConfig;

       protected WebDriverImpl()
       {
              WebUiConfig = WebUiConfigLoader.Instance.WebUiConfig;
       }

       public IWebDriver Create()
       {
              return SetupDriver();
       }

       protected abstract IWebDriver SetupDriver();

       protected WebUiConfig GetWebUiConfig() => WebUiConfig;
       
       protected WebDriverConfig GetWebUiDriverConfig() => WebUiConfig.WebDriverConfig;


}