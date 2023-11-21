using System;
using System.Collections.Generic;
using System.Linq;
using Datalaag.Classes;

namespace Datalaag2.Repositories
{
    public class Namenrepository : Repository<Namen>
    {
        //public Namen Selecteer(long id)
        //{
        //    return Context.Namen.FirstOrDefault(n => n.NaamID == id);
        //}
        public Namen Getbyoldid(long id)
        {
            return Context.Namen.FirstOrDefault(n => n.NaamID == id);
        }
        public List<Deelnemer> Getsorted(Global.Vistype vistype, string zoeken)
        {
            IEnumerable<Namen> tmpdeelnemers = !string.IsNullOrEmpty(zoeken) ? Context.Namen.Where(n => n.Achternaam != "" && n.Achternaam.Contains(zoeken) || n.Voornaam.Contains(zoeken)).OrderBy(n => n.Achternaam).ToList() : Context.Namen.Where(n => n.Achternaam != "").OrderBy(n => n.Achternaam).ToList();

            switch (vistype)
            {
                case Global.Vistype.Vijftigplus:
                    tmpdeelnemers = tmpdeelnemers.Where(n => n.Vijftigplus == true);
                    break;
                case Global.Vistype.Senioren:
                    tmpdeelnemers = tmpdeelnemers.Where(n => n.Senioren == true);
                    break;
                case Global.Vistype.Jeugd:
                    tmpdeelnemers = tmpdeelnemers.Where(n => n.Jeugd == true);
                    break;
                case Global.Vistype.Winter:
                    tmpdeelnemers = tmpdeelnemers.Where(n => n.Winter == true);
                    break;
                case Global.Vistype.Koppel:
                    tmpdeelnemers = tmpdeelnemers.Where(n => n.Koppelvissen == true);
                    break;
                case Global.Vistype.Vrijewedstrijden:
                    tmpdeelnemers = tmpdeelnemers.Where(n => n.Senioren == true);
                    break;
                case Global.Vistype.Toonalles:
                    //Toon alles
                    break;
                default:
                    //return new List<Deelnemer>();
                    //Niets doen, alles tonen
                    break;
            }
            var deelnemers = tmpdeelnemers.Select(deelnemer => new Deelnemer()
            {
                Naamid = (int)deelnemer.NaamID,
                Id = deelnemer.Id,
                Naam = deelnemer.Achternaam + ", " + deelnemer.Voornaam + " " + deelnemer.Tussenvoegsel
            }).ToList();
            return deelnemers.ToList();
        }
    }
}
