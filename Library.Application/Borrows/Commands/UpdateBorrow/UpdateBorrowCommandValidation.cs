using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Borrows.Commands.UpdateBorrow
{
    public class UpdateBorrowCommandValidation:AbstractValidator<UpdateBorrowCommand>
    {
        public UpdateBorrowCommandValidation()
        {
            RuleFor(UpdateBorrowCommand => UpdateBorrowCommand.DateBorrow).Must(DataBorrowCheck);
            RuleFor(UpdateBorrowCommand => UpdateBorrowCommand.BookId).NotEqual(Guid.Empty);
        }

        private bool DataBorrowCheck(DateTime date)
        {
            return date >= DateTime.MinValue && date <= DateTime.Now;
        }
    }
}
