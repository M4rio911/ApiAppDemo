using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Books.EditBook;

public class EditBookResponse : BaseResponse
{
    public EditBookResponse() : base() { }
    public EditBookResponse(List<string> errors) : base(errors) { }
    public EditBookResponse(string error) : base(error) { }
}
