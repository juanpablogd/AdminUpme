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
    
    public partial class GEOB_SERVICIOS_CATALOGO
    {
        public decimal ID_SERVICIO { get; set; }
        public string TITULO { get; set; }
        public string DESCRIPCION { get; set; }
        public string URL { get; set; }
        public string TAGS { get; set; }
        public decimal FK_ID_TIPO_SRV { get; set; }
        public decimal FK_ID_ESTADO { get; set; }
        public Nullable<decimal> FK_ID_USUARIO { get; set; }
        public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }
    
        public virtual GEOB_ESTADO GEOB_ESTADO { get; set; }
        public virtual GEOB_TIPO_SRV GEOB_TIPO_SRV { get; set; }
    }
}
