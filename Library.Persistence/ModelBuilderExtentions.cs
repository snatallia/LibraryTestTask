using Library.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Library.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region AuthorSeed
            modelBuilder.Entity<Author>().HasData
            (
                new Author { Id = Guid.Parse("914c29b0-8a4d-401a-a337-f25f38d6d5cc"), Name = "Steven", Surname = "King" },
                new Author { Id = Guid.Parse("4108e0f6-44a7-4635-bac3-38390459d5c3"), Name = "Joanne", Surname = "Rowling" },
                new Author { Id = Guid.Parse("3d4daea6-0ba7-46b2-932c-8f65a2f4ac21"), Name = "Robert", Surname = "Martin" }

            );
            #endregion

            #region BookSeed
            modelBuilder.Entity<Book>().HasData
            (
                new Book { Id = Guid.Parse("bee2997a-d08d-49ef-b440-803e9e0db533"), AuthorId = Guid.Parse("914c29b0-8a4d-401a-a337-f25f38d6d5cc"), Title = "The Green Mile" },
                new Book { Id = Guid.Parse("db4ff8e9-7b66-4d6b-8f69-d917206507dc"), AuthorId = Guid.Parse("914c29b0-8a4d-401a-a337-f25f38d6d5cc"), Title = "Children of the Corn" },
                new Book { Id = Guid.Parse("2ff15fcb-34ed-4337-80fe-ab0eda46fd8a"), AuthorId = Guid.Parse("914c29b0-8a4d-401a-a337-f25f38d6d5cc"), Title = "Dolores Claiborne" },
                new Book { Id = Guid.Parse("ae85a0e8-523d-4756-a5f9-5f6c017284a7"), AuthorId = Guid.Parse("914c29b0-8a4d-401a-a337-f25f38d6d5cc"), Title = "The Shawshank Redemption" },
                new Book { Id = Guid.Parse("115152ab-5fe4-4807-8186-8aa48e5ac725"), AuthorId = Guid.Parse("3d4daea6-0ba7-46b2-932c-8f65a2f4ac21"), Title = "Clean Architecture: A Craftsman’s Guide to Software Structure and Design", IBAN= "9780134494166" }
            );
            #endregion

            #region BorrowSeed
            modelBuilder.Entity<Borrow>().HasData
                (
                new Borrow { Id=Guid.Parse("a75cfa61-1d81-460b-ac15-578766c0acc3"), DateBorrow = DateTime.Now.AddMonths(-1).Date, DateReturn = DateTime.Now.AddDays(-10).Date, BookId= Guid.Parse("bee2997a-d08d-49ef-b440-803e9e0db533") }
                );
            #endregion
        }
    }
}
