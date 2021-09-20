using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Base.Domain;
using Base.Repositories;
using Base.Specification;
using NHibernate;
using NHibernate.Linq;

namespace Customer.Infrastructure.Data.Repository
{
    public class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        public BaseRepository(ISession session)
        {
            _session = session;
        }

        private readonly ISession _session;


        public async Task<TKey> Save(TEntity entity, CancellationToken cancellationToken)
        {
            await _session.SaveOrUpdateAsync(entity, cancellationToken);
            return entity.Id;
        }

        public async Task<TEntity> GetById(TKey id, CancellationToken cancellationToken)
        {
            return await _session.GetAsync<TEntity>(id, cancellationToken);
        }

        public async Task Delete(TEntity entity, CancellationToken cancellationToken)
        {
            await _session.DeleteAsync(entity, cancellationToken);
        }

        public async Task<IList<TEntity>> Get(ISpecification<TEntity> specification)
        {
            var queryable = _session.Query<TEntity>().Where(specification.IsSatisfied());
            return await queryable.ToListAsync();
        }
    }
}