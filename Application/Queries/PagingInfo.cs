namespace Application.Queries
{
    public class PagingInfo
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PagingInfo(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}