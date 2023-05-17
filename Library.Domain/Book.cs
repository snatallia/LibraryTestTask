using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public int IBAN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }  
        public DateTime? DateBorrow { get; set; }
        public DateTime? DateReturn { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
