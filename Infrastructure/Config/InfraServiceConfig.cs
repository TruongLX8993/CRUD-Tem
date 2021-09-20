using System.Reflection;
using Domain.Repositories;
using Infrastructure.Data.Queries;
using Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using IQuery = Application.Queries.IQuery;

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
            serviceCollection.AddTransient(typeof(IQuery),typeof(BaseQuery) );
            return serviceCollection;
        }
    }
}