using System;
using System.Collections.Generic;
using System.Linq;

namespace Datalaag2.Repositories
{
    public class Datumweeretcrepository : Repository<DatumWeerEtc>
    {
        public DatumWeerEtc Get(long seizoenid, long serieid, long nummer)
        {
            return Context.DatumWeerEtc.FirstOrDefault(d => d.IDseizoen == seizoenid && d.SerieNaamNr == serieid && d.IDserieNummer == nummer);
        }
        public DatumWeerEtc Get(Seizoen seizoen, NaamSerie serie, long serienaamnummer)
        {
            try
            {
                return Context.DatumWeerEtc.FirstOrDefault(d => d.IDseizoen == seizoen.ID && d.IDserieNummer == serienaamnummer && d.SerieNaamNr == serie.Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public long Getaantal(long seizoenid, long serieid)
        {
            return Context.DatumWeerEtc.Where(d => d.IDseizoen == seizoenid && d.SerieNaamNr == serieid).ToList().Count;
        }
        public List<DatumWeerEtc> Get(Seizoen seizoen, NaamSerie serie)
        {
            if (seizoen == null || serie == null)
            {
                return new List<DatumWeerEtc>();
            }
            return Context.DatumWeerEtc.Where(d => d.IDseizoen == seizoen.ID && d.SerieNaamNr == serie.Id).ToList();
        }
        public long Getid()
        {
            return Context.DatumWeerEtc.Max(d => d.ID) + 1;
        }
    }
}
