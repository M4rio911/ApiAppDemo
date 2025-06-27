using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Categories.RemoveCategory;

public class RemoveCategoryHandler : ICommandHandler<RemoveCategory, RemoveCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    public RemoveCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<RemoveCategoryResponse> Handle(RemoveCategory request, CancellationToken cancellationToken)
    {
        var dbCategory = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        if (dbCategory == null)
        {
            return new RemoveCategoryResponse("Catergory with passed Id does not exists");
        }

        await _categoryRepository.RemoveCategory(dbCategory.Id, cancellationToken);

        return new RemoveCategoryResponse();
    }
}
