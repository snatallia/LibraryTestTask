using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Authors.Commands.DeleteAuthor;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Application.Authors.Queries.GetAuthorById;
using Library.Application.Authors.Queries.GetAuthors;
using Library.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        /// <summary>
        /// Get the list of all authors. 
        /// </summary>
        /// <returns> IList of Author </returns>        
        /// <response code="401">The user is unauthorized</response>
        /// <response code="500">Inner DB error</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IList<Author>>> GetAll()
        {
            var query = new GetAuthorsQuery();
            var authors = await Mediator.Send(query);
            return Ok(authors);
        }

        /// <summary>
        /// Get Author data by Id
        /// </summary>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found  entity exception</response>
        /// <response code="422">Wrong field format</response>
        /// <response code="500">Inner DB error</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Author>> GetById(Guid id)
        {
            var query = new GetAuthorByIdQuery
            {
                Id = id
            };
            var author = await Mediator.Send(query);
            return Ok(author);
        }

        /// <summary>
        /// Add new Author 
        /// </summary>
        /// <remarks>
        /// {"Name": "Agatha",
        /// "Surname": "Christie" }
        /// </remarks>
        /// <response code="400">There's not required field (Name)</response>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="422">Wrong field format (f.e., Name string(50), Surname string(50))</response>
        /// <response code="500">Inner DB error</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Add([FromBody] Author newAuthor)
        {
            var authorId = await Mediator.Send(new CreateAuthorCommand
            {
                Name = newAuthor.Name,
                Surname = newAuthor.Surname            
            });

            return authorId;
        }

        /// <summary>
        /// Update Author 
        /// </summary>
        /// <remarks>
        /// {"id": "914c29b0-8a4d-401a-a337-f25f38d6d5cc"
        /// {"Name": "Agatha",
        /// "Surname": "Christie" }
        /// </remarks>
        /// <response code="400">There's not required field (Name)</response>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found update entity exception</response>
        /// <response code="422">Wrong field format (f.e., Name string(50), Surname string(50))</response>
        /// <response code="500">Inner DB error</response>        
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] Author author)
        {
            await Mediator.Send(new UpdateAuthorCommand
            {
               Name = author.Name,
               Surname = author.Surname
            });

            return NoContent();
        }

        /// <summary>
        /// Delete Author
        /// </summary>
        /// <param name="id"></param>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found update entity exception</response>
        /// <response code="422">Wrong field format (f.e., Name string(50), Surname string(50))</response>
        /// <response code="500">Inner DB error</response>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}