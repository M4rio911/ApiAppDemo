using ApiAppDemo.Application.Dto.Categories;
using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;

namespace ApiAppDemo.Application.Handlers.Categories.GetCategories;

public class GetCategoriesHandler : ICommandHandler<GetCategories, GetCategoriesResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoriesResponse> Handle(GetCategories request, CancellationToken cancellationToken)
    {
        var dbCategories = await _categoryRepository.GetCategoriesAsync(cancellationToken);

        var categoryDtos = dbCategories
        .Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        })
        .ToList();

        return new GetCategoriesResponse() { Categories = categoryDtos };
    }
}
