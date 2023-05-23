using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidation:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidation()
        {
            RuleFor(UpdateAuthorCommand => UpdateAuthorCommand.Id).NotEqual(Guid.Empty);
            RuleFor(UpdateAuthorCommand => UpdateAuthorCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(UpdateAuthorCommand => UpdateAuthorCommand.Surname).MaximumLength(50);
        }
    }
}
