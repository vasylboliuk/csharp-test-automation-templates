using test_automation_dotnet_template.src.automation.config;
using test_automation_dotnet_template.src.automation.models.configuration;

namespace test_automation_dotnet_template.automation.services.common;

public class AbstractWebService
{
    protected EnvironmentConfigDto ApiConfig;
    protected RequestSpecification RequestSpecification;

    protected AbstractWebService(string apiSetting)
    {
        LoadApiConfig(apiSetting);
    }

    private void LoadApiConfig(string apiSetting)
    {
        ApiConfig = EnvironmentProvider.GetSettings(apiSetting);
    }

    protected RequestSpecification GetDefaultSpecification()
    {
        RequestSpecification = new RequestSpecification(
            ApiConfig.ApiUrl,
            ApiConfig.ApiBasePath
        );
        return RequestSpecification;
    }
}