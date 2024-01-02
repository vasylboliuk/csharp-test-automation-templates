using fw_webui_selenium_nunit.automation.webui.webdriver.drivers;
using fw_webui_selenium_nunit.src.automation.config;
using fw_webui_selenium_nunit.src.automation.models.configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace fw_webui_selenium_nunit.automation.webui.webdriver;

public class DriverFactory
{
   private WebDriverImpl driverImpl;

   /*
    * Get Web Driver
    */
   public WebDriverImpl GetWebDriver(string browserType)
   {
      switch (browserType.ToUpper())
      {
         case "CHROME":
            driverImpl = new ChromeDriverImpl();
            break;
         case "FIREFOX":
            driverImpl = new FirefoxDriverImpl();
            break;
      }

      return driverImpl;
   }

}