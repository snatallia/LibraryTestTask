using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Books.Dtos;
using Library.Application.Books.Queries.GetBookDetailsByIBAN;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler:IRequestHandler<GetBooksQuery, BookList>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(ILibraryDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BookList> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _dbContext.Books
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync().ConfigureAwait(false);

            return new BookList { Books = books };
        }
    }
}
