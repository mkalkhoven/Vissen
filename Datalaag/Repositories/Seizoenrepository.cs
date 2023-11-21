using System.Collections.Generic;
using System.Linq;
using static Datalaag.Global;

namespace Datalaag.Repositories
{
    public class Seizoenrepository : Repository<Seizoen>
    {
        public Seizoen Getlaatsteseizoen()
        {
            return Context.Seizoen.OrderByDescending(s => s.ID).First();
        }
        public List<Seizoen> Getsorted()
        {
            return Context.Seizoen.OrderByDescending(s => s.Jaar).ToList();
        }
        public List<Seizoen> Get(Sorting sorting)
        {
            switch (sorting)
            {
                case Sorting.Ascending:
                    return Context.Seizoen.OrderBy(s => s.ID).ToList();
                case Sorting.descending:
                    return Context.Seizoen.OrderByDescending(s => s.ID).ToList();
            }
            return null;
        }
        public long Getlaatste()
        {
            return Context.Seizoen.Max(s => s.ID);
        }
    }
}

