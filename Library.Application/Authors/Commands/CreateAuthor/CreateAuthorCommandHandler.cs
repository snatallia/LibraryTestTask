using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        public CreateAuthorCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Id = new Guid(),
                Name = request.Name,
                Surname = request.Surname
            };

            await _dbContext.Authors.AddAsync(author,cancellationToken).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return author.Id;
        }
    }
}
