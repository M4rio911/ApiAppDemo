using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Authors.EditAuthor;

public class EditAuthorResponse : BaseResponse
{
    public EditAuthorResponse() : base() { }
    public EditAuthorResponse(List<string> errors) : base(errors) { }
}
