using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalaag.Repositories
{
    public class Partnerrepository : Repository<Partner>
    {
        public Partner Get(long Naamid, long Serieid)
        {
            return Context.Partner.Where(p => p.Naamid == Naamid && p.Serieid == Serieid).FirstOrDefault();
        }
    }
}
