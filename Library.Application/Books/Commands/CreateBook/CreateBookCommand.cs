using Library.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        [Required]
        public string IBAN { get; set; }
        [Required]
        public string Title { get; set; }
        public GenreNames Genre { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
