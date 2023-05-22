using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBookDetailsById
{
    public class GetBookDetailsByIdQueryValidation:AbstractValidator<GetBookDetailsByIdQuery>
    {
        public GetBookDetailsByIdQueryValidation()
        {
            RuleFor(book=>book.Id).NotEqual(Guid.Empty);
        }
    }
}
