using fw_webapi_nunit.automation.services.common;
using fw_webapi_nunit.automation.services.placeholder.endpoints;

namespace fw_webapi_nunit.automation.services.placeholder;

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