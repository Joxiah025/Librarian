using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Models
{
    public class CheckInViewModel
    {
        public string BookDetailId { get; set; }
        public string BookId { get; set; }
        public bool Fine { get; set; }
    }
}
