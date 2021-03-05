using AutoMapper;
using FluentDateTime;
using Librarian.Entities;
using Librarian.Models;
using Librarian.Repository.Interface;
using Librarian.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Services.Implementation
{
    public class BookDetailService : IBookDetailInterface
    {
        private readonly IMapper _mapper;
        private readonly IBookDetailRepository _book;
        public BookDetailService(IMapper mapper, IBookDetailRepository book)
        {
            _mapper = mapper;
            _book = book;
        }
        public async Task<BookDetail> CheckInBook(CheckInViewModel model)
        {
            Guid.TryParse(model.BookDetailId, out Guid bookDetailId);
            var result = await _book.GetBookById(bookDetailId);
            result.ActualReturnDate = DateTime.Now;
            result.Fine = model.Fine;
            return await _book.UpdateAsync(result);
        }

        public async Task<BookDetail> CheckOutBook(CheckOutViewModel model, Guid id)
        {
            var bookDetail = _mapper.Map<BookDetail>(model);
            bookDetail.BookId = id;
            bookDetail.ReturnDate = DateTime.Now.AddBusinessDays(15);
            return await _book.AddAsync(bookDetail);
        }
    }
}
