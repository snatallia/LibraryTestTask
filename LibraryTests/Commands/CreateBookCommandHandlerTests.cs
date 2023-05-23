using Library.Application.Books.Commands.CreateBook;
using Library.Domain;
using LibraryTests.Common;
using Microsoft.EntityFrameworkCore;

namespace LibraryTests.Commands
{
    public class CreateBookCommandHandlerTests: TestCommandBase
    {
        [Fact]
        public async Task CreateBookCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateBookCommandHandler(Context);
            var iban = "1111-111-11111-1";
            var bookTitle = "Book title";
            var noteDescription = "Some book description";
            var genre = GenreNames.Science;

            // Act
            var bookId = await handler.Handle(
                new CreateBookCommand
                {
                    IBAN = iban,
                    Title = bookTitle,
                    Description = noteDescription,
                    Genre = genre,
                    AuthorId = TestContextFactory.AuthorId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Books.SingleOrDefaultAsync(book =>
                    book.Id == bookId && book.IBAN == iban && book.Title == bookTitle && book.Description == noteDescription
                    && book.AuthorId == TestContextFactory.AuthorId));
        }
    }
}
