using Library.Application.Books.Dtos;
using MediatR;


namespace Library.Application.Books.Queries.GetBookDetailsByIBAN
{
    public class GetBookDetailsByIBANQuery: IRequest<BookDetailDto>
    {
        public string IBAN { get; set; }
    }
}
