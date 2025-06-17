using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.AddBook;

public class AddBookHandler : ICommandHandler<AddBook, AddBookResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public AddBookHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<AddBookResponse> Handle(AddBook request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var newBook = new Book
        {
            AuthorId = request.AuthorId,
            CategoryId = request.CategoryId,
            Title = request.Title,
            Description = request.Description,
            IsBorrowed = false,

            //CreatedBy = userName,
            //ModifiedBy = userName
            CreatedBy = "test",
            ModifiedBy = "test"
        };


        _context.Books.Add(newBook);
        await _context.SaveChangesAsync(cancellationToken);

        return new AddBookResponse();
    }
}
