using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolWorldFinalStats.Models.Domain
{
    public class TeamSessionChampionPick
    {
        public virtual int Id { get; set; }

        public virtual int TeamSessionId { get; set; }

        public virtual int? TeamMemberId { get; set; }

        public virtual int ChampionId { get; set; }

        public virtual int PickOrder { get; set; }
    }
}
