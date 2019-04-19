using AutoMapper;
using Library.Domain.Dto;
using Library.Domain.Entities;

namespace Library.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
