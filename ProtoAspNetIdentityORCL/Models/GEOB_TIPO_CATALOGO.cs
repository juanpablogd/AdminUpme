//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class GEOB_TIPO_CATALOGO
    {
        public GEOB_TIPO_CATALOGO()
        {
            this.GEOB_MAPAS_CATALOGO = new HashSet<GEOB_MAPAS_CATALOGO>();
        }
    
        public decimal ID_TIPO_CATAL { get; set; }
        public string TIPO_MAPA { get; set; }
        public decimal FK_ID_ESTADO { get; set; }
    
        public virtual GEOB_ESTADO GEOB_ESTADO { get; set; }
        public virtual ICollection<GEOB_MAPAS_CATALOGO> GEOB_MAPAS_CATALOGO { get; set; }
    }
}
