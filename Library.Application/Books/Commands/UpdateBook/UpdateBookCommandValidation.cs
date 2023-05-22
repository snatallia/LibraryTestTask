using FluentValidation;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidation: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidation()
        {
            RuleFor(UpdateBookCommand => UpdateBookCommand.Id).NotEqual(Guid.Empty);
            RuleFor(UpdateBookCommand => UpdateBookCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(UpdateBookCommand => UpdateBookCommand.AuthorId).NotEqual(Guid.Empty);
        }
    }
}
