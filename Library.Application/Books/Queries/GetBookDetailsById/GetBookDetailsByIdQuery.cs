using Library.Application.Books.Dtos;
using MediatR;

namespace Library.Application.Books.Queries.GetBookDetailsById
{
    public class GetBookDetailsByIdQuery: IRequest<BookDetailDto>
    {
        public Guid Id { get; set; }
    }
}
