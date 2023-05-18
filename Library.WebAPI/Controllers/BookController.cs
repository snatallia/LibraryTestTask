using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Books.Dtos;
using Library.Application.Books.Queries.GetBookDetailsByIBAN;
using Library.Application.Books.Queries.GetBookDetailsById;
using Library.Application.Books.Queries.GetBooks;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;
        public BookController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<BookList>> GetAll()
        {
            var query = new GetBooksQuery();
            var books = await Mediator.Send(query);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailDto>> GetById(Guid id)
        {
            var query = new GetBookDetailsByIdQuery
            {
                Id = id
            };
            var book = await Mediator.Send(query);
            return Ok(book);
        }

        [HttpGet("iban/{iban}")]
        public async Task<ActionResult<BookDetailDto>> GetByIBAN(string iban)
        {
            var query = new GetBookDetailsByIBANQuery
            {
                IBAN = iban
            };
            var book = await Mediator.Send(query);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] Book newBook)
        {
            var bookiD = await Mediator.Send(new CreateBookCommand
            {
                IBAN = newBook.IBAN,
                Title = newBook.Title,
                Genre = newBook.Genre,
                Description = newBook.Description,
                AuthorId = newBook.AuthorId
            });

            return bookiD;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book newBook)
        {
            await Mediator.Send(new UpdateBookCommand
            {
                Id = newBook.Id,
                IBAN = newBook.IBAN,
                Title = newBook.Title,
                Genre = newBook.Genre,
                Description = newBook.Description,
                AuthorId = newBook.AuthorId
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
