using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;

namespace Library.Application.Books.Dtos
{
    public class BookDetailDto: IMapWith<Book>
    {
        public string IBAN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LastDateBorrow { get; set; }
        public DateTime? LastDateReturn { get; set; }
        public string AuthorFullName { get; set; }

        public void Mapping(Profile profile)
        {  
            profile.CreateMap<Book, BookDetailDto>()                
                .ForMember(bookDto => bookDto.IBAN,
                    opt => opt.MapFrom(book => book.IBAN))
                .ForMember(bookDto => bookDto.Title,
                    opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.Description,
                    opt => opt.MapFrom(book => book.Description))
                .ForMember(bookDto => bookDto.LastDateBorrow,
                    opt => opt.MapFrom(book => book.Borrows != null ? book.Borrows.LastOrDefault().DateBorrow: (DateTime?)null))
                .ForMember(bookDto => bookDto.LastDateReturn,
                    opt => opt.MapFrom(book => book.Borrows != null ? book.Borrows.LastOrDefault().DateReturn: (DateTime?)null))
                .ForMember(bookDto => bookDto.AuthorFullName,
                    opt => opt.MapFrom(book => $"{book.Author.Name} {book.Author.Surname}"));
        }
    }
}
