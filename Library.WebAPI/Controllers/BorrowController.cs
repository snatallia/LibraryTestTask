using Library.Application.Borrows.Commands.CreateBorrow;
using Library.Application.Borrows.Commands.DeleteBorrow;
using Library.Application.Borrows.Commands.UpdateBorrow;
using Library.Application.Borrows.Queries.GetBorrowById;
using Library.Application.Borrows.Queries.GetBorrows;
using Library.Domain;
using Library.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BorrowController : BaseController
    {
        /// <summary>
        /// Get all Borrows
        /// </summary>
        /// <returns> IList of Borrow </returns>        
        /// <response code="401">The user is unauthorized</response>
        /// <response code="500">Inner DB error</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IList<Borrow>>> GetAll()
        {
            var query = new GetBorrowsQuery();
            var borrows = await Mediator.Send(query);
            return Ok(borrows);
        }

        /// <summary>
        /// Get Borrow by Id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found  entity exception</response>
        /// <response code="422">Wrong field format</response>
        /// <response code="500">Inner DB error</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Borrow>> GetById(Guid id)
        {
            var query = new GetBorrowByIdQuery
            {
                Id = id
            };
            var borrow = await Mediator.Send(query);
            return Ok(borrow);
        }

        /// <summary>
        /// Add new Borrow
        /// </summary>
        /// <param name="newBorrow"></param>
        /// <remarks>
        /// {"bookId":"115152ab-5fe4-4807-8186-8aa48e5ac725",
        /// "dateBorrow": "2023-05-23",
        /// "dateReturn": "2023-06-23" }
        /// </remarks>
        /// <response code="400">There's not required field (Name)</response>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="422">Wrong field format (f.e., Name string(50), Surname string(50))</response>
        /// <response code="500">Inner DB error</response>
        [HttpPost]
        [Authorize]
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

        /// <summary>
        /// Update Borrow
        /// </summary>
        /// <remarks>
        /// {"id":"a75cfa61-1d81-460b-ac15-578766c0acc3",
        /// "bookId":"115152ab-5fe4-4807-8186-8aa48e5ac725",
        /// "dateBorrow": "2023-05-23",
        /// "dateReturn": "2023-06-23" }
        /// </remarks>
        /// <param name="borrow"></param>
        /// <returns>204 -- NoResponse()</returns>
        /// <response code="400">There's not required field</response>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found update entity exception</response>
        /// <response code="422">Wrong field format</response>
        /// <response code="500">Inner DB error</response>
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        [Authorize]
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

        /// <summary>
        /// Delete Borrow
        /// </summary>
        /// <param name="id"></param>
        /// <returns>204 -- NoResponse()</returns>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found update entity exception</response>
        /// <response code="422">Wrong field format</response>
        /// <response code="500">Inner DB error</response>
       // [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        [Authorize]
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