//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClasesData
{
    using System;
    using System.Collections.Generic;
    
    public partial class EquiposEmergencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EquiposEmergencia()
        {
            this.Procedimientos = new HashSet<Procedimientos>();
        }
    
        public int IdEquipoEmergencia { get; set; }
        public Nullable<int> IdTipoEmergencia { get; set; }
        public string NombreEquipo { get; set; }
        public string Descripcion { get; set; }
    
        public virtual TipoEmergencia TipoEmergencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Procedimientos> Procedimientos { get; set; }
    }
}