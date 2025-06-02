using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Authors.AddAuthor;

public class AddAuthorHandler : ICommandHandler<AddAuthor, AddAuthorResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public AddAuthorHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<AddAuthorResponse> Handle(AddAuthor request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var newAuthor = new Author
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            //CreatedBy = userName,
            //ModifiedBy = userName
            CreatedBy = "test",
            ModifiedBy = "test"
        };


        _context.Authors.Add(newAuthor);
        await _context.SaveChangesAsync(cancellationToken);

        return new AddAuthorResponse();
    }
}
