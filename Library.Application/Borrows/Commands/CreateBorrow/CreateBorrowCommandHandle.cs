using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.Borrows.Commands.CreateBorrow
{
    public class CreateBorrowCommandHandle: IRequestHandler<CreateBorrowCommand,Guid>
    {
        private readonly ILibraryDbContext _dbcontext;
        public CreateBorrowCommandHandle(ILibraryDbContext dbContext) => _dbcontext = dbContext;

        public async Task<Guid> Handle(CreateBorrowCommand request, CancellationToken cancellationToken)
        {
            var borrow = new Borrow
            {
                Id = new Guid(),
                BookId = request.BookId,
                DateBorrow = request.DateBorrow,
                DateReturn = request.DateReturn
            };

            await _dbcontext.Borrows.AddAsync(borrow, cancellationToken).ConfigureAwait(false);
            await _dbcontext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            
            return borrow.Id;
        }
    }
}
