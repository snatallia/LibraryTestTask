using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Borrows.Commands.DeleteBorrow
{
    public class DeleteBorrowCommandHandler:IRequestHandler<DeleteBorrowCommand,bool>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeleteBorrowCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> Handle(DeleteBorrowCommand request, CancellationToken cancellationToken)
        {
            var borrow = await _dbContext.Borrows.FirstOrDefaultAsync(b => b.Id == request.Id,cancellationToken).ConfigureAwait(false);

            if (borrow == null)
                throw new EntityNotFoundException(nameof(Book), "ID", request.Id);
            
            _dbContext.Borrows.Remove(borrow);
            return true;
        }
    }
}
