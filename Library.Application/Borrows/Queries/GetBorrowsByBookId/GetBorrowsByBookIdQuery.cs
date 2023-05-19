using Library.Domain;
using MediatR;

namespace Library.Application.Borrows.Queries.GetBorrowsByBookId
{
    public class GetBorrowsByBookIdQuery:IRequest<IList<Borrow>>
    {
        public Guid BookId { get; set; }
    }
}
