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
    
    public partial class AsignacionPistasDespegue
    {
        public int Id { get; set; }
        public int IdVuelo { get; set; }
        public int IdPista { get; set; }
    
        public virtual Pistas Pistas { get; set; }
        public virtual Vuelos Vuelos { get; set; }
    }
}
