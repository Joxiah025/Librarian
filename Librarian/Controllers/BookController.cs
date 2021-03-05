using System;
using System.Linq;
using System.Threading.Tasks;
using Librarian.Models;
using Librarian.Services;
using Librarian.Services.Interface;
using Librarian.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Librarian.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookInterface _book;
        private readonly IBookDetailInterface _bookDetail;

        public BookController(ILogger<HomeController> logger, IBookDetailInterface bookDetail, IBookInterface book)
        {
            _logger = logger;
            _book = book;
            _bookDetail = bookDetail;
        }
        // GET
        public async Task<IActionResult> Index(
            [FromQuery(Name = "NotFound")] bool NotFound, 
            [FromQuery(Name = "CheckOut")] bool CheckOut, 
            [FromQuery(Name = "CheckOutFailed")] bool CheckOutFailed,
            [FromQuery(Name = "CheckIn")] bool CheckIn
            )
        {
            if (NotFound)
                ViewBag.ErrorMessage = "Book was not found";

            if (CheckOut)
                ViewBag.Message = "Check out was successful";

            if (CheckOutFailed)
                ViewBag.ErrorMessage = "This book hasn't been checked in";

            if (CheckIn)
                ViewBag.Message = "Book was successfully checked in.";

            ViewBag.Books = await _book.GetAllBooks();
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            Guid.TryParse(id, out Guid data);
            var book = await _book.GetBookById(data);
            return Ok(book);
        }

        public async Task<IActionResult> CheckIn(string id)
        {
            Guid.TryParse(id, out Guid data);
            var book = await _book.GetBookById(data);
            if (book == null) return RedirectToAction("Index", new { NotFound = true });

            ViewBag.Book = book;
            ViewBag.Fined = false;
            var bookDetail = book.BookDetail.LastOrDefault();
            if (bookDetail != null) { 
                ViewBag.BookDetail = bookDetail;
                ViewBag.Fined = (bookDetail.ReturnDate < DateTime.Now) ? true : false;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn(CheckInViewModel model, string id)
        {
            Guid.TryParse(id, out Guid data);
            var book = await _book.GetBookById(data);
            ViewBag.Book = book;

            var result = await _bookDetail.CheckInBook(model);
            await _book.UpdateBookStatus(result.BookId, BookStatus.CheckIn);
            return Ok();
        }

        public async Task<IActionResult> CheckOut(string id)
        {
            Guid.TryParse(id, out Guid data);
            var book = await _book.GetBookById(data);
            if (book == null) return RedirectToAction("Index", new { NotFound = true });

            if (book.Status == BookStatus.CheckOut) return RedirectToAction("Index", new { CheckOutFailed = true });

            ViewBag.Book = book;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(CheckOutViewModel model, string id)
        {
            Guid.TryParse(id, out Guid data);
            var book = await _book.GetBookById(data);
            ViewBag.Book = book;
            ViewBag.Message = null;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isNumeric = Int64.TryParse(model.NationalId, out Int64 _);
            if (!isNumeric)
            {
                ModelState.AddModelError("NationalId", "Provide a valid 11 digit number");
                return View(model);
            }

             var result = await _bookDetail.CheckOutBook(model, data);
            await _book.UpdateBookStatus(result.BookId, BookStatus.CheckOut);
            return RedirectToAction("Index", new { CheckOut = true });
        }
    }
}