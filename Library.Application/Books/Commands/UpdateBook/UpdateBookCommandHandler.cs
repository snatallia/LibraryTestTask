﻿using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly ILibraryDbContext _dbContext;

        public UpdateBookCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (book == null)            
                throw new NotFoundEntityException(nameof(Book), request.Id);            

            book.IBAN = request.IBAN;
            book.Title = request.Title;
            book.Description = request.Description;
            book.DateBorrow = request.DateBorrow;
            book.DateReturn = request.DateReturn;
            book.AuthorId = request.AuthorId;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

     
    }
}
