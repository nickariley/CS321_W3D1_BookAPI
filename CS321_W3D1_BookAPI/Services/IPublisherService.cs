using CS321_W3D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public interface IPublisherService
    {
        //Get all publishers
        IEnumerable<Publisher> GetAll();

        //Get publisher by id
        Publisher Get(int id);

        //Add a new publisher
        Publisher Add(Publisher newPublisher);

        //Update a publisher
        Publisher Update(Publisher updatedPublisher);

        //Delete a publisher
        void Delete(Publisher publisher);
    }
}
