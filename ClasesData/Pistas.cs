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
    
    public partial class Pistas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pistas()
        {
            this.AsignacionPistasDespegue = new HashSet<AsignacionPistasDespegue>();
            this.EstadoPista = new HashSet<EstadoPista>();
            this.OperacionesRodaje = new HashSet<OperacionesRodaje>();
            this.ReporteFinalDespegues = new HashSet<ReporteFinalDespegues>();
        }
    
        public int IdPista { get; set; }
        public Nullable<int> IdAeropuerto { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public Nullable<decimal> Ancho { get; set; }
        public string Designacion { get; set; }
        public string Superficie { get; set; }
    
        public virtual Aeropuertos Aeropuertos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsignacionPistasDespegue> AsignacionPistasDespegue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadoPista> EstadoPista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OperacionesRodaje> OperacionesRodaje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReporteFinalDespegues> ReporteFinalDespegues { get; set; }
    }
}
