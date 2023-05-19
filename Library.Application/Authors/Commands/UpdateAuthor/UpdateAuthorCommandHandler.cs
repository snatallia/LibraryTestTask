using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler:IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly ILibraryDbContext _dbContext;
        public UpdateAuthorCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken).ConfigureAwait(false);
            
            if(author == null)
                throw new EntityNotFoundException(nameof(Author), "ID", request.Id);

            author.Name = request.Name;
            author.Surname = request.Surname;
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return true;
        }
    }
}
