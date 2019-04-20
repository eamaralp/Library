using Library.Domain.Entities;
using Library.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Data.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Library;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
