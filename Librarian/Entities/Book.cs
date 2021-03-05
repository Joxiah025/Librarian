using Librarian.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace Librarian.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string BookTitle { get; set; }
        public string PublishedYear { get; set; }
        public decimal CoverPrice { get; set; }
        public string ISBN { get; set; }
        public BookStatus Status { get; set; }
        public ICollection<BookDetail> BookDetail { get; set; }
        public DateTime DateCreated { get; set; }

        public Book()
        {
            BookDetail = new System.Collections.ObjectModel.Collection<BookDetail>();
            DateCreated = DateTime.Now;
        }

        public static void ConfigureModel(ModelBuilder builder)
        {
            builder
                .Entity<Book>()
                .Property(e => e.Status)
                .HasConversion(new EnumToStringConverter<BookStatus>());
            builder.Entity<Book>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }

    }
}