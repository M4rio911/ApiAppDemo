using ApiAppDemo.Application.Handlers.BaseModel;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Borrowers.GetBorrowers;

public class GetBorrowersResponse : BaseResponse
{
    public IEnumerable<Borrower?> Borrowers { get; set; }
    public GetBorrowersResponse() : base() { }
    public GetBorrowersResponse(List<string> errors) : base(errors) { }
}
