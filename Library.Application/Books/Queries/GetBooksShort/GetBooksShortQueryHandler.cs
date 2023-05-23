using AutoMapper.QueryableExtensions;
using AutoMapper;
using Library.Application.Books.Dtos;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBooks
{
    public class GetBooksShortQueryHandler: IRequestHandler<GetBooksShortQuery, BookList>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksShortQueryHandler(ILibraryDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BookList> Handle(GetBooksShortQuery request, CancellationToken cancellationToken)
        {
            var books = await _dbContext.Books
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync().ConfigureAwait(false);

            return new BookList { Books = books };
        }
    }
}
