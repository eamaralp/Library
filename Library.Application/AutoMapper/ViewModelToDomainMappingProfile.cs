using AutoMapper;
using Library.Domain.Dto;
using Library.Domain.Entities;

namespace Library.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BookDto, Book>();
        }
    }
}
