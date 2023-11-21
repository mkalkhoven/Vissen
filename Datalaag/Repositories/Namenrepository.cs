using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Datalaag.Classes;
using static Datalaag.Global;

namespace Datalaag.Repositories
{
    public class Namenrepository : Repository<Namen>
    {
        public int Verkrijgid()
        {
            var id = Context.Namen.Max(n => n.NaamID) + 1;
            return (int)id;
        }
        public Namen GetbyNaamid(int Naamid)
        {
            return Context.Namen.Where(n => n.NaamID == Naamid).FirstOrDefault();
        }
        public List<Namen>Get(string zoeken)
        {
            return Context.Namen.Where(n => n.Naam.ToLower().Contains(zoeken.ToLower())).ToList();
        }
        public List<Namen>Get(Serienaam serie, bool verwijderd)
        {
            var namen = new List<Namen>();
            switch(serie)
            {
                case Serienaam.Alles:
                    return Context.Namen.Where(n => n.Verwijderd == verwijderd).OrderBy(n => n.Achternaam).ThenBy(n => n.Voornaam).ToList();
                case Serienaam.Vijftigplus:
                    return Context.Namen.Where(n => n.Vijftigplus == true && n.Verwijderd == verwijderd).OrderBy(n => n.Achternaam).ThenBy(n => n.Voornaam).ToList();
                case Serienaam.Jeugd:
                    return Context.Namen.Where(n => n.Jeugd == true && n.Verwijderd == verwijderd).OrderBy(n => n.Achternaam).ThenBy(n => n.Voornaam).ToList();
                case Serienaam.Senioren:
                    return Context.Namen.Where(n => n.Senioren == true && n.Verwijderd == verwijderd).OrderBy(n => n.Achternaam).ThenBy(n => n.Voornaam).ToList();
                case Serienaam.Wintervissen:
                    return Context.Namen.Where(n => n.Winter == true && n.Verwijderd == verwijderd).OrderBy(n => n.Achternaam).ThenBy(n => n.Voornaam).ToList();
            }
            return namen;
        }
        public List<Namen>Get(bool deleted)
        {
            return Context.Namen.OrderBy(n => n.Achternaam).ThenBy(n => n.Voornaam) .ToList();
            //return Context.Namen.Where(n => n.Verwijderd == deleted).ToList();
        }
        public List<Namen> Get(Vistype vistype)
        {
            var namen = new List<Namen>();
            switch (vistype)
            {
                case Vistype.Vijftigplus:
                    return Get().Where(n => n.Vijftigplus == true).ToList();
                case Vistype.Senioren:
                    return Get().Where(n => n.Senioren == true).ToList();
                case Vistype.Jeugd:
                    return Get().Where(n => n.Jeugd == true).ToList();
                case Vistype.Winter:
                    return Get().Where(n => n.Winter == true).ToList();
                case Vistype.Vrijewedstrijden:
                    return Get().Where(n => n.Koppelvissen == true).ToList();
            }
            return new List<Namen>();
        }
        public List<Namen> Getbytype(Global.Vistype type)
        {
            var namen = new List<Namen>();
            switch (type)
            {
                case Global.Vistype.Vijftigplus:
                    namen = Context.Namen.Where(n => n.Vijftigplus == true).ToList();
                    break;
                case Global.Vistype.Nachtvissen:
                case Global.Vistype.Koppel:
                    namen = Context.Namen.Where(n => n.Koppelvissen == true).ToList();
                    break;
                case Global.Vistype.Senioren:
                case Global.Vistype.Vrijewedstrijden:
                    namen = Context.Namen.Where(n => n.Senioren == true).ToList();
                    break;
                case Global.Vistype.Jeugd:
                    namen = Context.Namen.Where(n => n.Jeugd == true).ToList();
                    break;
                case Global.Vistype.Winter:
                    namen = Context.Namen.Where(n => n.Winter == true).ToList();
                    break;
                case Global.Vistype.Toonalles:

                    break;
            }
            return namen;
        }
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
                case Global.Vistype.Nachtvissen:
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

        public int Getid()
        {
            var x = Context.Namen.Select(n => n.NaamID).Max() + 1;
            return (int)x;
        }
    }
}
