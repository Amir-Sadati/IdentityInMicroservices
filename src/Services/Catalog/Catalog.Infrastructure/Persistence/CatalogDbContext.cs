using Catalog.Domain.ProductAggregate;
using Catalog.Domain.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalog.Infrastructure.Persistence
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
    }
}
