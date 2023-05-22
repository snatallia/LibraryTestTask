using FluentValidation;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidation: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidation()
        {
            RuleFor(DeleteBookCommand => DeleteBookCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
