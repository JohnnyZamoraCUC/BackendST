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
    
    public partial class Emergencias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emergencias()
        {
            this.Aproximaciones = new HashSet<Aproximaciones>();
            this.Aterrizajes = new HashSet<Aterrizajes>();
            this.RegistroEmergencia = new HashSet<RegistroEmergencia>();
        }
    
        public int IdEmergencia { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaHoraInicio { get; set; }
        public Nullable<System.DateTime> FechaHoraFin { get; set; }
        public Nullable<int> idTipoEmergencia { get; set; }
        public Nullable<int> idvuelo { get; set; }
        public Nullable<int> idaltitudemergencia { get; set; }
        public Nullable<int> iddesvioruta { get; set; }
        public Nullable<int> idprioridadaterrizaje { get; set; }
    
        public virtual AltitudEmergencia AltitudEmergencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aproximaciones> Aproximaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aterrizajes> Aterrizajes { get; set; }
        public virtual DesviosRuta DesviosRuta { get; set; }
        public virtual PrioridadAterrizaje PrioridadAterrizaje { get; set; }
        public virtual TipoEmergencia TipoEmergencia { get; set; }
        public virtual Vuelos Vuelos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroEmergencia> RegistroEmergencia { get; set; }
    }
}