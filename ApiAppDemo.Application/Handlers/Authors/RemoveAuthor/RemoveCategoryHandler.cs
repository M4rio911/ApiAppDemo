using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Authors.RemoveAuthor;

public class RemoveCategoryHandler : ICommandHandler<RemoveAuthor, RemoveAuthorResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public RemoveCategoryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<RemoveAuthorResponse> Handle(RemoveAuthor request, CancellationToken cancellationToken)
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

        if (dbAuthor == null)
        {
            return new RemoveAuthorResponse("Author with passed Id does not exists");
        }

        _context.Authors.Remove(dbAuthor);
        await _context.SaveChangesAsync(cancellationToken);

        return new RemoveAuthorResponse();
    }
}
