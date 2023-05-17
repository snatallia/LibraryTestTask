namespace Library.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string IBAN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<Borrow> Borrows { get; set; }
    }
}
