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
    
    public partial class RegistroComunicaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistroComunicaciones()
        {
            this.ReporteFinalDespegues = new HashSet<ReporteFinalDespegues>();
        }
    
        public int IdRegistroComunicacion { get; set; }
        public Nullable<int> IdComunicacion { get; set; }
        public int IdVuelo { get; set; }
        public string IdUsuario { get; set; }
        public string TipoComunicacion { get; set; }
        public string Contenido { get; set; }
        public System.DateTime FechaHora { get; set; }
    
        public virtual Comunicaciones Comunicaciones { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual Vuelos Vuelos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReporteFinalDespegues> ReporteFinalDespegues { get; set; }
    }
}