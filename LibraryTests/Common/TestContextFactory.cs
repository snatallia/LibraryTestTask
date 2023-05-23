using Library.Domain;
using Library.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryTests.Common
{
    public class TestContextFactory
    {
        public readonly static Guid BookId1 = Guid.NewGuid();
        public readonly static Guid BookId2= Guid.NewGuid();
        public readonly static Guid AuthorId = Guid.NewGuid();

        public readonly static Guid BookIdDelete = Guid.NewGuid();
        public readonly static Guid BookIdUpdate = Guid.NewGuid();

       public static LibraryDbContext Create()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            var context = new LibraryDbContext(options);
            context.Database.EnsureCreated();

            context.Books.AddRange(
                new Book
                {   
                    Id = Guid.Parse("25ad18ca-89bf-4619-b00b-ddec752c8786"),
                    Title = "Book title 1",
                    AuthorId = AuthorId
                },
                new Book
                {
                    Id = Guid.Parse("08625eb6-3d25-4dc5-877c-6142162a5287"),
                    Title = "Book title 2",
                    AuthorId = AuthorId
                },
               new Book
               {
                   Id = Guid.Parse("6b60621f-119d-4957-85f5-49dfea8773d2"),
                   Title = "Book title 3",
                   AuthorId = AuthorId
               },
               new Book
               {
                   Id = Guid.Parse("0ce9cc5e-34f9-492c-b671-de00eaa2a014"),
                   Title = "Book title 4",
                   AuthorId = AuthorId
               }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(LibraryDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
