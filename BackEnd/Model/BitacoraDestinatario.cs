//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BitacoraDestinatario
    {
        public int idBitacora { get; set; }
        public int idUsuario { get; set; }
        public int tipoMovimiento { get; set; }
        public System.DateTime fecha { get; set; }
        public int idDestinatario { get; set; }
        public int idDocumento { get; set; }
        public int idTipoDestino { get; set; }
        public int numeroDestinatario { get; set; }
        public string observacion { get; set; }
        public string observacionBitacora { get; set; }
    
        public virtual TablaGeneral TablaGeneral { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}