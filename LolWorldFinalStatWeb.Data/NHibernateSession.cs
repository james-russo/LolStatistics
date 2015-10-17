using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace LolWorldFinalStatWeb.Data
{
    public class NHibernateSession : IDisposable
    {
        public ISession OpenSession()
        {
            return OpenSession(NHibernateRespository.ConnectionNameSpace, NHibernateRespository.DataAssemblyName);
        }

        public ISession OpenSession(string connectionNameSpace, string dataAssemblyName)
        {
            var configuration = new Configuration();
            configuration.Configure(this.GetType().Assembly, connectionNameSpace);
            configuration.AddAssembly(dataAssemblyName);

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        public void Dispose()
        {
        }
    }
}
