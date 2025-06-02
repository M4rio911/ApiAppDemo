using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.EditBook;

public class EditBookHandler : ICommandHandler<EditBook, EditBookResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public EditBookHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<EditBookResponse> Handle(EditBook request, CancellationToken cancellationToken)
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

        dbBook.ModifiedBy = "test";
        dbBook.AuthorId = request.AuthorId;
        dbBook.CategoryId = request.CategoryId;
        dbBook.BorrowerId = request.BorrowerId;
        dbBook.Description = request.Description;
        dbBook.Title = request.Title;


        await _context.SaveChangesAsync(cancellationToken);

        return new EditBookResponse();
    }
}
