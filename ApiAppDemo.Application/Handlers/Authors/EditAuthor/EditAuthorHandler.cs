using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Authors.EditAuthor;

public class EditAuthorHandler : ICommandHandler<EditAuthor, EditAuthorResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public EditAuthorHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<EditAuthorResponse> Handle(EditAuthor request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var dbAuthor = await _context.Authors
            .Where(x => x.Id == request.AuthorId)
            .FirstOrDefaultAsync(cancellationToken);

        dbAuthor.ModifiedBy = "test";
        dbAuthor.FirstName = request.FirstName;
        dbAuthor.LastName = request.LastName;

        await _context.SaveChangesAsync(cancellationToken);

        return new EditAuthorResponse();
    }
}
