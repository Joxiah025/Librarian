using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Librarian.Context;
using Librarian.Entities;
using Librarian.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Librarian.Repository.Implementation
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await GetAll().Include(x => x.BookDetail).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await GetAll().Include(x => x.BookDetail).ToListAsync();
        }
    }
}