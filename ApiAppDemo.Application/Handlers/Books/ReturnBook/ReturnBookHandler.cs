using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.ReturnBook;

public class ReturnBookHandler : ICommandHandler<ReturnBook, ReturnBookResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public ReturnBookHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<ReturnBookResponse> Handle(ReturnBook request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var dbBook = await _context.Books
            .Where(x => x.Id == request.BookId)
            .FirstOrDefaultAsync(cancellationToken);

        if (dbBook == null)
        {
            return new ReturnBookResponse("Book with passed Id does not exists");
        }

        dbBook.IsBorrowed = false;
        dbBook.BorrowerId = null;
        //dbBook.ModifiedBy = userName;

        await _context.SaveChangesAsync(cancellationToken);

        return new ReturnBookResponse();
    }
}
