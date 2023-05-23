using Library.Application.Books.Dtos;
using Library.Domain;
using MediatR;

namespace Library.Application.Books.Queries.GetBooks
{
    public class GetBooksShortQuery: IRequest<BookList>
    {
    }
}
