using System.Collections.Generic;
using System.Linq;

namespace Datalaag2.Repositories
{
    public class Seizoenrepository : Repository<Seizoen>
    {
        public List<Seizoen> Getsorted()
        {
            return Context.Seizoen.OrderByDescending(s => s.Jaar).ToList();
        }
    }
}
