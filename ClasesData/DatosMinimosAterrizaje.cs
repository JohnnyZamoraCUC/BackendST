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
    
    public partial class DatosMinimosAterrizaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatosMinimosAterrizaje()
        {
            this.Aterrizajes = new HashSet<Aterrizajes>();
        }
    
        public int IdDatosMinimos { get; set; }
        public Nullable<decimal> VelocidadMinima { get; set; }
        public Nullable<decimal> AltitudMinima { get; set; }
        public Nullable<decimal> CombustibleMinimo { get; set; }
        public Nullable<decimal> AnguloDescensoMinimo { get; set; }
        public Nullable<bool> PermisoTorreAproximaciones { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aterrizajes> Aterrizajes { get; set; }
    }
}
