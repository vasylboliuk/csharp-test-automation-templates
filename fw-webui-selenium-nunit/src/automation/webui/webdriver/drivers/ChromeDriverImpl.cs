 using AngleSharp;
 using fw_webui_selenium_nunit.src.automation.models.configuration;
 using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace fw_webui_selenium_nunit.automation.webui.webdriver.drivers;

public class ChromeDriverImpl: WebDriverImpl
{
    public ChromeDriverImpl() : base()
    {
    }

    protected override IWebDriver SetupDriver()
    {
        Log.Information("Setup Chrome WebDriver");
        string driverDirPath = new WebDriverManager.DriverManager()
            .SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        driverDirPath = driverDirPath?.Substring(0, driverDirPath.Length - 16); // 16 length for exe name
        var chromeDriverService = ChromeDriverService.CreateDefaultService(driverDirPath);
       
        Log.Information("Setup Chrome WebDriver Options");
        ChromeOptions options = SetupChromeDriverOptions();
        IWebDriver driver = new ChromeDriver(chromeDriverService, options);
        driver = ConfigureTimeouts(driver);
        return driver;
    }

    private ChromeOptions SetupChromeDriverOptions()
    {
        ChromeOptions options = new ChromeOptions();
        options.SetLoggingPreference(LogType.Browser, LogLevel.All);
        options.SetLoggingPreference("performance", LogLevel.All);
        string headlessMode = WebUiConfig.WebDriverConfig.HeadlessMode;
        string windowsSize = WebUiConfig.WebDriverConfig.WindowSize;
        if (headlessMode != "No")
        {
            if (headlessMode == "New")
            {
                options.AddArgument("--headless=new");
                options.AddArgument($"--window-size={windowsSize}");
            }
            options.AddArgument("--headless");
            options.AddArgument($"--window-size={windowsSize}");
        }
        options.PageLoadStrategy = PageLoadStrategy.Eager;
        options.AddArgument("--start-maximized");
        options.AddArgument("--ignore-certificate-errors");
        options.AddArgument("--disable-popup-blocking");
        options.AddArgument("--incognito");
        options.AddUserProfilePreference("disable-popup-blocking", true);
        return options;
    }

    private IWebDriver ConfigureTimeouts(IWebDriver driver)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(15);
        return driver;
    }
   
}