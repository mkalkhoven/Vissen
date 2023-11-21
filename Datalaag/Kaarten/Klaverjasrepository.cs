using Datalaag.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalaag.Kaarten
{
    public class Klaverjasrepositorie : Repository<DeelnemerK>
    {
        public List<Kaartdeelnemer> Getdeelnemers(string zoeken)
        {
            return Context.Deelnemer.Where(n => n.VolledigeNaam.ToLower().Contains(zoeken.ToLower())).OrderBy(n => n.Naam).Select(n => new Kaartdeelnemer
            {
                Nr = n.Nr,
                Naam = n.VolledigeNaam,
                Afbeelding = n.Afbeelding
            }).ToList();
        }
        public List<Kaartdeelnemer> Getdeelnemers(bool verwijderd)
        {
            return Context.Deelnemer.Where(n => n.Verwijderd == verwijderd).OrderBy(n => n.Naam).OrderBy(n => n.Achternaam).ThenBy(n => n.Voornaam).Select(n => new Kaartdeelnemer
            {
                Nr = n.Nr,
                Naam = n.VolledigeNaam,
                Afbeelding = n.Afbeelding
            }).ToList();
        }
    }
}
