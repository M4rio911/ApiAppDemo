using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Borrowers.AddBorrower;

public class AddBorrowerHandler : ICommandHandler<AddBorrower, AddBorrowerResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public AddBorrowerHandler(IHttpContextAccessor httpContextAccessor, AppDbContext deliveryDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = deliveryDbContext;
    }

    public async Task<AddBorrowerResponse> Handle(AddBorrower request, CancellationToken cancellationToken)
    {
        //var user = _httpContextAccessor.HttpContext?.User;
        //if (user == null)
        //{
        //    throw new UnauthorizedAccessException("User is not authenticated");
        //}
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userName = user.Identities.FirstOrDefault().Name;

        var newBorrower = new Borrower
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.DateOfBirth,
            //CreatedBy = userName,
            //ModifiedBy = userName
            CreatedBy = "test",
            ModifiedBy = "test"
        };


        _context.Borrowers.Add(newBorrower);
        await _context.SaveChangesAsync(cancellationToken);

        return new AddBorrowerResponse();
    }
}
