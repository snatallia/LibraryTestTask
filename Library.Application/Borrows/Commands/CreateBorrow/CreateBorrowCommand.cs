using MediatR;

namespace Library.Application.Borrows.Commands.CreateBorrow
{
    public class CreateBorrowCommand:IRequest<Guid>
    {
        public Guid BookId { get; set; }
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
    }
}
