using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Books.BorrowBook;

public class BorrowBookResponse : BaseResponse
{
    public BorrowBookResponse() : base() { }
    public BorrowBookResponse(string error) : base(error) { }
    public BorrowBookResponse(List<string> errors) : base(errors) { }
}
