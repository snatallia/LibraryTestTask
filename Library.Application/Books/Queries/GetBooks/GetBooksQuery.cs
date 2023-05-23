using Library.Domain;
using MediatR;

namespace Library.Application.Books.Queries.GetBooks
{
    public class GetBooksQuery: IRequest<IList<Book>>
    {

    }
}
