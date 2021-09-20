using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Base.Queries;
using Base.Specification;
using Infrastructure.Data.Extensions;
using NHibernate;

namespace Infrastructure.Data.Queries
{
    public class BaseGenericQuery: Base.Queries.IGenericQuery
    {
        public async Task<Paging<T>> Get<D, T>(ISpecification<D> specification, Expression<Func<D, T>> selector, PagingInfo pagingInfo)
        {
            var query = _statelessSession.Query<D>();
            query = query.Where(specification.IsSatisfied());
            return await query.ToPage( pagingInfo.Page, pagingInfo.PageSize, selector);
        }
        
        private readonly IStatelessSession _statelessSession;

        public BaseGenericQuery(IStatelessSession statelessSession)
        {
            _statelessSession = statelessSession;
        }
        
    }
}