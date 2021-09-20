using System;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services;
using Base.Queries;

namespace Application.ServiceImpl
{
    public class CustomerServiceImpl : ICustomerService
    {
        public Task CreateCustomer(CreateCustomerDTO createCustomerDto)
        {
            throw new NotImplementedException();
        }

        public Task<Paging<CustomerListItemDTO>> Search(CustomerSearchDTO customerSearchDto)
        {
            throw new NotImplementedException();
        }
    }
}