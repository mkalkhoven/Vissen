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
    
    public partial class Seizoen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seizoen()
        {
            this.DatumWeerEtc = new HashSet<DatumWeerEtc>();
            this.KlassementCorrectie = new HashSet<KlassementCorrectie>();
            this.Uitslagen = new HashSet<Uitslagen>();
        }
    
        public int ID { get; set; }
        public string Jaar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatumWeerEtc> DatumWeerEtc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KlassementCorrectie> KlassementCorrectie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uitslagen> Uitslagen { get; set; }
    }
}
