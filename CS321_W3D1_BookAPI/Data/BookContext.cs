using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Data
{
    public class BookContext : DbContext
    {
        DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder myBuilder)
        {
            myBuilder.UseSqlite("Data Source=Books.db");
        }

        protected override void OnModelCreating(ModelBuilder myModelBuilder)
        {
            base.OnModelCreating(myModelBuilder);

            myModelBuilder.Entity<Book>().HasData(
                new Book { Title = "Test Title 1", Author = "Author1", Category = "Fantasy" },
                new Book { Title = "Test Title 2", Author = "Author2", Category = "Fantasy" },
                new Book { Title = "Test Title 3", Author = "Author3", Category = "Fantasy" }
                );
        }
    }
}
