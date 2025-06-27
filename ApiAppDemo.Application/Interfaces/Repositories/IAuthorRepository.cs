using ApiAppDemo.Application.Dto.Books;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Interfaces.Repositories;

public interface IAuthorRepository
{
    Task<Author> AddAsync(Author book, CancellationToken token);
    Task<Author> EditAsync(EditAuthorDto book, CancellationToken token);
    Task DeleteAsync(int id, CancellationToken token);
    Task<Author> GetByIdAsync(int id, CancellationToken token);
    Task<List<Author>> GetAuthorsAsync(CancellationToken token);
    Task<bool> RemoveAsync(int authorId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
