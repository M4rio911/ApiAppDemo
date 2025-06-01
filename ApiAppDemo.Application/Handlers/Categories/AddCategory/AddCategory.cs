using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Categories.AddCategory;

public class AddCategory : ICommand<AddCategoryResponse>
{
    public string Name { get; set; }

    public AddCategory(AddCategoryParameters parameters)
    {
        Name = parameters.Name;
    }
}