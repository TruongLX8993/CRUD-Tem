using System.Reflection;
using Base.Queries;
using Base.Repositories;
using Customer.Infrastructure.Config;
using Customer.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace Customer.Infrastructure
{
    public static class InfrastructureConfig
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection serviceCollection,
            string connectionString)
        {
            var nhibernateMgr = new NhibernateMgr(connectionString,Assembly.GetExecutingAssembly());
            serviceCollection.AddSingleton(nhibernateMgr);
            serviceCollection.AddTransient<ISession>(session => session.GetService<NhibernateMgr>()?.Open());
            serviceCollection.AddTransient<IStatelessSession>(session => session.GetService<NhibernateMgr>()?.OpenStateless());
            serviceCollection.AddTransient(typeof(IRepository<,>), typeof(BaseRepository<,>));
            serviceCollection.AddTransient(typeof(IGenericQuery),typeof(BaseGenericQuery) );
            return serviceCollection;
        }
    }
}