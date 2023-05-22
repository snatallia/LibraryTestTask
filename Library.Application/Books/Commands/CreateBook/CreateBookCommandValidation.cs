using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
