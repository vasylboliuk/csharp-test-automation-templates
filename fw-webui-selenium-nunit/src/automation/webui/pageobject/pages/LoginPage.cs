using fw_webui_selenium_nunit.automation.webui.pageobject.common;
using OpenQA.Selenium;

namespace fw_webui_selenium_nunit.automation.webui.pageobject;

public class LoginPage: BasePage
{
    protected string LoginUrl;

    public LoginPage() : base()
    {
        LoginUrl = base.BaseUrl;
    }

    private IWebElement UserNameField() => WebDriver.FindElement(By.Id("user-name"));
    
    private IWebElement UserPasswordField() => WebDriver.FindElement(By.Id("password"));
    
    private IWebElement LoginButton() => WebDriver.FindElement(By.Id("login-button"));

    // Business logic
    public LoginPage Navigate()
    {
        NavigateTo(BaseUrl);
        return this;
    }

    public LoginPage EnterUserName(string userName)
    {
        UserNameField().SendKeys(userName);
        return this;
    }
    
    public LoginPage EnterPassword(string password)
    {
        UserPasswordField().SendKeys(password);
        return this;
    }

    public void LoginToSite(string userName, string password)
    {
        EnterUserName(userName);
        EnterPassword(password);
        LoginButton().Click();
    }


}