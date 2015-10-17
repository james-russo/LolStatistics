using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolWorldFinalStats.Configuration;
using NHibernate;
using NHibernate.Linq;

namespace LolWorldFinalStatWeb.Data
{
    public class NHibernateRespository : IRepository
    {
       public static readonly string ConnectionNameSpace = "LolWorldFinalStatWeb.Data.hibernate.cfg.xml";
       public static readonly string DataAssemblyName = "LolWorldFinalStatWeb.Data";

        public IEnumerable<T> GetAll<T>() where T : class, new()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession(ConnectionNameSpace, DataAssemblyName))
                {
                    var dataRows = session.Query<T>();

                    return dataRows.ToList();
                }
            }
        }

        public IEnumerable<T> GetAll<T>(Func<T, bool> expression) where T : class, new()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession(ConnectionNameSpace, DataAssemblyName))
                {
                    var dataRows = session.Query<T>().Where(expression);

                    return dataRows.ToList();
                }
            }
        }

        public void InsertOrUpdate<T>(T source) where T : class, new()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(source);
                        transaction.Commit();
                    }
                }
            }
        }

        public void Purge<T>(T item) where T : class, new()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(item);
                        transaction.Commit();
                    }
                }
            }
        }
    }
}
