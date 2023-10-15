<h1>Library WebAPI</h1>
<b>Clean architecture</b> <br/>
.Net 6, EntityFrameworkCore, SQLite, Fluent API, FluentValidation, AutoMapper, MediatR + CQRS, Swagger, JWTBearer

WebAPI allows:
*	get full list of books with authors and book borrowing data
*	get short list of books (book title, author's name+surname )
*	get book data by Id
*	get book data by IBAN
*	change borrowing data
*	delete book data
*	add, edit and delete author's data
*	add, edit and delete borrowing data
  Model: entities **Book, Author, Borrow**

Run project (dotnet run), open in browser link https://localhost:7755/index.html 

For working with part API requests (except authentication requests /api/Authenticate) authentication is required using a bearer token. 
