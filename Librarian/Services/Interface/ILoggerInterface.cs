using Librarian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Services.Interface
{
    public interface ILoggerInterface
    {
        Task<Entities.Exception> LogToDb(ExceptionViewModel exception);
    }
}
