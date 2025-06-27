using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Borrowers.EditBorrower;

public class EditBorrowerResponse : BaseResponse
{
    public EditBorrowerResponse() : base() { }
    public EditBorrowerResponse(List<string> errors) : base(errors) { }
    public EditBorrowerResponse(string error) : base(error) { }
}
