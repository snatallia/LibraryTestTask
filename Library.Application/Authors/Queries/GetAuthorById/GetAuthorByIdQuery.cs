using Library.Domain;
using MediatR;

namespace Library.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery: IRequest <Author>
    {
        public Guid Id { get; set; }
    }
}
