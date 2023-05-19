using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Borrows.Queries.GetBorrowsByBookId
{
    public class GetBorrowsByBookIdQueryHandler: IRequestHandler<GetBorrowsByBookIdQuery,IList<Borrow>>
    {
        private readonly ILibraryDbContext _dbContext;
        public GetBorrowsByBookIdQueryHandler(ILibraryDbContext dbContext)=> _dbContext = dbContext;

        public async Task<IList<Borrow>> Handle(GetBorrowsByBookIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Borrows.Where(b => b.BookId == request.BookId).ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
