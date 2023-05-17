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
        public string Title { get; set; }
        public string Description { get; set; }  
        public DateTime DateLeave { get; set; }
        public DateTime DateExp { get; set; }
        public Guid AuthorID { get; set; }
        public Author Author { get; set; } = null!;
    }
}
