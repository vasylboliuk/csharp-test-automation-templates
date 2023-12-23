using test_automation_dotnet_template.automation.services.common;
using test_automation_dotnet_template.automation.services.placeholder.endpoints;

namespace test_automation_dotnet_template.automation.services.placeholder;

public class JsonPlaceholderApi: AbstractWebService
{
    private const string API_KEY = "placeholderService";
    private RequestSpecification RequestSpecification;

    public JsonPlaceholderApi(): base(API_KEY)
    {
        InitRequestSpecification();
    }
    
    protected void InitRequestSpecification() {
        RequestSpecification = GetDefaultSpecification();
    }

    public ToDoEndpoint ToDoEndpoint()
    {
        return new ToDoEndpoint(RequestSpecification);
    }
}