using Domain.Entities;
using FluentNHibernate.Mapping;

namespace Infrastructure.Data.Mappers
{
    public class CustomerMapper : ClassMap<CustomerEntity>
    {
        public CustomerMapper()
        {
            Id(cus => cus.Id);
            Map(cus => cus.Name);
            Map(cus => cus.Phone);
            Table("Customer");
        }
    }
} 