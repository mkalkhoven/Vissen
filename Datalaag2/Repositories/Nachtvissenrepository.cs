using System.Collections.Generic;
using System.Linq;
using Datalaag.Classes;

namespace Datalaag2.Repositories
{
    public class Nachtvissenrepository : Repository<Nachtvissen>
    {
        public long Getid()
        {
            return Context.Nachtvissen.Max(d => d.Nachtvisid) + 1;
        }

        public List<Uitslag> Get(DatumWeerEtc datum)
        {
            var tmp = Context.Nachtvissen.Where(u => u.ID.Equals(datum.ID));//.OrderBy(u => u.Gewicht);

            var uitslagen = new List<Uitslag>();
            int totaal = 0;
            int aantal = 0;

            foreach (var regel in tmp)
            {
                var uitslag = new Uitslag
                {
                    Uitslagid = regel.Nachtvisid,
                    Naam = regel.Namen,
                    Gewicht = regel.Gewicht,
                    Punten = 0,
                    Naamid = 0
                };
                totaal = (int)(totaal + regel.Gewicht);
                uitslagen.Add(uitslag);
            }
            var Uitslag = new Uitslag
            {
                Naam = "      Totaal Gewicht",
                Gewicht = totaal
            };
            if (datum.SerieNaamNr == 12 || datum.SerieNaamNr == 13)
            {
                Uitslag.Punten = aantal;
            }
            uitslagen.Add(Uitslag);

            return uitslagen;
        }
    }
}
