namespace fw_webui_selenium_nunit.automation.webui.pageobject.common;

public class BasePage: WebEntity
{
    protected readonly string BaseUrl;
    
    protected BasePage() : base()
    {
        BaseUrl = WebUiConfig.BaseURL;
    }

    public void NavigateTo(string url)
    {
        WebDriver.Navigate().GoToUrl(url);
    }

}