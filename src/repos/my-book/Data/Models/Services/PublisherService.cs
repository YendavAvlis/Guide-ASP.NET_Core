using System;
using System.Collections.Generic;
using System.Linq;
using my_book.Data.ViewModels;

namespace my_book.Data.Models.Services
{
    public class PublisherService
    {
        private AppDbContext _appDbcontext;
        public PublisherService(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = (new Publisher()
            {
                Name = publisher.Name
            });
            _appDbcontext.Publishers.Add(_publisher);
            _appDbcontext.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _appDbcontext.Publishers.Where(x => x.Id == publisherId)
                .Select(x => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = x.Name,
                    BookAuthors = x.Books.Select(x => new BookAuthorVM()
                    {
                        BookName = x.Title,
                        BookAuthors = x.Book_Authors.Select(x => x.Author.Name).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _appDbcontext.Publishers.FirstOrDefault(x => x.Id == id);
            if (_publisher != null)
            {
                _appDbcontext.Publishers.Remove(_publisher);
                _appDbcontext.SaveChanges();
            }
        }
    }
}