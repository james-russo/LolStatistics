using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolWorldFinalStats.Configuration;
using LolWorldFinalStats.Models;

namespace LolWorldFinalStats.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IRepository repo) : base(repo)
        {
        }

        public IEnumerable<User> GetUsers(Func<User, bool> where = null)
        {
            return where == null ? GetAll() : GetAll(where);
        }

        public void Save(User user)
        {
            InsertOrUpdate(user);
        }
    }
}
