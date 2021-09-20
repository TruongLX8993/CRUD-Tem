using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Base.Domain;
using Base.Specification;

namespace Base.Repositories
{
    public interface IRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        Task<TKey> Save(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> GetById(TKey id, CancellationToken cancellationToken);
        Task Delete(TEntity entity, CancellationToken cancellationToken);
        Task<IList<TEntity>> Get(ISpecification<TEntity> specification);
    }
}