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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;
        public BookController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the list of all Books with all information about Author and Borrows data
        /// </summary>        
        /// <returns> IList of Book </returns>        
        /// <response code="401">The user is unauthorized</response>
        /// <response code="500">Inner DB error</response>
        [HttpGet]
        public async Task<ActionResult<BookList>> GetAll()
        {
            var query = new GetBooksShortQuery();
            var books = await Mediator.Send(query);
            return Ok(books);
        }

        /// <summary>
        /// Get the list of short Books data {"id", "title", "full author name"}
        /// </summary>        
        /// <returns> IList of Book </returns>        
        /// <response code="401">The user is unauthorized</response>
        /// <response code="500">Inner DB error</response>
        [HttpGet("short")]
        public async Task<ActionResult<BookList>> GetShortData()
        {
            var query = new GetBooksShortQuery();
            var books = await Mediator.Send(query);
            return Ok(books);
        }

        /// <summary>
        /// Get Book data by Id
        /// </summary>
        /// <returns> Book {} </returns>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found  entity exception</response>
        /// <response code="422">Wrong field format</response>
        /// <response code="500">Inner DB error</response>
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

        /// <summary>
        /// Get Book data by IBAN
        /// </summary>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found entity exception</response>
        /// <response code="422">Wrong field format</response>
        /// <response code="500">Inner DB error</response>
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

        /// <summary>
        /// Add new Book 
        /// </summary>
        /// <remarks>
        /// {"iban": "123456789-134",
        /// "title": "Fairy tale",
        /// "genre": 0,
        /// "description": "fairy tales",
        /// "authorId": "914c29b0-8a4d-401a-a337-f25f38d6d5cc"}
        /// </remarks>
        /// <response code="400">There's not required field (IBAN, Title, AuthorId)</response>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found update entity exception</response>
        /// <response code="422">Wrong field format (f.e., IBAN string(17), Title string(250), AuthorId Guid)</response>
        /// <response code="500">Inner DB error</response>
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
        /// <summary>
        /// Update existing Book 
        /// </summary>
        /// <remarks>
        /// {"id": "115152ab-5fe4-4807-8186-8aa48e5ac725"
        /// "iban": "123456789-134",
        /// "title": "Fairy tale",
        /// "genre": 0,
        /// "description": "fairy tales",
        /// "authorId": "914c29b0-8a4d-401a-a337-f25f38d6d5cc"}
        /// </remarks>
        /// <response code="400">There's not required field (IBAN, Title, AuthorId)</response>
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found update entity exception</response>
        /// <response code="422">Wrong field format (f.e., IBAN string(17), Title string(250), AuthorId Guid)</response>
        /// <response code="500">Inner DB error</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book book)
        {
            await Mediator.Send(new UpdateBookCommand
            {
                Id = book.Id,
                IBAN = book.IBAN,
                Title = book.Title,
                Genre = book.Genre,
                Description = book.Description,
                AuthorId = book.AuthorId
            });

            return NoContent();
        }
        /// <summary>
        /// Delete Book 
        /// </summary>      
        /// <response code="401">The user is unauthorized</response>
        /// <response code="404">Not found update entity exception</response>
        /// <response code="422">Wrong field format</response>
        /// <response code="500">Inner DB error</response>
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
