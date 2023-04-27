using AutoMapper;
using Recobookation.Domain;

namespace Recobookation.App.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, Book>();
        }
    }
}