using System.Linq;

namespace Datalaag2.Repositories
{
    public class Correctierepository : Repository<KlassementCorrectie>
    {
        public KlassementCorrectie Get(Seizoen seizoen, NaamSerie serie)
        {
            var x = Context.KlassementCorrectie.Where(k => k.Seizoenid == seizoen.ID && k.Serieid == serie.Id).FirstOrDefault();
            return x;

            //return Context.KlassementCorrectie.FirstOrDefault(c => c.Seizoenid == seizoen.ID && c.Serieid == serie.Id);
        }
    }
}
