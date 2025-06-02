using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Authors.AddAuthor;

public class AddAuthorResponse : BaseResponse
{
    public AddAuthorResponse() : base() { }
    public AddAuthorResponse(List<string> errors) : base(errors) { }
}
