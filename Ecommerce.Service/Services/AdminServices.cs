using AutoMapper;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Interfaces;
using Ecommerce.Service.DTOs.ResponceDTOs;
using Ecommerce.Service.Interfaces;

namespace Ecommerce.Service.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public AdminServices(IRepository<Customer> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<GenericApiResponceDTO<List<CustomerListDTO?>>> GetAllCustomers()
        {
           var data=await _repository.GetAllAsync();
            if (data == null) {
                return new GenericApiResponceDTO<List<CustomerListDTO>>
                {
                 Message="No Customers",
                 Success=false,
                 Data=null
                };
            }
            return new GenericApiResponceDTO<List<CustomerListDTO?>>
            {
                Message="Request Success",
                Data=_mapper.Map<List<CustomerListDTO>>(data),
                Success=true,
            };
        }
    }
}
