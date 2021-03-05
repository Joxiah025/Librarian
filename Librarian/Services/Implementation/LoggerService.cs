using AutoMapper;
using Librarian.Models;
using Librarian.Repository.Interface;
using Librarian.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Services.Implementation
{
    public class LoggerService : ILoggerInterface
    {
        private readonly ILoggerRepository _logger;
        private readonly IMapper _mapper;
        public LoggerService(ILoggerRepository logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Entities.Exception> LogToDb(ExceptionViewModel exception)
        {
            var error = _mapper.Map<Entities.Exception>(exception);
            return await _logger.AddAsync(error);
        }
    }
}
