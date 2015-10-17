using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolWorldFinalStats.Configuration;
using LolWorldFinalStats.Models.Domain;

namespace LolWorldFinalStats.Services
{
    public class ChampionEventSessionService : BaseService<ChampionEventSession>
    {
        public ChampionEventSessionService(IRepository repo) : base(repo)
        {
        }
    }
}
