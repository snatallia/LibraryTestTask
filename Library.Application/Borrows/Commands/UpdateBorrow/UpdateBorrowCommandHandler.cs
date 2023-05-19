using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Borrows.Commands.UpdateBorrow
{
    public class UpdateBorrowCommandHandler : IRequestHandler<UpdateBorrowCommand, bool>
    {
        private readonly ILibraryDbContext _dbContext;
        public UpdateBorrowCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> Handle(UpdateBorrowCommand request, CancellationToken cancellationToken)
        {
            var borrow = await _dbContext.Borrows.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken).ConfigureAwait(false);

            if (borrow == null)
                throw new EntityNotFoundException(nameof(Borrow), "ID", request.Id);

            borrow.BookId = request.BookId;
            borrow.DateBorrow = request.DateBorrow;
            borrow.DateReturn = request.DateReturn;

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return true;
        }
    }
}
