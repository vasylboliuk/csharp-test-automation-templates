using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace fw_webui_selenium_nunit.test.saucedemo.ui;

public class TestDummyHardCodedDriverPathSimpleNavigatePage: BaseNUnitUiTest
{
    private IWebDriver _driver;
    
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver("C:\\ChromeDriver\\chromedriver_win32");
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void TestLoginByValidUser() 
    { 
        // new DriverManager().SetUpDriver(new ChromeConfig());
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/"); 
        _driver.FindElement(By.Id("user-name")).SendKeys("standard_user"); 
        _driver.FindElement(By.Id("password")).SendKeys("secret_sauce"); 
        _driver.FindElement(By.Id("login-button")).Click(); 
        var appLogo = _driver.FindElement(By.ClassName("app_logo")).Text; 
        var productsLable = _driver.FindElement(By.ClassName("header_secondary_container"))
            .FindElement(By.XPath("./span")).Text; 
        // Validation
        Assert.That("Swag Labs", Is.EqualTo(appLogo));
        Assert.That("Products", Is.EqualTo(productsLable));
    }
    
}