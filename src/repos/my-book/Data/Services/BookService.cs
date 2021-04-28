using System;
using System.Collections.Generic;
using System.Linq;
using my_book.Data.Models;
using my_book.Data.ViewModels;

namespace my_book.Data.Services
{
    public class BookService
    {
        private AppDbContext _appDbContext;
        public BookService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _appDbContext.Books.Add(_book);
            _appDbContext.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _appDbContext.Books_Authors.Add(_book_author);
                _appDbContext.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _appDbContext.Books.ToList();
            return allBooks;
        }

        public BookWithAuthorsVM GetBookById(int id)
        {
            var _bookWithAuthors = _appDbContext.Books.Where(x => x.Id == id).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(x => x.Author.Name).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
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