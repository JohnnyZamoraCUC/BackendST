﻿using System;
using System.Linq;
using System.Web.Http;
using Controllers.Models;
using ClasesData;

using System.Web;
using Newtonsoft.Json;
namespace Controllers.Controllers
{
    public class VuelosController : ApiController
    {
        private readonly tiusr26pl_ProyectoSitiosEntities VuelosEntidad = new tiusr26pl_ProyectoSitiosEntities();

        public VuelosController()
        {
            VuelosEntidad.Configuration.LazyLoadingEnabled = false;
            VuelosEntidad.Configuration.ProxyCreationEnabled = false;
        }
    
  
        [HttpGet]
        [Route("api/Vuelos/Obtener")]
        public IHttpActionResult ObtenerTodos()
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
                              select new
                              {
                                  vuelo.IdVuelo,
                                  vuelo.NumeroVuelo,
                                  Aerolinea = aerolinea.NombreAerolinea,
                                  Aeronave = aeronave.Modelo,
                                  AeronaveLon = aeronave.Longitud,
                                  AeronaveLat = aeronave.Latitud,
                                  AeronaveImagen = rutaDominio + "/BackendST/" + aeronave.Rutaimagen,
                                  EstadoVuelo = estadoVuelo.Estado,
                                  PilotoNombre = piloto.Nombre,
                                  PilotoApellido = piloto.Apellido,
                                  Prioridad = prioridad.Nombre,
                                  TipoVuelo = tipoVuelo.Descripcion,
                                  Origen = origen.NombreCiudad,
                                  Destino = destino.NombreCiudad,
                                  AeropuertoOLatitud = aeropuertoOrigenlatitudLongitud.Latitud,
                                  AeropuertoOLontigud = aeropuertoOrigenlatitudLongitud.Longitud,
                                  AeropuertoDLatitud = aeropuertoDestinolatitudLongitud.Latitud,
                                  AeropuertoDLongitud = aeropuertoDestinolatitudLongitud.Longitud,
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
        [Route("api/Vuelos/ObtenerPorCodigo")]
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
                                  vuelo.IdVuelo,
                                  vuelo.NumeroVuelo,
                                  Aerolinea = aerolinea.NombreAerolinea,
                                  Aeronave = aeronave.Modelo,
                                  AeronaveLon = aeronave.Longitud,
                                  AeronaveLat = aeronave.Latitud,
                                  AeronaveImagen = rutaDominio + "/BackendST/" + aeronave.Rutaimagen,
                                  EstadoVuelo = estadoVuelo.Estado,
                                  PilotoNombre = piloto.Nombre,
                                  PilotoApellido = piloto.Apellido,
                                  Prioridad = prioridad.Nombre,
                                  TipoVuelo = tipoVuelo.Descripcion,
                                  Origen = origen.NombreCiudad,
                                  Destino = destino.NombreCiudad,
                                  AeropuertoOLatitud = aeropuertoOrigenlatitudLongitud.Latitud,
                                  AeropuertoOLontigud = aeropuertoOrigenlatitudLongitud.Longitud,
                                  AeropuertoDLatitud = aeropuertoDestinolatitudLongitud.Latitud,
                                  AeropuertoDLongitud = aeropuertoDestinolatitudLongitud.Longitud,
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
                Console.WriteLine($"Error al obtener el vuelo con código {codigoVuelo}: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("api/Vuelos/ActualizarEstado/{id}")]
        public IHttpActionResult ActualizarEstado(int id, [FromBody] int nuevoIdEstado)
        {
            try
            {
                // Obtener el vuelo con el ID proporcionado
                var vuelo = VuelosEntidad.Vuelos.FirstOrDefault(v => v.IdVuelo == id);
                if (vuelo == null)
                {
                    return NotFound(); // Vuelo no encontrado
                }

                // Verificar si el nuevo estado de vuelo existe
                var estadoVuelo = VuelosEntidad.EstadoVuelo.FirstOrDefault(ev => ev.IdEstadoVuelo == nuevoIdEstado);
                if (estadoVuelo == null)
                {
                    return BadRequest("El estado de vuelo especificado no existe."); // Estado de vuelo no encontrado
                }

                // Actualizar el estado del vuelo
                vuelo.IdEstadoVuelo = nuevoIdEstado;

                // Guardar los cambios en la base de datos
                VuelosEntidad.SaveChanges();

                return Ok(); // Operación exitosa
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al actualizar el estado del vuelo con ID {id}: {ex.Message}");
                return InternalServerError();
            }
        }
    }
}


