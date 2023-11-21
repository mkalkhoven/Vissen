using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalaag.Classes
{
    public class Agenda
    {
        public int Agendaid { get; set; }
        public long? Serieid { get; set; }
        public DateTime Datum { get; set; }
        public string Serienaamnummer { get; set; }
    }
}
