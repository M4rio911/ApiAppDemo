using ApiAppDemo.Application.Handlers.BaseModel;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Books.GetBook;

public class GetBookResponse : BaseResponse
{
    public Book? Book { get; set; }
    public GetBookResponse() : base() { }
    public GetBookResponse(List<string> errors) : base(errors) { }
}
