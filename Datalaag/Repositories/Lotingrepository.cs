using System;
using System.Collections.Generic;
using System.Linq;

namespace Datalaag.Repositories
{
    public class Lotingrepository : Repository<Loting2>
    {
        public Loting2 Getbydatumid(long Datumid)
        {
            return Context.Loting2.Where(l => l.Datumid == Datumid).Take(1).FirstOrDefault();
        }
        public Loting2 Getnulloting(long serieid)
        {
            return Context.Loting2.Where(l => l.Serieid == serieid && l.Naamid == 0).FirstOrDefault();
        }
        public Loting2 Get(DateTime datum)
        {
            return Context.Loting2.Where(l => l.Datum == datum).Take(1).FirstOrDefault();
        }
        public void Deleteemptyrow()
        {
            var lot = Context.Loting2.Where(l => l.Naamid == 0).FirstOrDefault();
            if(lot == null)
            {
                return;
            }
            var id = lot.Lotingid;
            lot = null;
            Delete(id);
        }
        public void Delete(DatumWeerEtc datum)
        {
            var lotingen = Context.Loting2.Where(l => l.Datum == datum.Datum && l.Serieid == datum.SerieNaamNr).ToList();
            foreach(var loting in lotingen)
            {
                Delete(loting);
            }
        }

        public List<Loting2> Get(DatumWeerEtc datum)
        {
            return Context.Loting2.Where(l => l.Datum == datum.Datum && l.Serieid == datum.SerieNaamNr && l.Seizoenid == datum.IDseizoen).ToList();
        }
    }
}
