﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tiusr26pl_ProyectoSitiosEntities : DbContext
    {
        public tiusr26pl_ProyectoSitiosEntities()
            : base("name=tiusr26pl_ProyectoSitiosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aerolineas> Aerolineas { get; set; }
        public virtual DbSet<Aeronaves> Aeronaves { get; set; }
        public virtual DbSet<Aeropuertos> Aeropuertos { get; set; }
        public virtual DbSet<AltitudEmergencia> AltitudEmergencia { get; set; }
        public virtual DbSet<Aproximaciones> Aproximaciones { get; set; }
        public virtual DbSet<Asientos> Asientos { get; set; }
        public virtual DbSet<AsignacionDespeguesUsuario> AsignacionDespeguesUsuario { get; set; }
        public virtual DbSet<AsignacionPistasDespegue> AsignacionPistasDespegue { get; set; }
        public virtual DbSet<Aterrizajes> Aterrizajes { get; set; }
        public virtual DbSet<Autoridades> Autoridades { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Comunicaciones> Comunicaciones { get; set; }
        public virtual DbSet<ComunicacionesControladorAeronave> ComunicacionesControladorAeronave { get; set; }
        public virtual DbSet<ComunicacionesControladorAutoridad> ComunicacionesControladorAutoridad { get; set; }
        public virtual DbSet<Controladores> Controladores { get; set; }
        public virtual DbSet<CoordinadoresTierra> CoordinadoresTierra { get; set; }
        public virtual DbSet<DatosMinimosAterrizaje> DatosMinimosAterrizaje { get; set; }
        public virtual DbSet<Desembarques> Desembarques { get; set; }
        public virtual DbSet<DesviosRuta> DesviosRuta { get; set; }
        public virtual DbSet<Embarques> Embarques { get; set; }
        public virtual DbSet<Emergencias> Emergencias { get; set; }
        public virtual DbSet<Equipaje> Equipaje { get; set; }
        public virtual DbSet<EquipoEmergenciaTierra> EquipoEmergenciaTierra { get; set; }
        public virtual DbSet<Escalas> Escalas { get; set; }
        public virtual DbSet<EstadoAeronave> EstadoAeronave { get; set; }
        public virtual DbSet<EstadoAproximacion> EstadoAproximacion { get; set; }
        public virtual DbSet<EstadoPista> EstadoPista { get; set; }
        public virtual DbSet<EstadoVuelo> EstadoVuelo { get; set; }
        public virtual DbSet<EventosDespegue> EventosDespegue { get; set; }
        public virtual DbSet<HistorialVuelos> HistorialVuelos { get; set; }
        public virtual DbSet<InformacionMeteorologica> InformacionMeteorologica { get; set; }
        public virtual DbSet<InstruccionesRodaje> InstruccionesRodaje { get; set; }
        public virtual DbSet<Mercancias> Mercancias { get; set; }
        public virtual DbSet<OperacionesRodaje> OperacionesRodaje { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Pasajeros> Pasajeros { get; set; }
        public virtual DbSet<PasajerosVuelos> PasajerosVuelos { get; set; }
        public virtual DbSet<PersonalCarga> PersonalCarga { get; set; }
        public virtual DbSet<PersonalMantenimiento> PersonalMantenimiento { get; set; }
        public virtual DbSet<PersonalOperacionesAeropuerto> PersonalOperacionesAeropuerto { get; set; }
        public virtual DbSet<PersonalServiciosTierra> PersonalServiciosTierra { get; set; }
        public virtual DbSet<Pilotos> Pilotos { get; set; }
        public virtual DbSet<Pistas> Pistas { get; set; }
        public virtual DbSet<Posiciones> Posiciones { get; set; }
        public virtual DbSet<PosicionesEstacionamiento> PosicionesEstacionamiento { get; set; }
        public virtual DbSet<PrioridadAterrizaje> PrioridadAterrizaje { get; set; }
        public virtual DbSet<PrioridadesAterrizajes> PrioridadesAterrizajes { get; set; }
        public virtual DbSet<PrioridadesVuelos> PrioridadesVuelos { get; set; }
        public virtual DbSet<PuertasEmbarqueDesembarque> PuertasEmbarqueDesembarque { get; set; }
        public virtual DbSet<RegistroComunicaciones> RegistroComunicaciones { get; set; }
        public virtual DbSet<RegistroEmergencia> RegistroEmergencia { get; set; }
        public virtual DbSet<ReporteFinalDespegues> ReporteFinalDespegues { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<SecuenciaAterrizaje> SecuenciaAterrizaje { get; set; }
        public virtual DbSet<Taxiways> Taxiways { get; set; }
        public virtual DbSet<TipoAproximacion> TipoAproximacion { get; set; }
        public virtual DbSet<TipoEmergencia> TipoEmergencia { get; set; }
        public virtual DbSet<Tripulacion> Tripulacion { get; set; }
        public virtual DbSet<Tripulación> Tripulación { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vuelos> Vuelos { get; set; }
        public virtual DbSet<Labels> Labels { get; set; }
    }
}
