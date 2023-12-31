namespace fw_webui_selenium_nunit.automation.webui.pageobject.common;

public class BasePage: WebEntity
{
    protected string BaseUrl = "https://www.saucedemo.com/";
    
    protected BasePage() : base()
    {
    }

    public void NavigateTo(string url)
    {
        WebDriver.Navigate().GoToUrl(url);
    }

}