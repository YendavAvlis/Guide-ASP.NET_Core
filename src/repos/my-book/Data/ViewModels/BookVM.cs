using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_book.Data.ViewModels
{
    public class BookVM
    {
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

        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }

    public class BookWithAuthorsVM
    {
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

        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}