using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler: IRequestHandler<DeleteBookCommand, bool>
    {
        ILibraryDbContext _dbContext;
        public DeleteBookCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (book == null)
                throw new NotFoundEntityException(nameof(Book), request.Id);

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return true;
        }
    }
}
