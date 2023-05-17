using Library.Application.Books.Dtos;
using MediatR;

namespace Library.Application.Books.Queries.GetBookDetailsById
{
    public class GetBookDetailsByIdQuery: IRequest<BookDto>
    {
        public Guid Id { get; set; }
    }
}
