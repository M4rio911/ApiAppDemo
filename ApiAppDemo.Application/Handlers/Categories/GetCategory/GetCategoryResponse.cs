using ApiAppDemo.Application.Dto.Categories;
using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Categories.GetCategory;

public class GetCategoryResponse : BaseResponse
{
    public CategoryDto? Category { get; set; }
    public GetCategoryResponse() : base() { }
    public GetCategoryResponse(List<string> errors) : base(errors) { }
}
