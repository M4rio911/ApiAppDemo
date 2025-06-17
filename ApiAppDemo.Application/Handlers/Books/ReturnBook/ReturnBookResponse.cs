using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Books.ReturnBook;

public class ReturnBookResponse : BaseResponse
{
    public ReturnBookResponse() : base() { }
    public ReturnBookResponse(string error) : base(error) { }
    public ReturnBookResponse(List<string> errors) : base(errors) { }
}
