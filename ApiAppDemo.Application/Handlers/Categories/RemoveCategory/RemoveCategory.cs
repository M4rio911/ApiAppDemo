using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Categories.RemoveCategory;

public class RemoveCategory : ICommand<RemoveCategoryResponse>
{
    public int CategoryId { get; set; }

    public RemoveCategory(RemoveCategoryParameters parameters)
    {
        CategoryId = parameters.CategoryId;
    }
}