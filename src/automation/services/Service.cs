using test_automation_dotnet_template.automation.services.placeholder;

namespace test_automation_dotnet_template.automation.services;

public class Service
{
    private Service()
    {
        // default private constructor
    }
    
    public static readonly JsonPlaceholderApi PlaceholderApi = new JsonPlaceholderApi();
    
}