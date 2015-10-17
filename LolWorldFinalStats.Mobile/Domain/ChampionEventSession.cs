using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolWorldFinalStats.Models.Domain
{
    public class ChampionEventSession
    {
        public virtual int Id { get; set; }

        public virtual int ChampionId { get; set; }

        public virtual int EventSessionId { get; set; }

        public virtual int TeamMemberId { get; set; }
    }
}
