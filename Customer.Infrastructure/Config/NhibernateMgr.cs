using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Customer.Infrastructure.Config
{
    public class NhibernateMgr
    {
        private readonly ISessionFactory _sessionFactory;
        
        public NhibernateMgr(string connectionStr,Assembly mappingAssembly)
        {
            _sessionFactory = CreateSessionFactory(connectionStr, mappingAssembly);
        }
        public ISession Open()
        {
            return _sessionFactory.OpenSession();
        }

        public IStatelessSession OpenStateless()
        {
            return _sessionFactory.OpenStatelessSession();
        }

        private static ISessionFactory CreateSessionFactory(
            string connectionString,
            Assembly mappingAssembly)
        {
            var cfg = MsSqlConfiguration.MsSql2012
                .ConnectionString(c =>
                    c.Is(connectionString));


            return Fluently.Configure()
                .Database(
                    cfg
                )
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(mappingAssembly))
                .BuildSessionFactory();
        }

        
    }
}