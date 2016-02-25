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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using Microsoft.Owin.Security.Provider;
    
    public partial class pcUpmeCnx : DbContext
    {
        public pcUpmeCnx()
            : base("name=pcUpmeCnx")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MUB_CLASE_CP> MUB_CLASE_CP { get; set; }
        public virtual DbSet<VISTA_BC_MPIO_DPTO> VISTA_BC_MPIO_DPTO { get; set; }
        public virtual DbSet<MUB_ORGANIZACIONES> MUB_ORGANIZACIONES { get; set; }
        public virtual DbSet<MUB_PROYECTOS_PECOR> MUB_PROYECTOS_PECOR { get; set; }
        public virtual DbSet<MUB_TIPO_ORGANIZACION> MUB_TIPO_ORGANIZACION { get; set; }
        public virtual DbSet<MUB_TIPO_PROY_PECOR> MUB_TIPO_PROY_PECOR { get; set; }
        public virtual DbSet<BC_DP_SITIOS_UPME> BC_DP_SITIOS_UPME { get; set; }
        public virtual DbSet<MUB_PECOR_CP_VSS> MUB_PECOR_CP_VSS { get; set; }
        public virtual DbSet<MUB_VSS> MUB_VSS { get; set; }
        public virtual DbSet<MUB_GENERALES> MUB_GENERALES { get; set; }
        public virtual DbSet<MUB_MODULOS> MUB_MODULOS { get; set; }
        public virtual DbSet<MUB_PRIVILEGIOS> MUB_PRIVILEGIOS { get; set; }
        public virtual DbSet<MUB_ROL> MUB_ROL { get; set; }
        public virtual DbSet<MUB_ROL_PRIVILEGIOS> MUB_ROL_PRIVILEGIOS { get; set; }
        public virtual DbSet<MUB_USUARIOS> MUB_USUARIOS { get; set; }
        public virtual DbSet<MUB_USUARIOS_ORG> MUB_USUARIOS_ORG { get; set; }
        public virtual DbSet<MUB_GRUPOS> MUB_GRUPOS { get; set; }
        public virtual DbSet<MUB_UNIDADES> MUB_UNIDADES { get; set; }
        public virtual DbSet<MUB_USUARIOS_ROLES> MUB_USUARIOS_ROLES { get; set; }
        public virtual DbSet<VISTA_SUBESTACION> VISTA_SUBESTACION { get; set; }
        public virtual DbSet<MUB_PECOR_PLAN> MUB_PECOR_PLAN { get; set; }
        public virtual DbSet<MUH_PECOR_COBERTURA> MUH_PECOR_COBERTURA { get; set; }
    
        public virtual int PECOR_P1_CUDIS(Nullable<decimal> pID_PLAN)
        {
            var pID_PLANParameter = pID_PLAN.HasValue ?
                new ObjectParameter("PID_PLAN", pID_PLAN) :
                new ObjectParameter("PID_PLAN", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PECOR_P1_CUDIS", pID_PLANParameter);
        }

    }
}