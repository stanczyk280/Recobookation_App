using Microsoft.EntityFrameworkCore;
using Recobookation.Domain;

namespace Recobookation.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}