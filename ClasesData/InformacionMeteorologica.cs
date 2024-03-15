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
    
    public partial class InformacionMeteorologica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InformacionMeteorologica()
        {
            this.Aproximaciones = new HashSet<Aproximaciones>();
            this.Aterrizajes = new HashSet<Aterrizajes>();
            this.ReporteFinalDespegues = new HashSet<ReporteFinalDespegues>();
            this.SecuenciaAterrizaje = new HashSet<SecuenciaAterrizaje>();
        }
    
        public int IdInformacionMetereologica { get; set; }
        public Nullable<System.DateTime> FechaHora { get; set; }
        public Nullable<decimal> Temperatura { get; set; }
        public Nullable<decimal> VientoDireccion { get; set; }
        public Nullable<decimal> VientoVelocidad { get; set; }
        public Nullable<decimal> Visibilidad { get; set; }
        public Nullable<decimal> Precipitacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aproximaciones> Aproximaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aterrizajes> Aterrizajes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReporteFinalDespegues> ReporteFinalDespegues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecuenciaAterrizaje> SecuenciaAterrizaje { get; set; }
    }
}