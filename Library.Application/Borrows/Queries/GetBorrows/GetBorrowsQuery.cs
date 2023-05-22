using Library.Domain;
using MediatR;

namespace Library.Application.Borrows.Queries.GetBorrows
{
    public class GetBorrowsQuery : IRequest<IList<Borrow>>
    {
    }
}
