﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VisSeizoenEntities : DbContext
    {
        public VisSeizoenEntities()
            : base("name=VisSeizoenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DatumWeerEtc> DatumWeerEtc { get; set; }
        public virtual DbSet<KlassementCorrectie> KlassementCorrectie { get; set; }
        public virtual DbSet<Loting2> Loting2 { get; set; }
        public virtual DbSet<NaamSerie> NaamSerie { get; set; }
        public virtual DbSet<Nachtvissen> Nachtvissen { get; set; }
        public virtual DbSet<Namen> Namen { get; set; }
        public virtual DbSet<Seizoen> Seizoen { get; set; }
        public virtual DbSet<Uitslagen> Uitslagen { get; set; }
        public virtual DbSet<Wind> Wind { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
    }
}