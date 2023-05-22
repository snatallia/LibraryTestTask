using AutoMapper;
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
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IList<Author>>> GetAll()
        {
            var query = new GetAuthorsQuery();
            var authors = await Mediator.Send(query);
            return Ok(authors);
        }

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