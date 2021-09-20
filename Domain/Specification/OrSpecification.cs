using System;
using System.Linq.Expressions;

namespace Domain.Specification
{
    public class OrSpecification<T> : BaseSpecification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }
        public override Expression<Func<T, bool>> IsSatisfied()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(_left.IsSatisfied(), _right.IsSatisfied()));
        }
    }
}