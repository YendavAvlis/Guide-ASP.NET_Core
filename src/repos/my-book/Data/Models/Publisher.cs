using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_book.Data.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public List<Book> Books { get; set; }
    }
}