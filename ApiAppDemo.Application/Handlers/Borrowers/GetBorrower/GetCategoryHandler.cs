using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Borrowers.GetBorrower;

public class GetCategoryHandler : ICommandHandler<GetBorrower, GetBorrowerResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public GetCategoryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<GetBorrowerResponse> Handle(GetBorrower request, CancellationToken cancellationToken)
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

        await _context.SaveChangesAsync(cancellationToken);

        return new GetBorrowerResponse() { Borrower = dbBorrower };
    }
}
