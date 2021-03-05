using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Librarian.Entities;
using Librarian.Repository.Interface;
using Librarian.Util;

namespace Librarian.Services
{
    public class BookService : IBookInterface
    {
        private readonly IBookRepository _book;
        private readonly IMapper _mapper;

        public BookService(IBookRepository book, IMapper mapper)
        {
            _book = book;
            _mapper = mapper;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _book.GetAllBooksAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _book.GetBookByIdAsync(id);
        }

        public async Task<Book> UpdateBookStatus(Guid id, BookStatus status)
        {
            var book = await _book.GetBookByIdAsync(id);
            book.Status = status;
            return await _book.UpdateAsync(book);
        }
    }
}