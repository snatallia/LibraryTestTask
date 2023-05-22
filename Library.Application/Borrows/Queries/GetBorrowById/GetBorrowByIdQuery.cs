using Library.Domain;
using MediatR;

namespace Library.Application.Borrows.Queries.GetBorrowById
{
    public class GetBorrowByIdQuery:IRequest<Borrow>
    {
        public Guid Id { get; set; }
    }
}
