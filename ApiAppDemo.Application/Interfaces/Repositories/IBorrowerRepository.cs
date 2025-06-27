using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Interfaces.Repositories;

public interface IBorrowerRepository
{
    Task<Borrower> AddAsync(Borrower book, CancellationToken token);
    Task<Borrower> EditAsync(Borrower book, CancellationToken token);
    Task DeleteAsync(int id, CancellationToken token);
    Task<Borrower> GetByIdAsync(int id, CancellationToken token);
    Task<List<Borrower>> GetBorrowersAsync(CancellationToken token);
    Task<bool> RemoveBorrower(int borrowerId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
