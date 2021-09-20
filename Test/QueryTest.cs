using System.Threading.Tasks;
using Application.DTOs;
using Application.Specifications;
using Base.Queries;
using Domain.Entities;
using Infrastructure.Config;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class QueryTest
    {
        private ServiceProvider _serviceProvider;

        [OneTimeSetUp]
        public void SetUp()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigInfra(
                "data source=103.74.123.8;initial catalog=rwtfgrxz_motor;user id=rwtfgrxz_sa;password=Motor@123;MultipleActiveResultSets=True;");
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Test]
        public async Task Test()
        {
            var query = _serviceProvider.GetService<IGenericQuery>();
            var page = await query.Get<CustomerEntity,CustomerListItemDTO>(new CustomerSpecification("truonglx", null),
                cus => new CustomerListItemDTO() { Name = cus.Name },
                new PagingInfo(1, 10));
        }
    }
}