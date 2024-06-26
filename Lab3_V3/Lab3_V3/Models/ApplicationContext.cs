using Microsoft.EntityFrameworkCore;

namespace Lab3_V3.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            //Database.EnsureDeleted();
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<ReaderModel> Readers { get; set; }
    }
}
