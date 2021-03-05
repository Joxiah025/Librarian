using Librarian.Entities;
using Librarian.Models;
using System;
using System.Threading.Tasks;

namespace Librarian.Services.Interface
{
    public interface IBookDetailInterface
    {
        Task<BookDetail> CheckInBook(CheckInViewModel model);
        Task<BookDetail> CheckOutBook(CheckOutViewModel model, Guid id);
    }
}
