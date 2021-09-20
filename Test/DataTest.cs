using System.ComponentModel.Design;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Config;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class DataTest
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
            var cusRepo = _serviceProvider.GetService<IRepository<int, CustomerEntity>>();
            var cancel = new CancellationTokenSource();
            if (cusRepo != null)
            {
                var cus = await cusRepo.GetById(1, cancel.Token);
            }
        }
    }
}