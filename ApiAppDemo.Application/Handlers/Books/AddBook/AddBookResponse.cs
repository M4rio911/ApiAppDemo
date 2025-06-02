using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Books.AddBook;

public class AddBookResponse : BaseResponse
{
    public AddBookResponse() : base() { }
    public AddBookResponse(List<string> errors) : base(errors) { }
}
