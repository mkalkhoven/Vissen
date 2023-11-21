using Datalaag2.Repositories;

namespace Datalaag2
{
    public static class Global
    {
        public enum Vistype
        {
            Vijftigplus,
            Senioren,
            Jeugd,
            Winter,
            Koppel,
            Vrijewedstrijden,
            Toonalles
        }
        public static Correctierepository Correctierepo = new Correctierepository();
        public static Seizoenrepository Seizoenrepo = new Seizoenrepository();
        public static Naamserierepository Naamserierepo = new Naamserierepository();
        public static Namenrepository Namenrepo = new Namenrepository();
        public static Datumweeretcrepository Datumweeretcrepo = new Datumweeretcrepository();
        public static Windrepository Windrepo = new Windrepository();
        public static Uitslagenrepository Uitslagenrepo = new Uitslagenrepository();
        public static Nachtvissenrepository Nachtvissenrepo = new Nachtvissenrepository();
    }
}
