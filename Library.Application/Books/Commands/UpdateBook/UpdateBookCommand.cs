using Library.Domain;
using MediatR;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
        public string IBAN { get; set; }
        public string Title { get; set; }
        public GenreNames Genre { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
    }
}
