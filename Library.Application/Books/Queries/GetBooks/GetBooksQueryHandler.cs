using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler:IRequestHandler<GetBooksQuery, IList<Book>>
    {
        private readonly ILibraryDbContext _dbContext;

        public GetBooksQueryHandler(ILibraryDbContext dbContext) => (_dbContext) = (dbContext);

        public async Task<IList<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Books.Include(b => b.Borrows).Include(b=>b.Author).ToListAsync().ConfigureAwait(false);
        }
    }
}
