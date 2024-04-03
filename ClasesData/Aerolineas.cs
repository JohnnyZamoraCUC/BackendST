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
    
    public partial class Aerolineas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aerolineas()
        {
            this.Aeronaves = new HashSet<Aeronaves>();
            this.Vuelos = new HashSet<Vuelos>();
        }
    
        public int IdAerolinea { get; set; }
        public string NombreAerolinea { get; set; }
        public string CodigoIATA { get; set; }
        public string CodigoICAO { get; set; }
        public Nullable<System.DateTime> FechaFundacion { get; set; }
        public Nullable<int> IDPaisOperacion { get; set; }
        public Nullable<int> IDPilotoA { get; set; }
        public Nullable<int> IDTripulacionA { get; set; }
    
        public virtual Paises Paises { get; set; }
        public virtual Pilotos Pilotos { get; set; }
        public virtual Tripulacion Tripulacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aeronaves> Aeronaves { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vuelos> Vuelos { get; set; }
    }
}
