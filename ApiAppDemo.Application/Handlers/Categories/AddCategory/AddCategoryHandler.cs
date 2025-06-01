using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Categories.AddCategory;

public class AddCategoryHandler : ICommandHandler<AddCategory, AddCategoryResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public AddCategoryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<AddCategoryResponse> Handle(AddCategory request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var newCategory = new Category
        {
            Name = request.Name,
            //CreatedBy = userName,
            //ModifiedBy = userName
            CreatedBy = "test",
            ModifiedBy = "test"
        };


        _context.Categories.Add(newCategory);
        await _context.SaveChangesAsync(cancellationToken);

        return new AddCategoryResponse();
    }
}
