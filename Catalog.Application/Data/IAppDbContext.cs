using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Data;

public interface IAppDbContext
{
    DbSet<Product> Products { get; }
    DbSet<Category> Categories { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
