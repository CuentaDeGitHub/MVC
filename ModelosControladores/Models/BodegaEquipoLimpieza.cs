//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelosControladores.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BodegaEquipoLimpieza
    {
        public int idBodegaEquipoLimpieza { get; set; }
        public int idBodega { get; set; }
        public int idEquipoLimpieza { get; set; }
        public Nullable<bool> estatus { get; set; }
        public Nullable<int> idUsuarioCrea { get; set; }
        public Nullable<System.DateTime> fechaCrea { get; set; }
        public Nullable<int> idUsuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    
        public virtual Bodega Bodega { get; set; }
        public virtual EquipoLimpieza EquipoLimpieza { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}