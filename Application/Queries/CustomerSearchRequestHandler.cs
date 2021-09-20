﻿using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Application.Specifications;
using Base.Queries;
using Base.Shared;
using MediatR;
using Newtonsoft.Json;

namespace Application.Queries
{
    public class CustomerSearchRequest : IRequest<Paging<CustomerSearchItem>>
    {
        [JsonProperty("phone")] public string Phone { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("pageInfo")] public PagingInfo PagingInfo { get; set; }
        public CustomerSpecification GetSpecification() => new CustomerSpecification(Name, Phone);
    }

    public class CustomerSearchItem
    {
        public string Name { get; set; }
    }


    public class CustomerSearchRequestHandler : IRequestHandler<CustomerSearchRequest, Paging<CustomerSearchItem>>
    {
        private readonly IGenericQuery _genericQuery;

        public CustomerSearchRequestHandler(IGenericQuery genericQuery)
        {
            _genericQuery = genericQuery;
        }

        public async Task<Paging<CustomerSearchItem>> Handle(
            CustomerSearchRequest request, CancellationToken cancellationToken)
        {
            return await _genericQuery.Get(request.GetSpecification(), item => new CustomerSearchItem()
            {
                Name = item.Name
            }, request.PagingInfo, cancellationToken);
        }
    }
}