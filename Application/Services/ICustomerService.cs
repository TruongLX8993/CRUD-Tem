using System.Threading.Tasks;
using Application.DTOs;
using Base.Queries;

namespace Application.Services
{
    public interface ICustomerService
    {
        Task CreateCustomer(CreateCustomerDTO createCustomerDto);
        Task<Paging<CustomerListItemDTO>> Search(CustomerSearchDTO customerSearchDto);
    }
}