//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClasesData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Taxiways
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Taxiways()
        {
            this.OperacionesRodaje = new HashSet<OperacionesRodaje>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdAeropuerto { get; set; }
        public string Designacion { get; set; }
        public string Tipo { get; set; }
    
        public virtual Aeropuertos Aeropuertos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OperacionesRodaje> OperacionesRodaje { get; set; }
    }
}
