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
    
    public partial class Mercancias
    {
        public int IdMercancia { get; set; }
        public string Descripción { get; set; }
        public Nullable<decimal> Peso { get; set; }
        public Nullable<decimal> Volumen { get; set; }
        public string TipoMercancia { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public Nullable<System.DateTime> FechaEnvío { get; set; }
        public Nullable<System.DateTime> FechaEntregaEsperada { get; set; }
        public string Estado { get; set; }
        public Nullable<int> IDNumeroVuelo { get; set; }
    
        public virtual Vuelos Vuelos { get; set; }
    }
}
