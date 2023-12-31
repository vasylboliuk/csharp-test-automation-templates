using fw_webui_selenium_nunit.automation.webui.webdriver.drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace fw_webui_selenium_nunit.automation.webui.webdriver;

public class DriverFactory
{
   private WebDriverImpl driverImpl;

   public WebDriverImpl GetWebDriver(Browser browserType)
   {
      switch (browserType)
      {
         case Browser.CHROME:
            driverImpl = new ChromeDriverImpl();
            break;
         case Browser.FIREFOX:
            driverImpl = new FirefoxDriverImpl();
            break;
      }

      return driverImpl;
   }

}