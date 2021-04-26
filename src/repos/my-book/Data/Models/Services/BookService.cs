using System;
using System.Collections.Generic;
using System.Linq;
using my_book.Data.ViewModels;

namespace my_book.Data.Models.Services
{
    public class BookService
    {
        private AppDbContext _appDbContext;
        public BookService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _appDbContext.Add(_book);
            _appDbContext.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _appDbContext.Books.ToList();
            return allBooks;
        }

        public Book GetBookById(int id)
        {
            var allBooks = _appDbContext.Books.FirstOrDefault(x => x.Id == id);
            return allBooks;
        }

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _appDbContext.Books.FirstOrDefault(x => x.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
                _book.DateAdded = DateTime.Now;

                _appDbContext.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _appDbContext.Books.FirstOrDefault(x => x.Id == bookId);
            if (_book != null)
            {
                _appDbContext.Books.Remove(_book);
                _appDbContext.SaveChanges();
            }
        }
    }
}