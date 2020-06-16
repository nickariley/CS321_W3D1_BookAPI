﻿// <auto-generated />
using CS321_W3D1_BookAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS321_W3D1_BookAPI.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CS321_W3D1_BookAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Author1",
                            Category = "Fantasy",
                            Title = "Test Title 1"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Author2",
                            Category = "Fantasy",
                            Title = "Test Title 2"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Author3",
                            Category = "Fantasy",
                            Title = "Test Title 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
