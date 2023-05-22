using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Borrows.Queries.GetBorrows
{
    public class GetBorrowsQueryHandler : IRequestHandler<GetBorrowsQuery, IList<Borrow>>
    {
        ILibraryDbContext _dbContext;
        public GetBorrowsQueryHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IList<Borrow>> Handle(GetBorrowsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Borrows.ToListAsync().ConfigureAwait(false);
        }
    }
}
