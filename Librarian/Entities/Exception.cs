using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Entities
{
    public class Exception
    {
        public Guid Id { get; set; }
        public string ExceptionMsg { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionURL { get; set; }
        public DateTime Logdate { get; set; }

        public Exception()
        {
            Logdate = DateTime.Now;
        }
                

    }
}
