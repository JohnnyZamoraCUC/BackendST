using System;
using System.Linq;
using System.Web.Http;
using Controllers.Models;
using ClasesData;

using System.Web;
using Newtonsoft.Json;
namespace Controllers.Controllers
{
    public class AterrizajeController : ApiController
    {
        private readonly tiusr26pl_ProyectoSitiosEntities VuelosEntidad = new tiusr26pl_ProyectoSitiosEntities();

        public AterrizajeController()
        {
            VuelosEntidad.Configuration.LazyLoadingEnabled = false;
            VuelosEntidad.Configuration.ProxyCreationEnabled = false;
        }
    
  
        [HttpGet]
        [Route("api/Aterrizaje/ObtenerAproximacion")]
        public IHttpActionResult ObtenerAproximaciones()
        {
            try
            {
                var rutaDominio = ObtenerDominio(); // Método para obtener el dominio completo

                var result = (from Aproximaciones in VuelosEntidad.Aproximaciones
                              join Vuelo in VuelosEntidad.Vuelos on Aproximaciones.IdVuelo equals Vuelo.IdVuelo
                              join piloto in VuelosEntidad.Pilotos on Vuelo.IdPiloto equals piloto.IDPiloto
                              join Aeronave in VuelosEntidad.Aeronaves on Vuelo.IDAeronave equals Aeronave.IdAeronave
                              join prioridad in VuelosEntidad.PrioridadesVuelos on Vuelo.IdPrioridad equals prioridad.IdPrioridad
                              join Aerolinea in VuelosEntidad.Aerolineas on Vuelo.IdAerolinea equals Aerolinea.IdAerolinea
                              join Aeropuerto in VuelosEntidad.Aeropuertos on Vuelo.IDDestino equals Aeropuerto.IdAeropuerto
                              select new
                              {
                                  Aerolinea = Aerolinea.NombreAerolinea,
                                  Vuelo = Vuelo.NumeroVuelo,
                                  NombrePiloto = piloto.Nombre,
                                  ApellidoPiloto = piloto.Apellido,
                                  Aeronave = Aeronave.Modelo,
                                  Prioridad = prioridad.Nombre,
                                  Destino = Aeropuerto.Nombre,
                                  AeronaveImagen = rutaDominio + "/BackendST/" + Aeronave.Rutaimagen
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

        //busca todos los aeropuertos existentes
        [HttpGet]
        [Route("api/Aterrizaje/ObtenerAeropuertos")]
        public IHttpActionResult ObtenerAeropuertos()
        {
            try
            {
                var rutaDominio = ObtenerDominio(); // Método para obtener el dominio completo

                var result = (from Aeropuertos in VuelosEntidad.Aeropuertos
                              select new
                              {
                                  Aeropuerto = Aeropuertos.Nombre
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

        private string ObtenerDominio()
        {
            try
            {
                var dominio = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                return dominio;
            }
            catch (Exception)
            {
                return null; 
            }
        }

        [HttpGet]
        [Route("api/Aterrizaje/InfoVuelo")]
        public IHttpActionResult ObtenerPorCodigo(string codigoVuelo)
        {
            try
            {
                var rutaDominio = ObtenerDominio(); // Método para obtener el dominio completo
                var result = (from vuelo in VuelosEntidad.Vuelos

                              join aerolinea in VuelosEntidad.Aerolineas on vuelo.IdAerolinea equals aerolinea.IdAerolinea
                              join aeronave in VuelosEntidad.Aeronaves on vuelo.IDAeronave equals aeronave.IdAeronave
                              join estadoVuelo in VuelosEntidad.EstadoVuelo on vuelo.IdEstadoVuelo equals estadoVuelo.IdEstadoVuelo
                              join piloto in VuelosEntidad.Pilotos on vuelo.IdPiloto equals piloto.IDPiloto
                              join prioridad in VuelosEntidad.PrioridadesVuelos on vuelo.IdPrioridad equals prioridad.IdPrioridad
                              join tipoVuelo in VuelosEntidad.TipoVuelo on vuelo.IDTipovuelo equals tipoVuelo.IdTipoVuelo
                              join origen in VuelosEntidad.Ciudades on vuelo.IDOrigen equals origen.IdCiudad
                              join destino in VuelosEntidad.Ciudades on vuelo.IDDestino equals destino.IdCiudad
                              join aeropuertoOrigenlatitudLongitud in VuelosEntidad.Aeropuertos on vuelo.IDOrigen equals aeropuertoOrigenlatitudLongitud.IdAeropuerto
                              join aeropuertoDestinolatitudLongitud in VuelosEntidad.Aeropuertos on vuelo.IDDestino equals aeropuertoDestinolatitudLongitud.IdAeropuerto
                              where vuelo.NumeroVuelo == codigoVuelo
                              select new
                              {
                                  NumVuelo = vuelo.NumeroVuelo,
                                  Aerolinea = aerolinea.NombreAerolinea,
                                  Aeronave = aeronave.Modelo,
                                  EstadoVuelo = estadoVuelo.Estado,
                                  PilotoNombre = piloto.Nombre,
                                  PilotoApellido = piloto.Apellido,
                                  Prioridad = prioridad.Nombre,
                                  TipoVuelo = tipoVuelo.Descripcion,
                                  Origen = origen.NombreCiudad,
                                  Destino = destino.NombreCiudad,
                              }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al obtener el vuelo con código {codigoVuelo}: {ex.Message}");
                return InternalServerError();
            }
        }


    }
}
