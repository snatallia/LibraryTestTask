using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;

namespace Library.Application.Books.Dtos
{
    public class BookDto : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorFullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDto>()
                .ForMember(bookDto => bookDto.Title,
                    opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.AuthorFullName,
                    opt => opt.MapFrom(book => $"{book.Author.Name} {book.Author.Surname}"));
        }
    }

    public class BookList
    { 
        public IList<BookDto> Books { get; set; }
    }
}
