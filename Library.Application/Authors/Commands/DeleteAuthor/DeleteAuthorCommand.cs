using MediatR;

namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
