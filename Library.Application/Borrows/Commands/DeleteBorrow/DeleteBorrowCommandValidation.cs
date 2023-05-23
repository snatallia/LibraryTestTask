using FluentValidation;

namespace Library.Application.Borrows.Commands.DeleteBorrow
{
    public class DeleteBorrowCommandValidation: AbstractValidator<DeleteBorrowCommand>
    {
        public DeleteBorrowCommandValidation()
        {
            RuleFor(DeleteBorrowCommand => DeleteBorrowCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
