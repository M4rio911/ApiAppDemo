using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<Category> AddAsync(Category category, CancellationToken token);
    Task<Category> EditAsync(Category category, CancellationToken token);
    Task DeleteAsync(int id, CancellationToken token);
    Task<Category> GetByIdAsync(int id, CancellationToken token);
    Task<List<Category>> GetCategoriesAsync(CancellationToken token);
    Task<bool> RemoveCategory(int categoryId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
