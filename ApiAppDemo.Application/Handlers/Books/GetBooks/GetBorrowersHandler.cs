using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.GetBooks;

public class GetBorrowersHandler : ICommandHandler<GetBooks, GetBooksResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public GetBorrowersHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<GetBooksResponse> Handle(GetBooks request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var dbBooks = await _context.Books
            .ToListAsync(cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new GetBooksResponse() { Books = dbBooks };
    }
}