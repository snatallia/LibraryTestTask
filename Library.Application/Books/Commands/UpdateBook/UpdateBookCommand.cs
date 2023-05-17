using MediatR;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
        public int IBAN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateBorrow { get; set; }
        public DateTime? DateReturn { get; set; }
        public Guid AuthorId { get; set; }
    }
}
