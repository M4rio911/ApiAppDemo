using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Categories.AddCategory;

public class AddCategoryResponse : BaseResponse
{
    public AddCategoryResponse() : base() { }
    public AddCategoryResponse(List<string> errors) : base(errors) { }
}
