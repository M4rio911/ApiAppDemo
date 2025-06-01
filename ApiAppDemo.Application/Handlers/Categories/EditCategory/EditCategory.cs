using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Categories.EditCategory;

public class EditCategory : ICommand<EditCategoryResponse>
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    public EditCategory(EditCategoryParameters parameters)
    {
        CategoryId = parameters.CategoryId;
        Name = parameters.Name;
    }
}