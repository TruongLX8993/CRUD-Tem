using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Base.Shared;
using Base.Specification;

namespace Base.Queries
{

    public interface IGenericQuery
    {
        Task<Paging<T>> Get<D, T>(
            ISpecification<D> specification, Expression<Func<D, T>> selector, PagingInfo pagingInfo,CancellationToken cancellationToken);
    }
}