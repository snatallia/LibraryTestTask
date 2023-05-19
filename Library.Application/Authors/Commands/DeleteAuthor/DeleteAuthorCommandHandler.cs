using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler: IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeleteAuthorCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (author == null)
                throw new NotFoundEntityException(nameof(Author), "ID", request.Id);

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return true;
        }
    }
}
