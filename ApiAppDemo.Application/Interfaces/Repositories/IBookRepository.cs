using ApiAppDemo.Application.Dto.Books;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Interfaces.Repositories;

public interface IBookRepository
{
    Task<Book> AddAsync(Book book, CancellationToken token);
    Task<Book> EditAsync(EditBookDto book, CancellationToken token);
    Task DeleteAsync(int id, CancellationToken token);
    Task<Book> GetByIdAsync(int id, CancellationToken token);
    Task<List<Book>> GetBooksAsync(CancellationToken token);
    Task<bool> BorrowBook(int bookId, int borrowerId, CancellationToken cancellationToken);
    Task<bool> ReturnBook(int bookId, CancellationToken cancellationToken);
    Task<Book> RemoveBook (int bookId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
