using FluentValidation;

namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidation: AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidation()
        {
            RuleFor(DeleteAuthorCommand => DeleteAuthorCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
