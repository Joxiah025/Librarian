using Librarian.Context;
using Librarian.Entities;
using Librarian.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Librarian.Repository.Implementation
{
    public class BookDetailRepository : BaseRepository<BookDetail>, IBookDetailRepository
    {
        public BookDetailRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<BookDetail> GetBookById(Guid id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
