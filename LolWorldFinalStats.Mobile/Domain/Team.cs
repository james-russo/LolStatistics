using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolWorldFinalStats.Models.Domain
{
    public class Team
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<TeamMember> Members { get; set; } 

        public virtual ICollection<Event> TeamEvents { get; set; }

        public virtual ICollection<TeamSession> TeamSessions { get; set; }
    }
}
