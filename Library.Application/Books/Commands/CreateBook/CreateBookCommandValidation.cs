using FluentValidation;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidation: AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidation()
        {
            RuleFor(CreateBookCommand => CreateBookCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(CreateBookCommand => CreateBookCommand.AuthorId).NotEqual(Guid.Empty);
        }
    }
}
