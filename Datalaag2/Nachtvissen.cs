//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datalaag2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nachtvissen
    {
        public int Nachtvisid { get; set; }
        public Nullable<int> ID { get; set; }
        public string Namen { get; set; }
        public Nullable<int> Gewicht { get; set; }
        public Nullable<int> Deelnemerid1 { get; set; }
        public Nullable<int> Gewicht1 { get; set; }
        public Nullable<int> Deelnemerid2 { get; set; }
        public Nullable<int> Gewicht2 { get; set; }
    
        public virtual DatumWeerEtc DatumWeerEtc { get; set; }
    }
}