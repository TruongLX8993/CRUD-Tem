using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Base.Shared;
using Base.Specification;
using Customer.Infrastructure.Data.Extensions;
using NHibernate;

namespace Base.Queries
{
    public class BaseGenericQuery : IGenericQuery
    {
        private readonly IStatelessSession _statelessSession;

        public BaseGenericQuery(IStatelessSession statelessSession)
        {
            _statelessSession = statelessSession;
        }

        public async Task<Paging<T>> Get<D, T>(
            ISpecification<D> specification, Expression<Func<D, T>> selector, PagingInfo pagingInfo,
            CancellationToken cancellationToken)
        {
            var query = _statelessSession.Query<D>();
            query = query.Where(specification.IsSatisfied());
            pagingInfo ??= PagingInfo.CreateDefault();
            return await query.ToPage(pagingInfo.Page, pagingInfo.PageSize, selector, cancellationToken);
        }
    }
}