﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FortuneTellerMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FortuneTellerMVCEntities : DbContext
    {
        public FortuneTellerMVCEntities()
            : base("name=FortuneTellerMVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BirthMonth> BirthMonths { get; set; }
        public virtual DbSet<ColorList> ColorLists { get; set; }
        public virtual DbSet<Rube> Rubes { get; set; }
        public virtual DbSet<Transportation> Transportations { get; set; }
        public virtual DbSet<VacaySpot> VacaySpots { get; set; }
    }
}
