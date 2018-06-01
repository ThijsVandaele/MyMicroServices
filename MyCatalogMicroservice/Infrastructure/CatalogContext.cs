using Microsoft.EntityFrameworkCore;
using MyCatalogMicroservice.Model;

namespace MyCatalogMicroservice.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<CatalogItem> catalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> catalogTypes { get; set; }
    }
}
