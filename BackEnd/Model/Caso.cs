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
    
    public partial class Caso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caso()
        {
            this.Documentos = new HashSet<Documento>();
        }
    
        public int idCaso { get; set; }
        public int idPersona { get; set; }
        public int idTipo { get; set; }
        public int idUsuario { get; set; }
        public int idEstado { get; set; }
        public int tipoLitigante { get; set; }
        public string numeroCaso { get; set; }
        public string materia { get; set; }
        public string descripcion { get; set; }
        public string observacion { get; set; }
    
        public virtual TablaGeneral TablaGeneral { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual TablaGeneral TablaGeneral1 { get; set; }
        public virtual TablaGeneral TablaGeneral2 { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documento> Documentos { get; set; }
    }
}