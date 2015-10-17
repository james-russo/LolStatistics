using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolWorldFinalStats.Models.Domain;

namespace LolWorldFinalStatsMobile.ViewModels
{
    public class ChampionViewModel : BaseObservable<Champion>
    {
        public ChampionViewModel() : base(new Champion())
        {
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetField(ref name, value, "Name"); }

        }


    }
}
