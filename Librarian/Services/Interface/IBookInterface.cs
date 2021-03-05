using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Librarian.Entities;
using Librarian.Util;

namespace Librarian.Services
{
    public interface IBookInterface
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<Book> UpdateBookStatus(Guid id, BookStatus status);
    }
}