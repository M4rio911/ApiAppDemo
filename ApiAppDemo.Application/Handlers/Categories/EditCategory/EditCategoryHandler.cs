using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Categories.EditCategory;

public class EditCategoryHandler : ICommandHandler<EditCategory, EditCategoryResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public EditCategoryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<EditCategoryResponse> Handle(EditCategory request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var dbCategory = await _context.Categories
            .Where(x => x.Id == request.CategoryId)
            .FirstOrDefaultAsync(cancellationToken);

        dbCategory.ModifiedBy = "test";
        dbCategory.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return new EditCategoryResponse();
    }
}
