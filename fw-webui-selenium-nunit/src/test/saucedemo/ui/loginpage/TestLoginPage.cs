using fw_webui_selenium_nunit.automation.webui.pageobject;
using fw_webui_selenium_nunit.automation.webui.webdriver;

namespace fw_webui_selenium_nunit.test.saucedemo.ui;

public class TestLoginPage: BaseNUnitUiTest
{
   
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
        var appLogoLabel = Pages.ProductsPage.GetAppLogoLabel();
        var productsLabel = Pages.ProductsPage.GetProductsLabel();
        // Validation
        Assert.That("Swag Labs", Is.EqualTo(appLogoLabel));
        Assert.That("Products", Is.EqualTo(productsLabel));
    }
    
}