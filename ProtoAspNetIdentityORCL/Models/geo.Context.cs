﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NSPecor.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class geo : DbContext
    {
        public geo()
            : base("name=geo")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GEOB_CARROUSEL> GEOB_CARROUSEL { get; set; }
        public virtual DbSet<GEOB_ENLACES_PANEL> GEOB_ENLACES_PANEL { get; set; }
        public virtual DbSet<GEOB_ESTADO> GEOB_ESTADO { get; set; }
        public virtual DbSet<GEOB_GRUPOS> GEOB_GRUPOS { get; set; }
        public virtual DbSet<GEOB_MAPAS_CATALOGO> GEOB_MAPAS_CATALOGO { get; set; }
        public virtual DbSet<GEOB_PANEL> GEOB_PANEL { get; set; }
        public virtual DbSet<GEOB_SERVICIOS_CATALOGO> GEOB_SERVICIOS_CATALOGO { get; set; }
        public virtual DbSet<GEOB_TEMATICAS> GEOB_TEMATICAS { get; set; }
        public virtual DbSet<GEOB_TIPO_CATALOGO> GEOB_TIPO_CATALOGO { get; set; }
        public virtual DbSet<GEOB_TIPO_SRV> GEOB_TIPO_SRV { get; set; }
    }
}
