using System;
using System.Linq;
using System.Web.Http;
using Controllers.Models;
using ClasesData;

namespace Controllers.Controllers
{
    public class RadarController : ApiController
    {
        private readonly tiusr26pl_ProyectoSitiosEntities RadarEntidad = new tiusr26pl_ProyectoSitiosEntities();

        public RadarController()
        {
            RadarEntidad.Configuration.LazyLoadingEnabled = false;
            RadarEntidad.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        [Route("api/Radar/Obtener")]
        public IHttpActionResult ObtenerTodos()
        {
            try
            {
                var result = (from vuelo in RadarEntidad.Vuelos
                              join aerolinea in RadarEntidad.Aerolineas on vuelo.IdAerolinea equals aerolinea.IdAerolinea
                              join aeronave in RadarEntidad.Aeronaves on vuelo.IdAeronave equals aeronave.IdAeronave
                              join estadoVuelo in RadarEntidad.EstadoVuelo on vuelo.IdEstadoVuelo equals estadoVuelo.IdEstadoVuelo
                              join piloto in RadarEntidad.Pilotos on vuelo.IdPiloto equals piloto.IDPiloto
                              join prioridad in RadarEntidad.PrioridadesVuelos on vuelo.IdPrioridad equals prioridad.IdPrioridad
                              join tipoVuelo in RadarEntidad.TipoVuelo on vuelo.IDTipoVuelo equals tipoVuelo.IdTipoVuelo
                              join origen in RadarEntidad.Ciudades on vuelo.IDOrigen equals origen.IdCiudad
                              join destino in RadarEntidad.Ciudades on vuelo.IDDestino equals destino.IdCiudad
                              //join aeropuertoO in RadarEntidad.Aeropuertos on vuelo.IDOrigen equals aeropuertoO.Latitud
                              //join aeropuertoD in RadarEntidad.Aeropuertos on vuelo.IDDestino equals aeropuertoD.Longitud
                              select new
                              {
                                  vuelo.IdVuelo,
                                  vuelo.NumeroVuelo,
                                  Aerolinea = aerolinea.NombreAerolinea,
                                  Aeronave = aeronave.Modelo,
                                  EstadoVuelo = estadoVuelo.Estado,
                                  PilotoNombre = piloto.Nombre,
                                  PilotoApellido = piloto.Apellido,
                                  Prioridad = prioridad.Descripcion,
                                  TipoVuelo = tipoVuelo.Descripcion,
                                  Origen = origen.NombreCiudad,
                                  Destino = destino.NombreCiudad,
                                  //AeropuertoO  = aeropuertoO.Latitud,
                                 // AeropuertoD =aeropuertoD.Longitud,
                                  vuelo.Ruta,
                                  vuelo.HoraSalida,
                                  vuelo.HoraLlegada,
                                  vuelo.DuracionEstimada
                              }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al obtener todos los vuelos: {ex.Message}");
                return InternalServerError();
            }
        }

    }
}
