using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Queries;
using NHibernate.Linq;

namespace Infrastructure.Data.Extensions
{
    public static class IQueryableExtension
    {
        public static async Task<Paging<P>> ToPage<T, P>(this IQueryable<T> queryable,
            int page,
            int size,
            Expression<Func<T, P>> selector)
        {
            var total = await queryable.CountAsync();
            queryable = queryable.Skip(page * size);
            var data = await queryable.Select(selector).ToListAsync();
            return new Paging<P>()
            {
                Total = total,
                Data = data,
                Page = page,
                PageSize = size
            };
        }
    }
}