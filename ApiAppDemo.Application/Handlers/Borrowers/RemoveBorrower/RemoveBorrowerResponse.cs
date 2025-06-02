using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Borrowers.RemoveBorrower;

public class RemoveBorrowerResponse : BaseResponse
{
    public RemoveBorrowerResponse() : base() { }
    public RemoveBorrowerResponse(string error) : base(error) { }
    public RemoveBorrowerResponse(List<string> errors) : base(errors) { }
}
