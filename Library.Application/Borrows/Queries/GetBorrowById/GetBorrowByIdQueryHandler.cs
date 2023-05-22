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

namespace Library.Application.Borrows.Queries.GetBorrowById
{
    public class GetBorrowByIdQueryHandler: IRequestHandler<GetBorrowByIdQuery,Borrow>
    {
        ILibraryDbContext _dbContext;
        public GetBorrowByIdQueryHandler(ILibraryDbContext dbContext)=> _dbContext=dbContext;

        public async Task<Borrow> Handle(GetBorrowByIdQuery request, CancellationToken cancellationToken)
        {
            var borrow = await _dbContext.Borrows.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken).ConfigureAwait(false);

            if (borrow == null)
                throw new EntityNotFoundException(nameof(Borrow), "ID", request.Id);

            return borrow;
        }
    }
}
