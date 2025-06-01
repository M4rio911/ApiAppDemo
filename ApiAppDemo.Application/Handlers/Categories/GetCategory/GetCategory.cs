using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Categories.GetCategory;

public class GetCategory : ICommand<GetCategoryResponse>
{
    public int CategoryId { get; set; }

    public GetCategory(GetCategoryParameters parameters)
    {
        CategoryId = parameters.CategoryId;
    }
}