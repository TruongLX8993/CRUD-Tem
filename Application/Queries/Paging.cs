using System.Collections.Generic;

namespace Application.Queries
{
    public class Paging<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IList<T> Data { get; set; }
    }
}