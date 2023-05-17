using MediatR;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public int IBAN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
        public Guid AuthorId { get; set; }
    }
}
