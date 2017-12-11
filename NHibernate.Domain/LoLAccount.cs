using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain
{
    public class LoLAccount
    {
        public virtual int Id { get; set; }
        public virtual string SummonerName { get; set; }
        public virtual int AantalOfRp { get; set; }
        public virtual int AantalOfIp { get; set; }
        public virtual string HuidigeRang { get; set; }
    }
}
