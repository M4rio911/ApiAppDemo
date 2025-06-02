using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Borrowers.EditBorrower;

public class EditBorrroweHandler : ICommandHandler<EditBorrower, EditBorrowerResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public EditBorrroweHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<EditBorrowerResponse> Handle(EditBorrower request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var dbBorrower = await _context.Borrowers
            .Where(x => x.Id == request.BorrowerId)
            .FirstOrDefaultAsync(cancellationToken);

        dbBorrower.ModifiedBy = "test";
        dbBorrower.FirstName = request.FirstName;
        dbBorrower.LastName = request.LastName;
        dbBorrower.BirthDate = request.DateOfBirth;

        await _context.SaveChangesAsync(cancellationToken);

        return new EditBorrowerResponse();
    }
}
