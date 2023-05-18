namespace Library.Domain
{
    public enum GenreNames
    {
        NoGenre,
        Fantasy,
        Adventure,
        Romance,
        Contemporary,
        Dystopian,
        Mystery,
        Horror,
        Thriller,
        Paranormal,
        Historical,
        Science
    }

    public class Book
    {
        public Guid Id { get; set; }
        public string IBAN { get; set; }
        public string Title { get; set; }
        public GenreNames Genre { get; set; }
        public string Description { get; set; }       
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<Borrow> Borrows { get; set; }
    }
}
