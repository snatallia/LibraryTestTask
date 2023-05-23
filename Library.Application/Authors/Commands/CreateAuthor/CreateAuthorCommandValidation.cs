using FluentValidation;

namespace Library.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidation : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidation()
        {
            RuleFor(CreateAuthorCommand => CreateAuthorCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(CreateAuthorCommand => CreateAuthorCommand.Surname).MaximumLength(50);
        }
    }
}
