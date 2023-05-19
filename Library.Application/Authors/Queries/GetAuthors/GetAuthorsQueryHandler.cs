using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authors.Queries.GetAuthors
{
    public class GetAuthorsQueryHandler:IRequestHandler<GetAuthorsQuery,IList<Author>>
    {
        private readonly ILibraryDbContext _dbContext;
        public GetAuthorsQueryHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IList<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Authors.ToListAsync().ConfigureAwait(false);
        }
    }
}
