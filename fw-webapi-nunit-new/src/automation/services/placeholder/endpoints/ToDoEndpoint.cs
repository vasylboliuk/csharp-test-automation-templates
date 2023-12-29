using fw_webapi_nunit.automation.services.common;
using fw_webapi_nunit.src.automation.models.configuration;
using fw_webapi_nunit.src.automation.utils;
using fw_webapi_nunit.src.automation.utils;


namespace fw_webapi_nunit.automation.services.placeholder.endpoints;

public class ToDoEndpoint: AbstractWebEndpoint
{
    private const string COMMENTDS_END = "/comments";
    private const string COMMENTS_RESOURCE_END = "/comments/{commentID}";

    public ToDoEndpoint(RequestSpecification specification) : 
        base($"{specification.BaseUrl}")
    {
    }

    public List<ToDoDto> GetToDos()
    {
        var response = Get(COMMENTDS_END);
        var dtoResponse = DtoConverter.StringToDto<List<ToDoDto>>(response.Content);
        return dtoResponse;
    }
    
    public ToDoDto GetToDoById(int id)
    {
        return null;
    }

}