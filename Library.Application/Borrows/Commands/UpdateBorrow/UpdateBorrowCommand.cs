using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Borrows.Commands.UpdateBorrow
{
    public class UpdateBorrowCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
    }
}
