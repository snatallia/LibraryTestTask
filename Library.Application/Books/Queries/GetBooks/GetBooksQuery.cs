using Library.Application.Books.Dtos;
using MediatR;

namespace Library.Application.Books.Queries.GetBooks
{
    public class GetBooksQuery: IRequest<BookList>
    {
    }
}
