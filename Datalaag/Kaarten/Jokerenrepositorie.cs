using Datalaag.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalaag.Kaarten
{
    public class Jokerenrepositorie : Repository<DeelnemerJ>
    {
        public List<Kaartdeelnemer> Getdeelnemers(string zoeken) 
        {
            return Context.DeelnemerJ.Where(n => n.NaamJ.ToLower().Contains(zoeken.ToLower())).OrderBy(n => n.NaamJ).Select(n => new Kaartdeelnemer
            {
                Nr = n.NrJ,
                Naam = n.VolledigeNaamJ,
                Afbeelding = n.Afbeelding
            }).ToList();
        }
        public List<Kaartdeelnemer> Getdeelnemers(bool Verwijderd)
        {
            return Context.DeelnemerJ.Where(n => n.Verwijderd == Verwijderd).OrderBy(n => n.Achternaam).ThenBy(n=> n.Voornaam).Select(n => new Kaartdeelnemer
            {
                Nr = n.NrJ,
                Naam = n.VolledigeNaamJ,
                Afbeelding = n.Afbeelding
            }).ToList();
        }
    }
}
