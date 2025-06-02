using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Borrowers.RemoveBorrower;

public class RemoveBorrowerHandler : ICommandHandler<RemoveBorrower, RemoveBorrowerResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public RemoveBorrowerHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<RemoveBorrowerResponse> Handle(RemoveBorrower request, CancellationToken cancellationToken)
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

        if (dbBorrower == null)
        {
            return new RemoveBorrowerResponse("Catergory with passed Id does not exists");
        }

        _context.Borrowers.Remove(dbBorrower);
        await _context.SaveChangesAsync(cancellationToken);

        return new RemoveBorrowerResponse();
    }
}
