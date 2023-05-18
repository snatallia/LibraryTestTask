using AutoMapper;
using Library.Application.Books.Dtos;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBookDetailsById
{
    public class GetBookDetailsByIdQueryHandler : IRequestHandler<GetBookDetailsByIdQuery, BookDetailDto>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookDetailsByIdQueryHandler(ILibraryDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<BookDetailDto> Handle(GetBookDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(book=> book.Id == request.Id, cancellationToken).ConfigureAwait(false);

            if (book == null)
                throw new NotFoundEntityException(nameof(Book),"ID", request.Id);

            return _mapper.Map<BookDetailDto>(book);
        }
    }
}
