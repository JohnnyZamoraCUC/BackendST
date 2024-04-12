using System;
using System.Linq;
using System.Web.Http;
using Controllers.Models;
using ClasesData;

using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
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

        private void ActualizarUbicacionAvion(string codigoVuelo, List<Tuple<double, double>> puntosIntermedios)
        {
            int index = 0; // Índice inicial de la lista de puntos intermedios

            while (true)
            {
                try
                {
                    // Obtener detalles del vuelo por código de vuelo
                    var vuelo = VuelosEntidad.Vuelos.FirstOrDefault(v => v.NumeroVuelo == codigoVuelo);
                    if (vuelo == null)
                    {
                        Console.WriteLine($"Vuelo con código {codigoVuelo} no encontrado.");
                        return;
                    }

                    // Obtener la aeronave asociada al vuelo
                    var aeronave = VuelosEntidad.Aeronaves.FirstOrDefault(a => a.IdAeronave == vuelo.IDAeronave);
                    if (aeronave == null)
                    {
                        Console.WriteLine($"Aeronave del vuelo con código {codigoVuelo} no encontrada.");
                        return;
                    }

                    // Obtener las coordenadas del punto intermedio actual
                    var currentPoint = puntosIntermedios[index];
                    var latitud = currentPoint.Item1;
                    var longitud = currentPoint.Item2;

                    // Actualizar la ubicación de la aeronave
                    aeronave.Latitud = (decimal?)latitud;
                    aeronave.Longitud = (decimal?)longitud;
                    VuelosEntidad.SaveChanges();

                    Console.WriteLine($"Ubicación actualizada para avión con ID {aeronave.IdAeronave} en vuelo {codigoVuelo}: Latitud = {latitud}, Longitud = {longitud}");

                    // Avanzar al siguiente punto intermedio circularmente
                    index = (index + 1) % puntosIntermedios.Count;

                    // Esperar 2 segundos antes de la próxima actualización
                    Thread.Sleep(2000); // Esperar 2000 milisegundos (equivalente a 2 segundos)
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar la ubicación del avión: {ex.Message}");
                }
            }
        }


        private List<Tuple<double, double>> CalcularPuntosIntermedios(double startLat, double startLon, double endLat, double endLon, int numPoints)
        {
            var points = new List<Tuple<double, double>>();

            for (int i = 0; i <= numPoints; i++)
            {
                var interp = (double)i / numPoints;

                // Modifica la interpolación para ajustar la curvatura de la ruta
                var curveFactor = Math.Pow(interp, 2); // Utiliza una función cuadrática para la curvatura

                var newLat = (1 - interp) * startLat + interp * endLat;
                var newLon = (1 - interp) * startLon + interp * endLon;

                // Aplica el factor de curvatura a los puntos intermedios
                newLat = (1 - curveFactor) * startLat + curveFactor * newLat;
                newLon = (1 - curveFactor) * startLon + curveFactor * newLon;

                points.Add(new Tuple<double, double>(newLat, newLon));
            }

            return points;
        }




        [HttpGet]
        [Route("api/Vuelos/CalcularPuntosIntermedios")]
        public IHttpActionResult CalcularPuntosIntermedios(string codigoVuelo)
        {
            try
            {
                // Verificar el estado del vuelo antes de calcular puntos intermedios
                var vuelo = VuelosEntidad.Vuelos.FirstOrDefault(v => v.NumeroVuelo == codigoVuelo);
                if (vuelo == null)
                {
                    return NotFound(); // Vuelo no encontrado
                }

                var estadoVuelo = vuelo.IdEstadoVuelo;
                if (estadoVuelo != 3)
                {
                    return BadRequest("El vuelo no se encuentra en estado de vuelo.");
                }

                // Obtener coordenadas de origen y destino
                var aeropuertoOrigen = VuelosEntidad.Aeropuertos.FirstOrDefault(a => a.IdAeropuerto == vuelo.IDOrigen);
                var aeropuertoDestino = VuelosEntidad.Aeropuertos.FirstOrDefault(a => a.IdAeropuerto == vuelo.IDDestino);
                if (aeropuertoOrigen == null || aeropuertoDestino == null)
                {
                    return NotFound(); // Aeropuertos no encontrados
                }

                // Calcular puntos intermedios entre las coordenadas de origen y destino
                var startLat = (double)aeropuertoOrigen.Latitud;
                var startLon = (double)aeropuertoOrigen.Longitud;
                var endLat = (double)aeropuertoDestino.Latitud;
                var endLon = (double)aeropuertoDestino.Longitud;
                var numPoints = 50;

                var points = CalcularPuntosIntermedios(startLat, startLon, endLat, endLon, numPoints);
                var thread = new Thread(() => ActualizarUbicacionAvion(codigoVuelo, points));
                thread.Start();
                // Devolver los puntos intermedios como resultado
                return Ok(points);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular puntos intermedios: {ex.Message}");
                return InternalServerError();
            }
        }
    }
}

