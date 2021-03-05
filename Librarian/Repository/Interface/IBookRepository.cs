using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Librarian.Entities;

namespace Librarian.Repository.Interface
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookByIdAsync(Guid id);
        Task<List<Book>> GetAllBooksAsync();
    }
}