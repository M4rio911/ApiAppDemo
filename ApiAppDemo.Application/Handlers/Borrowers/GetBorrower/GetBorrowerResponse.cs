using ApiAppDemo.Application.Dto.Borrowers;
using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Borrowers.GetBorrower;

public class GetBorrowerResponse : BaseResponse
{
    public BorrowerDto? Borrower { get; set; }
    public GetBorrowerResponse() : base() { }
    public GetBorrowerResponse(string error) : base(error) { }
    public GetBorrowerResponse(List<string> errors) : base(errors) { }
}
