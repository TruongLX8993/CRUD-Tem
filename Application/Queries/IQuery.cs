using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Base.Specification;

namespace Application.Queries
{
    public interface IQuery
    {
        Task<Paging<T>> Get<D, T>(
            ISpecification<D> specification, Expression<Func<D, T>> selector, PagingInfo pagingInfo);
    }
}