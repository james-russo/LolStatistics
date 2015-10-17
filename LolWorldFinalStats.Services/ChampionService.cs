using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolWorldFinalStats.Configuration;
using LolWorldFinalStats.Models.Domain;

namespace LolWorldFinalStats.Services
{
    public class ChampionService : BaseService<Champion>
    {
        public ChampionService(IRepository repo) : base(repo)
        {
        }
    }
}
