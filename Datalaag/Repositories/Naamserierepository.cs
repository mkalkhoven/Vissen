using System.Collections.Generic;
using System.Linq;

namespace Datalaag.Repositories
{
    public class Naamserierepository : Repository<NaamSerie>
    {
        public List<NaamSerie> Getsorted()
        {
            return Context.NaamSerie.Where(n => n.Tonen == true).OrderBy(n => n.Naam).ToList();
        }
    }
}
