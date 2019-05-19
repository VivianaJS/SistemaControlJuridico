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
    
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            this.Casos = new HashSet<Caso>();
        }
    
        public int idPersona { get; set; }
        public int idTipo { get; set; }
        public string cedula { get; set; }
        public string nombreCompleto { get; set; }
        public string RepresentanteSocial { get; set; }
        public string RepresentanteLegal { get; set; }
        public string correo { get; set; }
        public string observacion { get; set; }
        public Nullable<int> tipoIdentificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caso> Casos { get; set; }
        public virtual TablaGeneral TablaGeneral { get; set; }
        public virtual TablaGeneral TablaGeneral1 { get; set; }
    }
}
