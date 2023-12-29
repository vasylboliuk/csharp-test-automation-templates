using fw_webapi_nunit.src.automation.models.configuration;
using fw_webapi_nunit.src.automation.config;
using fw_webapi_nunit.src.automation.models.configuration;

namespace fw_webapi_nunit.automation.services.common;

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