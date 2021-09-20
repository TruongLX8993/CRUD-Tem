using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using Domain.Specification;
using Infrastructure.Data.Extensions;
using NHibernate;
using IQuery = Application.Queries.IQuery;

namespace Infrastructure.Data.Queries
{
    public class BaseQuery: IQuery
    {
        public async Task<Paging<T>> Get<D, T>(ISpecification<D> specification, Expression<Func<D, T>> selector, PagingInfo pagingInfo)
        {
            var query = _statelessSession.Query<D>();
            query = query.Where(specification.IsSatisfied());
            return await query.ToPage( pagingInfo.Page, pagingInfo.PageSize, selector);
        }
        
        private readonly IStatelessSession _statelessSession;

        public BaseQuery(IStatelessSession statelessSession)
        {
            _statelessSession = statelessSession;
        }

    }
}