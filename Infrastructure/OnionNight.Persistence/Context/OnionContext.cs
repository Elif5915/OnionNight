using Microsoft.EntityFrameworkCore;
using OnionNight.Domain.Entities;

namespace OnionNight.Persistence.Context;
public class OnionContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=NETCADYAZ;initial Catalog=OnionNightDb;integrated security=true");
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}

