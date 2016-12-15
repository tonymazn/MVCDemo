using nHibernateMapping.Domain;
using NHibernate.Cfg.ConfigurationSchema;

namespace Repository
{
    public class SessionFactory
    {
        private static NHibernate.ISessionFactory _factory;

        private static void Init()
        {
            NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration();
            config.AddAssembly(typeof(Product).Assembly);

            _factory = config.BuildSessionFactory();
        }

        public static NHibernate.ISessionFactory GetSessionFactory()
        {
            if (_factory == null)
            {
                Init();
            }

            return _factory;
        }

        public static NHibernate.ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }
    }
}
