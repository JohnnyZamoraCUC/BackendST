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
    
    public partial class Escalas
    {
        public int ID { get; set; }
        public Nullable<int> IdVuelo { get; set; }
        public Nullable<int> AeropuertoID { get; set; }
    
        public virtual Aeropuertos Aeropuertos { get; set; }
        public virtual Vuelos Vuelos { get; set; }
    }
}