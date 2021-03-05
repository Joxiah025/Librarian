using Librarian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Repository.Interface
{
    public interface IBookDetailRepository : IRepository<BookDetail>
    {
        Task<BookDetail> GetBookById(Guid id);
    }
}
