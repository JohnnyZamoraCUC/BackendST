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
    
    public partial class Pasajeros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pasajeros()
        {
            this.Equipaje = new HashSet<Equipaje>();
        }
    
        public int IdPasajero { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroPasaporte { get; set; }
        public string CorreoElectrónico { get; set; }
        public string NúmeroTeléfono { get; set; }
        public Nullable<System.DateTime> FechaCompra { get; set; }
        public Nullable<int> NumeroVuelo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipaje> Equipaje { get; set; }
        public virtual Vuelos Vuelos { get; set; }
    }
}
