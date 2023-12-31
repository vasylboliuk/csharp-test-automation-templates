using RestSharp;

namespace fw_webapi_nunit.automation.services.common;

public class AbstractWebEndpoint
{
    protected string BaseUrl;
    
    public AbstractWebEndpoint(string baseUrl) {
        BaseUrl = baseUrl;
    }
    
    public RestResponse Get(string path)
    {
        var client = new RestClient(BaseUrl);
        var request = new RestRequest(path);
        var response = client.ExecuteGet(request);
        return response;
    }
    
    public RestResponse Post(string path)
    {
        throw new NotImplementedException();
    }
    
    public RestResponse Put(string path)
    {
        throw new NotImplementedException();
    }
    
    public RestResponse Delete(string path)
    {
        throw new NotImplementedException();
    }
    
    
}