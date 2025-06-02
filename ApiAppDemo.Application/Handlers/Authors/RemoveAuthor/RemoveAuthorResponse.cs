using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Authors.RemoveAuthor;

public class RemoveAuthorResponse : BaseResponse
{
    public RemoveAuthorResponse() : base() { }
    public RemoveAuthorResponse(string error) : base(error) { }
    public RemoveAuthorResponse(List<string> errors) : base(errors) { }
}
