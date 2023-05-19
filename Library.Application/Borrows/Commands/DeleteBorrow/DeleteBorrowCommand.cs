using MediatR;

namespace Library.Application.Borrows.Commands.DeleteBorrow
{
    public class DeleteBorrowCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
