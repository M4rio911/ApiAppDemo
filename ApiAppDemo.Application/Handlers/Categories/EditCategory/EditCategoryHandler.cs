using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiAppDemo.Application.Handlers.Categories.EditCategory;

public class EditCategoryHandler : ICommandHandler<EditCategory, EditCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    public EditCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<EditCategoryResponse> Handle(EditCategory request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
            return new EditCategoryResponse("No category found");

        category.Name = request.Name;
        category.ModifiedBy = "test";

        await _categoryRepository.SaveChangesAsync(cancellationToken);

        return new EditCategoryResponse();
    }
}
