using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Categories.EditCategory;

public class EditCategoryResponse : BaseResponse
{
    public EditCategoryResponse() : base() { }
    public EditCategoryResponse(List<string> errors) : base(errors) { }
}
