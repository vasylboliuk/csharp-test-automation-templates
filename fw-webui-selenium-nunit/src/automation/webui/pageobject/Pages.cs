namespace fw_webui_selenium_nunit.automation.webui.pageobject;

public class Pages
{
    private Pages()
    {
        // default private constructor
    }

    public static LoginPage LoginPage => new LoginPage();
    public static ProductsPage ProductsPage => new ProductsPage();
    
}