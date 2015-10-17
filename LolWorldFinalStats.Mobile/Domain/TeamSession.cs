using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolWorldFinalStats.Models.Domain
{
    public class TeamSession
    {
        public virtual int Id { get; set; }

        public virtual int EventSessionId { get; set; }

        public virtual int TeamId { get; set; }

        public virtual string Side { get; set; }

        public virtual bool Won { get; set; }

        public virtual ICollection<TeamSessionChampionBan> TeamBans { get; set; }

        public virtual ICollection<TeamSessionChampionPick> ChampionPicks { get; set; }
    }
}
