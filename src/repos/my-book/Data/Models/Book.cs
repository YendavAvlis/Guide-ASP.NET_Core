using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_book.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The book must have a name.")]
        [MaxLength(60, ErrorMessage = "You cannot exceed 60 characters")]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        [Range(0, 10, ErrorMessage = "The rate goes from 0 to 10")]
        public int? Rate { get; set; }
        public string Genre { get; set; }
        [MaxLength(60, ErrorMessage = "You cannot exceed 60 characters")]
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        //Navigation Properties
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Author> Book_Authors { get; set; }

    }
}