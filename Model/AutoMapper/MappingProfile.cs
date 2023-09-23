using AutoMapper;
using Model.CreateDtos;
using Model.Entities;
using Model.ReturnDtos;

namespace Model.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<Student,StudentCreateDto>();
            CreateMap<Student, StudentReturnDto>();

            CreateMap<Class, ClassCreateDto>();
            CreateMap<Class, ClassReturnDto>();
        }
    }
}
