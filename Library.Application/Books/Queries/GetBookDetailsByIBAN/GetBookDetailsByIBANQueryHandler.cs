using AutoMapper;
using Library.Application.Books.Dtos;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBookDetailsByIBAN
{
    public class GetBookDetailsByIBANQueryHandler:IRequestHandler<GetBookDetailsByIBANQuery,BookDetailDto>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookDetailsByIBANQueryHandler(ILibraryDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BookDetailDto> Handle(GetBookDetailsByIBANQuery request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(book => book.IBAN == request.IBAN, cancellationToken).ConfigureAwait(false);

            if (book == null)
                throw new EntityNotFoundException(nameof(Book), "IBAN", request.IBAN);

            return _mapper.Map<BookDetailDto>(book);
        }
    }
}
