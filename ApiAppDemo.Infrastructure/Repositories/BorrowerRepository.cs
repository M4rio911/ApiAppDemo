using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ApiAppDemo.Infrastructure.Repositories;
public class BorrowerRepository : AppDbContextFactory, IBorrowerRepository
{
    private readonly AppDbContext _context;
    public BorrowerRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Borrower> AddAsync(Borrower borrower, CancellationToken token)
    {
        _context.Borrowers.Add(borrower);
        await _context.SaveChangesAsync(token);
        return borrower;
    }
    public async Task DeleteAsync(int id, CancellationToken token)
    {
        var borrower = await _context.Borrowers
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(token);
        if (borrower != null)
        {
            _context.Borrowers.Remove(borrower);
            await _context.SaveChangesAsync(token);
        }
    }
    public async Task<Borrower> EditAsync(Borrower borrower, CancellationToken token)
    {
        _context.Borrowers.Update(borrower);
        await _context.SaveChangesAsync(token);
        return borrower;
    }
    public async Task<Borrower> GetByIdAsync(int id, CancellationToken token)
    {
        return await _context.Borrowers
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(token);
    }
    public async Task<List<Borrower>> GetBorrowersAsync(CancellationToken token)
    {
        return await _context.Borrowers
            .ToListAsync(token);
    }

    public Task<bool> RemoveBorrower(int borrowerId, CancellationToken cancellationToken)
    {

        var borrower = _context.Borrowers
            .Where(x => x.Id == borrowerId)
            .FirstOrDefaultAsync(cancellationToken);

        if (borrower != null)
        {
            _context.Borrowers.Remove(borrower.Result);
            return _context.SaveChangesAsync(cancellationToken).ContinueWith(t => true, cancellationToken);
        }
        return Task.FromResult(false);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
