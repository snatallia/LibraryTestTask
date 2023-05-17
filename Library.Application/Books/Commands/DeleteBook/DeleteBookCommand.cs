using MediatR;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
