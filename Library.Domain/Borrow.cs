namespace Library.Domain
{
    public class Borrow
    {
        public Guid Id { get; set; }        
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
