//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datalaag
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uitslagen
    {
        public int IDseizoen { get; set; }
        public int IDdatum { get; set; }
        public int IDdeelnemer { get; set; }
        public Nullable<double> Kilo { get; set; }
        public Nullable<double> Pnt { get; set; }
        public Nullable<double> SerieNaamNr { get; set; }
        public Nullable<double> SerieNummerNr { get; set; }
        public string Ploegen { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
        public int Uitslagid { get; set; }
    
        public virtual Seizoen Seizoen { get; set; }
    }
}
