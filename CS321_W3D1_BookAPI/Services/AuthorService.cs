using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _bookContext;

        public AuthorService(BookContext myContext)
        {
            _bookContext = myContext;
        }

        public Author Add(Author newAuthor)
        {
            _bookContext.Authors.Add(newAuthor);
            _bookContext.SaveChanges();
            return newAuthor;
        }

        public void Delete(Author author)
        {
            var currentAuthor = _bookContext.Authors.FirstOrDefault(a => a.Id == author.Id);
            if (currentAuthor != null)
            {
                _bookContext.Authors.Remove(author);
                _bookContext.SaveChanges();
            }
        }

        public Author Get(int id)
        {
            var author = _bookContext.Authors.FirstOrDefault(a => a.Id == id);
            return author;
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookContext.Authors;
        }

        public Author Update(Author updatedAuthor)
        {
            var currentAuthor = _bookContext.Authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
            if (currentAuthor != null)
            {
                _bookContext.Authors.Update(updatedAuthor);
                _bookContext.SaveChanges();
                return currentAuthor;
            }
            return null;
        }
    }
}
