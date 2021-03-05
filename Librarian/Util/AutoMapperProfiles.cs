using AutoMapper;
using Librarian.Entities;
using Librarian.Models;

namespace Librarian.Util
{
    public class AutoMapperProfiles : Profile
    { 
        public AutoMapperProfiles()
        {
            CreateMap<CheckOutViewModel, BookDetail>();
            CreateMap<ExceptionViewModel, Entities.Exception>();
        }
    }
}
