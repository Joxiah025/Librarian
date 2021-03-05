using Librarian.Entities;
using Microsoft.EntityFrameworkCore;

namespace Librarian.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Exception> Exceptions { get; set; }
    }
}