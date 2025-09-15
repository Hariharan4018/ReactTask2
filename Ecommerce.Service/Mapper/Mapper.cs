using AutoMapper;
using Ecommerce.DAL.Entities;
using Ecommerce.Service.DTOs.RequestDTOs;
using Ecommerce.Service.DTOs.ResponceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerRegisterDTO, Customer>();
            CreateMap<Customer, ResponseDTO>();
        }
    }
}
