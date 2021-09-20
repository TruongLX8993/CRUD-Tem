using System;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Specification;

namespace Application.Specifications
{
    public class CustomerSpecification : BaseSpecification<CustomerEntity>
    {
        private readonly string _name;
        private string _phone;

        public CustomerSpecification(string name, string phone)
        {
            _name = name;
            _phone = phone;
        }


        public override Expression<Func<CustomerEntity, bool>> IsSatisfied()
        {
            return cus => cus.Name == _name;
        }
    }
}