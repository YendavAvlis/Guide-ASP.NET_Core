using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_book.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public List<Book_Author> Book_Authors { get; set; }
    }
}