using Librarian.Context;
using Librarian.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Repository.Implementation
{
    public class LoggerRepository : BaseRepository<Entities.Exception>, ILoggerRepository
    {
        public LoggerRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
