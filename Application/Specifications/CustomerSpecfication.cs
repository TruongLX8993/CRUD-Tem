using System;
using System.Linq.Expressions;
using Base.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class CustomerSpecification : BaseSpecification<Customer>
    {
        private readonly string _name;
        private string _phone;

        public CustomerSpecification(string name, string phone)
        {
            _name = name;
            _phone = phone;
        }


        public override Expression<Func<Customer, bool>> IsSatisfied()
        {
            return cus => cus.Name == _name;
        }
    }
}