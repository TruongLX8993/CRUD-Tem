using System;
using System.Linq.Expressions;
using Base.Specification;

namespace Customer.Application.Specifications
{
    public class CustomerSpecification : BaseSpecification<Domain.Entities.CustomerEntity>
    {
        private readonly string _name;
        private string _phone;

        public CustomerSpecification(string name, string phone)
        {
            _name = name;
            _phone = phone;
        }


        public override Expression<Func<Domain.Entities.CustomerEntity, bool>> IsSatisfied()
        {
            return cus => cus.Name.Contains(_name);
        }
    }
}