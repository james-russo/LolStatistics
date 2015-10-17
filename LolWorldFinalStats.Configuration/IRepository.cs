using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LolWorldFinalStats.Configuration
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : class, new();

        IEnumerable<T> GetAll<T>(Func<T, bool> expression) where T : class, new();

        void InsertOrUpdate<T>(T source) where T : class, new();

        void Purge<T>(T item) where T : class, new();
    }
}
