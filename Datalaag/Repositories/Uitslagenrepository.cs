using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Xml.Schema;
using Datalaag.Classes;
using static Datalaag.Global;

namespace Datalaag.Repositories
{
    public class Uitslagenrepository : Repository<Uitslagen>
    {
        public long Getaantal(long serieid, Seizoen seizoen)
        {
            var x = Context.Uitslagen.Where(u => u.SerieNaamNr == serieid && u.IDseizoen == seizoen.ID).Select(u => u.SerieNummerNr).Max();

            if (x == null)
            {
                return 0;
            }
            return (long)x;
        }
        public long Getaantal(NaamSerie serie, Seizoen seizoen)
        {
            return (long)Context.Uitslagen.Where(u => u.SerieNaamNr == serie.Id && u.IDseizoen == seizoen.ID).Select(u => u.SerieNummerNr).Max();
        }
        public void Save(DatumWeerEtc datum, double punten, int gewicht)
        {
            var uitslagen = Context.Uitslagen.Where(u => u.IDdatum == datum.ID && u.Kilo == gewicht);
            foreach (var uitslag in uitslagen)
            {
                uitslag.Pnt = punten;
                DbSet.AddOrUpdate(uitslag);
            }
            Context.SaveChanges();
        }
        public long Getaantal(DatumWeerEtc datum, long gewicht)
        {
            var x = Context.Uitslagen.Where(u => u.IDdatum == datum.ID && u.Kilo == gewicht).ToList();
            return x.Count;
        }
        public void Save(Uitslag uitslag)
        {
            if (uitslag.Naam.TrimEnd().ToLower().Contains("totaal"))
            {
                return;
            }
            var uitslagen = Get(uitslag.Uitslagid);
            uitslagen.Kilo = uitslag.Gewicht;
            uitslagen.Pnt = uitslag.Punten;
            Save(uitslagen);
        }
        public List<Uitslag> Get(DatumWeerEtc datum)
        {
            var tmp = Context.Uitslagen.Where(u => u.IDdatum.Equals(datum.ID)).OrderByDescending(u => u.Kilo);

            var uitslagen = new List<Uitslag>();
            int totaal = 0;
            int aantal = 0;

            foreach (var regel in tmp)
            {
                var naam = Namenrepo.Getbyoldid(regel.IDdeelnemer);
                var uitslag = new Uitslag
                {
                    Uitslagid = regel.Uitslagid,
                    Naam = naam.Naam,
                    Gewicht = regel.Kilo,
                    Punten = regel.Pnt,
                    Naamid = regel.IDdeelnemer
                };
                aantal = (int) (aantal + regel.Pnt);
                totaal = (int) (totaal + regel.Kilo);
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
