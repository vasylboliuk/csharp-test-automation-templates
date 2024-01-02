using System.Runtime.CompilerServices;
using fw_webui_selenium_nunit.automation.webui.webdriver.drivers;
using OpenQA.Selenium;

namespace fw_webui_selenium_nunit.automation.webui.webdriver;

public class TLDriverFactory
{
    private static readonly ThreadLocal<IWebDriver> tlDriver = new ThreadLocal<IWebDriver>();

    private TLDriverFactory()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static IWebDriver GetWebDriver()
    {
        if (null == tlDriver.Value)
        {
            throw new ArgumentException("Browser Driver is not initialized. Please setup WebDriver");
        }
        return tlDriver.Value;
    }
    
    public static IWebDriver GetWebDriver(string browserType)
    {
        if (null == tlDriver.Value)
        {
            SetWebDriver(browserType);
        }
        return tlDriver.Value;
    }

    private static void SetWebDriver(string browserType)
    {
        var manager = new TLDriverFactory();
        var factory = new DriverFactory();
        var webBrowser = factory.GetWebDriver(browserType);
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