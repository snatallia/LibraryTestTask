using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler:IRequestHandler<GetAuthorByIdQuery,Author>
    {
        private readonly ILibraryDbContext _dbContext;
        public GetAuthorByIdQueryHandler(ILibraryDbContext dbContext) => _dbContext=dbContext;
        
        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken).ConfigureAwait(false);

            if (author == null)
                throw new EntityNotFoundException(nameof(Author), "ID", request.Id);
            
            return author;
        }
    }
}
