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
    }
}