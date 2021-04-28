using System.Collections.Generic;
using System.Linq;
using my_book.Data.Models;
using my_book.Data.ViewModels;

namespace my_book.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _appDbcontext;
        public AuthorService(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = (new Author()
            {
                Name = author.Name
            });
            _appDbcontext.Authors.Add(_author);
            _appDbcontext.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _appDbcontext.Authors.Where(x => x.Id == authorId).Select(x => new AuthorWithBooksVM()
            {
                Name = x.Name,
                BookTitles = x.Book_Authors.Select(x => x.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}