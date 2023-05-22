using Library.Domain;
using MediatR;

namespace Library.Application.Authors.Queries.GetAuthors
{
    public class GetAuthorsQuery : IRequest<IList<Author>>
    {
    }
}
