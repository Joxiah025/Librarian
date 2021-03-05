using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Entities
{
    public class BookDetail
    {
        public BookDetail()
        {
            CheckOutDate = DateTime.Now;
            // ReturnDate = DateTime.Now.AddDays(15); // Exclude Weekends and Holidays
        }

        public Guid Id { get; set; }
        public string BorrowerName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public bool Fine { get; set; }
        public Guid BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
