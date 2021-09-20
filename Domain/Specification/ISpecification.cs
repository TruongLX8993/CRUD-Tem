using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Specification
{
    public interface ISpecification<T>
    { 
        Expression<Func<T,bool>> IsSatisfied();
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
    }
}