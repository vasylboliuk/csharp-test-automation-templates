using fw_webui_selenium_nunit.automation.webui.pageobject.common;
using OpenQA.Selenium;

namespace fw_webui_selenium_nunit.automation.webui.pageobject;

public class ProductsPage: BasePage
{
    
    private IWebElement AppLogoLabel() => WebDriver.FindElement(By.ClassName("app_logo"));

    private IWebElement ProductsLabel() => WebDriver.FindElement(By.ClassName("header_secondary_container"))
        .FindElement(By.XPath("./span"));

    public string GetAppLogoLabel() => AppLogoLabel().Text;
    
    public string GetProductsLabel() => ProductsLabel().Text;

}