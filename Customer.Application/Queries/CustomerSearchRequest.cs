using System.Threading;
using System.Threading.Tasks;
using Base.Application;
using Base.Queries;
using Base.Shared;
using Customer.Application.Specifications;
using Newtonsoft.Json;

namespace Customer.Application.Queries
{
    public class CustomerSearchRequest : SearchRequest<CustomerSearchItem>
    {
        [JsonProperty("phone")] public string Phone { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        public CustomerSpecification GetSpecification() => new CustomerSpecification(Name, Phone);
    }

    public class CustomerSearchItem
    {
        public string Name { get; set; }
    }


    
    public class CustomerSearchRequestHandler : SearchRequestHandler<CustomerSearchRequest,CustomerSearchItem>
    {
        private readonly IGenericQuery _genericQuery;

        public CustomerSearchRequestHandler(IGenericQuery genericQuery)
        {
            _genericQuery = genericQuery;
        }

        public async Task<Paging<CustomerSearchItem>> Handle(CustomerSearchRequest request, CancellationToken cancellationToken)
        {
            return await _genericQuery.Get(request.GetSpecification(), item => new CustomerSearchItem()
            {
                Name = item.Name
            }, request.GetPagingInfo(), cancellationToken);
        }
    }
}