using ApiAppDemo.Application.Dto.Categories;
using ApiAppDemo.Application.Handlers.BaseModel;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Categories.GetCategories;

public class GetCategoriesResponse : BaseResponse
{
    public IEnumerable<CategoryDto?> Categories { get; set; }
    public GetCategoriesResponse() : base() { }
    public GetCategoriesResponse(List<string> errors) : base(errors) { }
}
