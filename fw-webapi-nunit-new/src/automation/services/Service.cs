using fw_webapi_nunit.automation.services.placeholder;

namespace fw_webapi_nunit.automation.services;

public class Service
{
    private Service()
    {
        // default private constructor
    }
    
    public static readonly JsonPlaceholderApi PlaceholderApi = new JsonPlaceholderApi();
    
}