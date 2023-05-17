using Library.Application.Interfaces;
using Library.Domain;
using Library.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) {  }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BorrowConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
