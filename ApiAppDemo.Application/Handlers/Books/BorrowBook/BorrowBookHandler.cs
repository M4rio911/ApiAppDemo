using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.BorrowBook;

public class BorrowBookHandler : ICommandHandler<BorrowBook, BorrowBookResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public BorrowBookHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<BorrowBookResponse> Handle(BorrowBook request, CancellationToken cancellationToken)
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
            return new BorrowBookResponse("Book with passed Id does not exists");
        }

        var dbBorrower = await _context.Borrowers
            .Where(x => x.Id == request.BorrowerId)
            .FirstOrDefaultAsync(cancellationToken);

        if (dbBorrower == null) 
        { 
            return new BorrowBookResponse("Borrower with passed Id does not exists"); 
        }

        if (dbBook.IsBorrowed)
        {
            return new BorrowBookResponse("Book is already borrowed");
        }

        dbBook.IsBorrowed = true;
        dbBook.BorrowerId = request.BorrowerId;

        await _context.SaveChangesAsync(cancellationToken);

        return new BorrowBookResponse();
    }
}
