using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Books.RemoveBook;

public class RemoveBookResponse : BaseResponse
{
    public RemoveBookResponse() : base() { }
    public RemoveBookResponse(string error) : base(error) { }
    public RemoveBookResponse(List<string> errors) : base(errors) { }
}
