using fw_webui_selenium_nunit.automation.webui.pageobject;
using fw_webui_selenium_nunit.automation.webui.webdriver;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace fw_webui_selenium_nunit.test.saucedemo.ui;

public class TestLoginPage: BaseNUnitUiTest
{
   
    [SetUp]
    public void Setup()
    {
    }
    
    [TearDown]
    public void TearDown()
    {
        TLDriverFactory.CloseAllDrivers();
    }
    
    [Test]
    public void TestLoginByValidUser() 
    { 
        Pages.LoginPage
            .Navigate()
            .LoginToSite("standard_user", "secret_sauce");
        var appLogo = TLDriverFactory.GetWebDriver().FindElement(By.ClassName("app_logo")).Text;
        var productsLable = TLDriverFactory.GetWebDriver()
            .FindElement(By.ClassName("header_secondary_container"))
            .FindElement(By.XPath("./span")).Text; 
        // Validation
        Assert.That("Swag Labs", Is.EqualTo(appLogo));
        Assert.That("Products", Is.EqualTo(productsLable));
    }
    
}