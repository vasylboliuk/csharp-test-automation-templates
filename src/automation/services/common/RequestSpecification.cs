using RestSharp;

namespace test_automation_dotnet_template.automation.services.common;

public class RequestSpecification
{
    public string BaseUrl;
    public string BasePath;
    public ConfigureRestClient ConfigureRestClient { get; }
    public ConfigureHeaders ConfigureHeaders { get;  }
    public ConfigureSerialization ConfigureSerialization { get;  }
   
    public RequestSpecification(
        string baseUrl,
        string basePath,
        ConfigureRestClient? configureRestClient = null,
        ConfigureHeaders? configureDefaultHeaders = null,
        ConfigureSerialization? configureSerialization = null
    )
    {
        BaseUrl = baseUrl;
        BasePath = basePath;
        ConfigureRestClient = configureRestClient;
        ConfigureHeaders = configureDefaultHeaders;
        ConfigureSerialization = configureSerialization;
    }

 }