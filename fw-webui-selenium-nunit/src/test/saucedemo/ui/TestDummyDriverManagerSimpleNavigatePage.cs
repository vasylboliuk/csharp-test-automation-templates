using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace fw_webui_selenium_nunit.test.saucedemo.ui;

public class TestSimpleNavigatePage: BaseNUnitUiTest
{
    private IWebDriver _driver;
    
    [SetUp]
    public void Setup()
    {
        string driverDirPath = new WebDriverManager.DriverManager()
            .SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        Console.WriteLine(driverDirPath);
        driverDirPath = driverDirPath?.Substring(0, driverDirPath.Length - 16); // 16 length for exe name
        Console.WriteLine(driverDirPath);
        var chromeDriverService = ChromeDriverService.CreateDefaultService(driverDirPath);
        _driver = new ChromeDriver(chromeDriverService);
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void TestDriverManagerLoginByValidUser() 
    { 
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