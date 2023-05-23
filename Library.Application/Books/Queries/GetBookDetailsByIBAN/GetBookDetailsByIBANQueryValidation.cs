using FluentValidation;

namespace Library.Application.Books.Queries.GetBookDetailsByIBAN
{
    public class GetBookDetailsByIBANQueryValidation:AbstractValidator<GetBookDetailsByIBANQuery>
    {
        public GetBookDetailsByIBANQueryValidation()
        {
            RuleFor(book => book.IBAN).NotEmpty().MaximumLength(17);
        }
    }
}
