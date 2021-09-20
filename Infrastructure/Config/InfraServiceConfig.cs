using System.Reflection;
using Base.Queries;
using Base.Repositories;
using Infrastructure.Data.Queries;
using Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace Infrastructure.Config
{
    public static class InfraServiceConfig
    {
        public static IServiceCollection ConfigInfra(this IServiceCollection serviceCollection,
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