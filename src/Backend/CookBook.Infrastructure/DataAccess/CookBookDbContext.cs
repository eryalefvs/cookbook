using CookBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.DataAccess
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CookBookDbContext).Assembly);
        }
    }
}
