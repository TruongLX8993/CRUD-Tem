using Newtonsoft.Json;

namespace Base.Shared
{
    public class PagingInfo
    {
        [JsonProperty("page")] public int Page { get; set; }
        [JsonProperty("pageSize")] public int PageSize { get; set; }

        public PagingInfo(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public static PagingInfo CreateDefault() => new PagingInfo(0, 10);
    }
}