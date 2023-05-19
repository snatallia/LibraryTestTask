using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Borrows.Commands.CreateBorrow
{
    public class CreateBorrowCommand:IRequest<Guid>
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
    }
}
