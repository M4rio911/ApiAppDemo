using ApiAppDemo.Application.Dto.Categories;
using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;

namespace ApiAppDemo.Application.Handlers.Categories.GetCategory;

public class GetCategoryHandler : ICommandHandler<GetCategory, GetCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryResponse> Handle(GetCategory request, CancellationToken cancellationToken)
    {
        var dbCategory = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        var categoryDto = new CategoryDto
        {
            Id = dbCategory.Id,
            Name = dbCategory.Name
        };

        return new GetCategoryResponse() { Category = categoryDto };
    }
}
