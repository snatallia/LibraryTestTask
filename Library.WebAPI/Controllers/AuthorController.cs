﻿using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Authors.Commands.DeleteAuthor;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Application.Authors.Queries.GetAuthorById;
using Library.Application.Authors.Queries.GetAuthors;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    public class AuthorController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IList<Author>>> GetAll()
        {
            var query = new GetAuthorsQuery();
            var authors = await Mediator.Send(query);
            return Ok(authors);
        }

        [HttpGet("{id}")]
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
