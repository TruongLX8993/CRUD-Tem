using System;
using System.Linq;
using System.Linq.Expressions;

namespace Base.Specification
{
    public class AndSpecification<T> : BaseSpecification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }
        public override Expression<Func<T,bool>> IsSatisfied()
        {
            return Expression.Lambda<Func<T,bool>>(
             Expression.AndAlso(
                Expression.Invoke(_left.IsSatisfied()),
                Expression.Invoke(_right.IsSatisfied())
            ));
        }

    }
}