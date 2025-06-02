using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Borrowers.AddBorrower;

public class AddBorrowerResponse : BaseResponse
{
    public AddBorrowerResponse() : base() { }
    public AddBorrowerResponse(List<string> errors) : base(errors) { }
}
