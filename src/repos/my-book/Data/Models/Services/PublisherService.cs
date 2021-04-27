using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using my_book.Data.ViewModels;
using my_book.Exceptions;

namespace my_book.Data.Models.Services
{
    public class PublisherService
    {
        private AppDbContext _appDbcontext;
        public PublisherService(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("Name starts with number",
              publisher.Name);
            var _publisher = (new Publisher()
            {
                Name = publisher.Name
            });
            _appDbcontext.Publishers.Add(_publisher);
            _appDbcontext.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id) =>
            _appDbcontext.Publishers.FirstOrDefault(x => x.Id == id);

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
            else
            {
                throw new Exception($"The publisher id {id} does not exist!!!");
            }
        }

        private bool StringStartsWithNumber(string name)
        {
            return Regex.IsMatch(name, @"^\d");
        }
    }
}