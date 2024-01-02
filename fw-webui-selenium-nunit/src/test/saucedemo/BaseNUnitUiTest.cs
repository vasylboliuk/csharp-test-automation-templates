using fw_webui_selenium_nunit.automation.webui.webdriver;

namespace fw_webui_selenium_nunit.test.saucedemo;

public class BaseNUnitUiTest
{
    private const string Browser = "Chrome";
    
    [SetUp]
    public void Setup()
    {
        TLDriverFactory.GetWebDriver(Browser);
    }
    
    [TearDown]
    public void TearDown()
    {
        TLDriverFactory.CloseAllDrivers();
    }
    
}