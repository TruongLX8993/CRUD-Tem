using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Base.Queries;
using Base.Shared;
using NHibernate.Linq;

namespace Infrastructure.Data.Extensions
{
    public static class IQueryableExtension
    {
        public static async Task<Paging<P>> ToPage<T, P>(this IQueryable<T> queryable,
            int page,
            int size,
            Expression<Func<T, P>> selector,CancellationToken cancellationToken)
        {
            var total = await queryable.CountAsync(cancellationToken);
            queryable = queryable.Skip(page * size);
            var data = await queryable.Select(selector).ToListAsync(cancellationToken);
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