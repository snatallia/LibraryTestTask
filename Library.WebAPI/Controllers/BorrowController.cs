using Library.Application.Borrows.Commands.CreateBorrow;
using Library.Application.Borrows.Commands.DeleteBorrow;
using Library.Application.Borrows.Commands.UpdateBorrow;
using Library.Application.Borrows.Queries.GetBorrowById;
using Library.Application.Borrows.Queries.GetBorrows;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    public class BorrowController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<IList<Borrow>>> GetAll()
        {
            var query = new GetBorrowsQuery();
            var borrows = await Mediator.Send(query);
            return Ok(borrows);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Borrow>> GetById(Guid id)
        {
            var query = new GetBorrowByIdQuery
            {
                Id = id
            };
            var borrow = await Mediator.Send(query);
            return Ok(borrow);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] Borrow newBorrow)
        {
            var borrowId = await Mediator.Send(new CreateBorrowCommand
            {
                DateBorrow = newBorrow.DateBorrow,
                DateReturn = newBorrow.DateReturn,
                BookId = newBorrow.BookId
            });

            return borrowId;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Borrow borrow)
        {
            await Mediator.Send(new UpdateBorrowCommand
            {
                DateBorrow = borrow.DateBorrow,
                DateReturn = borrow.DateReturn,
                BookId=borrow.BookId
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBorrowCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}