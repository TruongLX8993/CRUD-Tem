using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Base.Shared;
using MediatR;
using Newtonsoft.Json;

namespace Application.Queries
{
    public class ProductSearchRequest : SearchRequest<ProductItemDto>
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("fromPrice")] public decimal? fromPrice { get; set; }
        [JsonProperty("toPrice")] public decimal? toPrice { get; set; }
    }

    public class ProductSearchRequestHandler : SearchRequestHandler<ProductSearchRequest, ProductItemDto>
    {
        public Task<Paging<ProductItemDto>> Handle(ProductSearchRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}