using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
             : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
