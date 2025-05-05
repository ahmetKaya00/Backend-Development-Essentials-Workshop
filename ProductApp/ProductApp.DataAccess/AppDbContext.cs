using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;
namespace ProductApp.DataAccess{

    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}

        public DbSet<Product> Products => Set<Product>();
    }
}