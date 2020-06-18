using CS321_W3D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public interface IAuthorService
    {
        //Get all books
        IEnumerable<Author> GetAll();

        //Get book by id
        Author Get(int id);

        //Add a new author
        Author Add(Author newBook);

        //Update an author
        Author Update(Author updatedAuthor);

        //Delete an author
        void Delete(Author author);
    }
}
