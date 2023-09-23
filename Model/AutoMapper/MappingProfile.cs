using AutoMapper;
using Model.CreateDtos;
using Model.Entities;
using Model.ReturnDtos;
using Model.ReturnDtos.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductReturnDto>();

            CreateMap<Student,StudentCreateDto>();
            CreateMap<Student, StudentReturnDto>();

            CreateMap<Class, ClassCreateDto>();
            CreateMap<Class, ClassReturnDto>();
        }
    }
}
