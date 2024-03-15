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
    
    public partial class ReporteFinalDespegues
    {
        public int Id { get; set; }
        public int IdVuelo { get; set; }
        public int IdPista { get; set; }
        public string IdUsuario { get; set; }
        public int IdInformacionMeteorologica { get; set; }
        public System.DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public int IdEventoDespegue { get; set; }
        public int IdRegistroComunicacion { get; set; }
    
        public virtual EventosDespegue EventosDespegue { get; set; }
        public virtual InformacionMeteorologica InformacionMeteorologica { get; set; }
        public virtual Pistas Pistas { get; set; }
        public virtual RegistroComunicaciones RegistroComunicaciones { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual Vuelos Vuelos { get; set; }
    }
}