using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string OriginalLanguage { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        
        public int PublisherId { get; set; }

        
        public Publisher Publisher { get; set; }
    }
}
