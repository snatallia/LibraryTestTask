using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        
        public CreateBookCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = new Guid(),
                IBAN = request.IBAN,
                Title = request.Title,
                Description = request.Description,
                DateBorrow = null,
                DateReturn = null,
                AuthorId = request.AuthorId                
            };

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
