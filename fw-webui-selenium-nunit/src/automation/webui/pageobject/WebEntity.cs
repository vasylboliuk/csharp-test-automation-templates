using fw_webui_selenium_nunit.automation.webui.webdriver;
using fw_webui_selenium_nunit.src.automation.config;
using fw_webui_selenium_nunit.src.automation.models.configuration;
using OpenQA.Selenium;

namespace fw_webui_selenium_nunit.automation.webui.pageobject;

public class WebEntity
{
    protected readonly IWebDriver WebDriver;
    protected readonly WebUiConfig WebUiConfig;
    
    protected WebEntity()
    {
        WebDriver = TLDriverFactory.GetWebDriver();
        WebUiConfig = WebUiConfigLoader.Instance.WebUiConfig;
    }

}