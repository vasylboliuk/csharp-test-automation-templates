using fw_webui_selenium_nunit.automation.webui.webdriver.drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace fw_webui_selenium_nunit.automation.webui.webdriver;

public class DriverFactoryV2
{
    
    private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
    private static IWebDriver driver;

    public static IWebDriver Driver
    {
        get
        {
            if(driver == null)
                throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
            return driver;
        }
        private set
        {
            driver = value;
        }
    }

    public static void InitBrowser(Browser browser)
    {          
        switch (browser)
        {
            case Browser.FIREFOX:
                if (driver == null)
                {
                    driver = new FirefoxDriverImpl().Create();
                    Drivers.Add("Firefox", driver);
                }
                break;
            case Browser.CHROME:
                if (driver == null)
                {
                    driver = new ChromeDriverImpl().Create();
                    Drivers.Add("Chrome", driver);
                }
                break;
        }            
    }

    public static void LoadApplication(string url)
    {
        Driver.Url = url;
    }

    public static void CloseAllDrivers()
    {
        foreach (var key in Drivers.Keys)
        {
            Drivers[key].Close();
            Drivers[key].Quit();
        }
    }
}