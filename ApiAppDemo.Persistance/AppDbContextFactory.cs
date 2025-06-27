using DeliveryApp.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ApiAppDemo.Persistance;

public class AppDbContextFactory : AppDbContextFactoryBase<AppDbContext>
{
    protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
    {
        return new AppDbContext(options);
    }
}