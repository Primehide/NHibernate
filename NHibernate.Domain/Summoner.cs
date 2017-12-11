using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain
{
    public class Summoner
    {
        public virtual int Id { get; set; }
        public virtual string Voornaam { get; set; }
        public virtual string Achternaam { get; set; }
        public virtual int Leeftijd { get; set; }
    }
}
