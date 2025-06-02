using ApiAppDemo.Application.Handlers.BaseModel;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Borrowers.GetBorrower;

public class GetBorrowerResponse : BaseResponse
{
    public Borrower? Borrower { get; set; }
    public GetBorrowerResponse() : base() { }
    public GetBorrowerResponse(List<string> errors) : base(errors) { }
}
