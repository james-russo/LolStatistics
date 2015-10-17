using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolWorldFinalStats.Models.Domain
{
    public class Event
    {
        public virtual  int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime StartDateUtc { get; set; }

        public virtual ICollection<EventSession> EventSessions  { get; set; }

    }
}
