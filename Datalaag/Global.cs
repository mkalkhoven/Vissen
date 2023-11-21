using Datalaag.Kaarten;
using Datalaag.Repositories;

namespace Datalaag
{
    public static class Global
    {
        public enum Sorting
        {
            Ascending,
            descending
        }
        public enum Serienaam
        {
            Alles,
            Vijftigplus,
            Jeugd,
            Senioren,
            Wintervissen
        }
        public enum Vistype
        {
            Vijftigplus,
            Senioren,
            Jeugd,
            Winter,
            Koppel,
            Vrijewedstrijden,
            Toonalles,
            Nachtvissen
        }
        public static KlassementCorrectierepository Correctierepo = new KlassementCorrectierepository();
        public static Seizoenrepository Seizoenrepo = new Seizoenrepository();
        public static Lotingrepository Lotingrepo = new Lotingrepository();
        public static Naamserierepository Naamserierepo = new Naamserierepository();
        public static Nachtvissenrepository Nachtvissenrepo = new Nachtvissenrepository();
        public static Namenrepository Namenrepo = new Namenrepository();
        public static Datumweeretcrepository Datumweeretcrepo = new Datumweeretcrepository();
        public static Windrepository Windrepo = new Windrepository();
        public static Uitslagenrepository Uitslagenrepo = new Uitslagenrepository();
        public static Partnerrepository Partnerrepo = new Partnerrepository();
        public static Klaverjasrepositorie klaverjasrepo = new Klaverjasrepositorie();
        public static Jokerenrepositorie Jokerenrepo = new Jokerenrepositorie();
    }
}
