using Newtonsoft.Json;

namespace ApiAppDemo.Application.Handlers.BaseModel;

public class BaseResponse
{
    [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Success { get; set; }

    [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Errors { get; set; }

    public BaseResponse()
    {
        Success = true;
    }
    public BaseResponse(List<string> errors)
    {
        Success = false;
        Errors = errors;
    }
    public BaseResponse(string error)
    {
        Success = false;
        Errors = [error];
    }
}
