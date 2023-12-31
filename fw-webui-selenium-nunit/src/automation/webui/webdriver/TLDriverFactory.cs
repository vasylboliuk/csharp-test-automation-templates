using System.Runtime.CompilerServices;
using fw_webui_selenium_nunit.automation.webui.webdriver.drivers;
using OpenQA.Selenium;

namespace fw_webui_selenium_nunit.automation.webui.webdriver;

public class TLDriverFactory
{
    private static readonly ThreadLocal<IWebDriver> tlDriver = new ThreadLocal<IWebDriver>();
    private static Browser browserType = Browser.CHROME;

    private TLDriverFactory()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static IWebDriver GetWebDriver()
    {
        if (null == tlDriver.Value)
        {
            SetWebDriver(browserType);
            tlDriver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // set implicit wait temporary
        }
        return tlDriver.Value;
    }

    private static void SetWebDriver(Browser browser)
    {
        var manager = new TLDriverFactory();
        var webBrowserImpl = new DriverFactory();
        var webBrowser = webBrowserImpl.GetWebDriver(browser);
        tlDriver.Value = (webBrowser.Create());
    }
    
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void CloseAllDrivers()
    {
        tlDriver.Value.Close();
        tlDriver.Value.Quit();
        tlDriver.Dispose();
    }

}