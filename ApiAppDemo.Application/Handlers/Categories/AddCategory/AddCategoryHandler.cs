using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Categories.AddCategory;

public class AddCategoryHandler : ICommandHandler<AddCategory, AddCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    public AddCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<AddCategoryResponse> Handle(AddCategory request, CancellationToken cancellationToken)
    {
        var newCategory = new Category
        {
            Name = request.Name,
            CreatedBy = "test",
            ModifiedBy = "test"
        };

        await _categoryRepository.AddAsync(newCategory, cancellationToken);

        return new AddCategoryResponse();
    }
}
