using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Categories.RemoveCategory;

public class RemoveCategoryResponse : BaseResponse
{
    public RemoveCategoryResponse() : base() { }
    public RemoveCategoryResponse(string error) : base(error) { }
    public RemoveCategoryResponse(List<string> errors) : base(errors) { }
}
