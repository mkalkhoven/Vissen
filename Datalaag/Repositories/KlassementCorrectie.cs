using System.Collections.Generic;
using System.Linq;
namespace Datalaag.Repositories
{
    public class KlassementCorrectierepository : Repository<KlassementCorrectie>
    {
        public KlassementCorrectie Get(Seizoen seizoen, NaamSerie serie)
        {
            return Context.KlassementCorrectie.Where(c => c.NaamSerie.Id == serie.Id && c.Seizoenid == seizoen.ID).FirstOrDefault();
        }
    }
}
