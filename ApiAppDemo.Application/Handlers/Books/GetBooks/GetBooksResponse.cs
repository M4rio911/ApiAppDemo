using ApiAppDemo.Application.Handlers.BaseModel;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Books.GetBooks;
public class GetBooksResponse : BaseResponse
{
    public IEnumerable<Book?> Books { get; set; }
    public GetBooksResponse() : base() { }
    public GetBooksResponse(List<string> errors) : base(errors) { }
}
