using FluentValidation;

namespace Library.Application.Borrows.Commands.CreateBorrow
{
    public class CreateBorrowCommandValidation:AbstractValidator<CreateBorrowCommand>
    {
        public CreateBorrowCommandValidation()
        {
            RuleFor(CreateBorrowCommand=>CreateBorrowCommand.DateBorrow).Must(DataBorrowCheck);
            RuleFor(CreateBorrowCommand => CreateBorrowCommand.BookId).NotEqual(Guid.Empty);
        }

        private bool DataBorrowCheck(DateTime date)
        {
            return date >= DateTime.MinValue && date <= DateTime.Now;
        }
    }
}
