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
    
    public partial class Adjunto
    {
        public int idAdjuntos { get; set; }
        public int idDocumento { get; set; }
        public int tipoReferencia { get; set; }
        public string ruta { get; set; }
    
        public virtual Documento Documento { get; set; }
        public virtual TablaGeneral TablaGeneral { get; set; }
    }
}