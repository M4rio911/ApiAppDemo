using ApiAppDemo.Application.Handlers.BaseModel;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Categories.GetCategory;

public class GetCategoryResponse : BaseResponse
{
    public Category? Category { get; set; }
    public GetCategoryResponse() : base() { }
    public GetCategoryResponse(List<string> errors) : base(errors) { }
}
