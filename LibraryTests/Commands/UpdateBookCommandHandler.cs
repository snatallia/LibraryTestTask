using Library.Application.Books.Commands.UpdateBook;
using LibraryTests.Common;
using Library.Application.Common.Exceptions;

namespace LibraryTests.Commands
{
    public class UpdateBookCommandHandlerTests:TestCommandBase
    {
        [Fact]
        public async Task UpdateBookCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateBookCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateBookCommand
                    {
                        Id = TestContextFactory.BookIdUpdate,
                        AuthorId = TestContextFactory.AuthorId
                    },
                    CancellationToken.None);
            });
        }
    }
}
