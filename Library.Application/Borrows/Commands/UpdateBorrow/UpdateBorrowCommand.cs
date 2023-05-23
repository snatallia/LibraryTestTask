using MediatR;

namespace Library.Application.Borrows.Commands.UpdateBorrow
{
    public class UpdateBorrowCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
    }
}
