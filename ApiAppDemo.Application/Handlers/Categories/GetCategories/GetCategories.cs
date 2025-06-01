using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Categories.GetCategories;

public class GetCategories : ICommand<GetCategoriesResponse>
{
    public GetCategories()
    {

    }
}