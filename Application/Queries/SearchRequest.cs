using Base.Shared;
using Base.Specification;
using MediatR;
using Newtonsoft.Json;

namespace Application.Queries
{
    public abstract class SearchRequest<T> : IRequest<Paging<T>>
    {
        [JsonProperty("pagingInfo")] public PagingInfo PagingInfo { private get; set; }
        public PagingInfo GetPagingInfo() => PagingInfo ?? PagingInfo.CreateDefault();
    }

    public interface SearchRequestHandler<Req, T> : IRequestHandler<Req, Paging<T>> where Req : SearchRequest<T>
    {
    }
}