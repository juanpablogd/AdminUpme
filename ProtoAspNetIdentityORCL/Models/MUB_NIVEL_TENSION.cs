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
    
    public partial class MUB_NIVEL_TENSION
    {
        public MUB_NIVEL_TENSION()
        {
            this.MUB_TENSION = new HashSet<MUB_TENSION>();
        }
    
        public short ID_NIVEL_TENSION { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual ICollection<MUB_TENSION> MUB_TENSION { get; set; }
    }
}
