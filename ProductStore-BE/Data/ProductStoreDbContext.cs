using Microsoft.EntityFrameworkCore;
using ProductStore_BE.Models;

namespace ProductStore_BE.Data;

public class ProductStoreDbContext : DbContext
{
    public ProductStoreDbContext(DbContextOptions options): base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
}
