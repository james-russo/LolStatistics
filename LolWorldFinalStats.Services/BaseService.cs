using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolWorldFinalStats.Configuration;

namespace LolWorldFinalStats.Services
{
    public class BaseService<T> where T : class, new()
    {
        private IRepository Repository;

        public BaseService(IRepository repo)
        {
            Repository = repo;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Repository.GetAll<T>();
        }

        public virtual IEnumerable<T> GetAll(Func<T, bool> expression)
        {
            return Repository.GetAll<T>(expression);
        }

        public void InsertOrUpdate(T source)
        {
            Repository.InsertOrUpdate(source);
        }

        public void Purge(T source)
        {
            Repository.Purge(source);
        }
    }
}
