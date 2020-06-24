using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly AppDbContext _appDbContext;

        public PublisherService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Publisher Add(Publisher newPublisher)
        {
            _appDbContext.Publishers.Add(newPublisher);
            _appDbContext.SaveChanges();
            return newPublisher;
        }

        public void Delete(Publisher publisher)
        {
            var currentPublisher = _appDbContext.Publishers.FirstOrDefault(a => a.Id == publisher.Id);
            if (currentPublisher != null)
            {
                _appDbContext.Publishers.Remove(publisher);
                _appDbContext.SaveChanges();
            }
        }

        public Publisher Get(int id)
        {
            var publisher = _appDbContext.Publishers.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
            return publisher;
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _appDbContext.Publishers.Include(a => a.Books);
        }

        public Publisher Update(Publisher updatedPublisher)
        {
            var currentPublisher = _appDbContext.Publishers.FirstOrDefault(a => a.Id == updatedPublisher.Id);
            if (currentPublisher != null)
            {
                _appDbContext.Publishers.Update(updatedPublisher);
                _appDbContext.SaveChanges();
                return currentPublisher;
            }
            return null;
        }
    }
}
