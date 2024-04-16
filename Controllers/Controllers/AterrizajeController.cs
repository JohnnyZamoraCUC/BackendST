using System;
using System.Linq;
using System.Web.Http;
using Controllers.Models;
using ClasesData;

using System.Web;
using Newtonsoft.Json;
using System.Net;
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

        //Obtiene aproximaciones que esten listas para aterrizar
        [HttpGet]
        [Route("api/Aterrizaje/ObtenerAproximacion")]
        public IHttpActionResult ObtenerAproximaciones(string Aeroport)
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
                              where Aeropuerto.Nombre == Aeroport //filtrar solo naves listas para aterrizar
                              select new
                              {
                                  Aerolinea = Aerolinea.NombreAerolinea,
                                  Vuelo = Vuelo.NumeroVuelo,
                                  NombrePiloto = piloto.Nombre,
                                  ApellidoPiloto = piloto.Apellido,
                                  Aeronave = Aeronave.Modelo,
                                  Prioridad = prioridad.Nombre,
                                  Destino = Aeropuerto.Nombre,
                                  AeronaveImagen = rutaDominio + "/BackendST/" + Aeronave.Rutaimagen,
                              }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener aterrizajes: {ex.Message}");
                return InternalServerError();
            }
        }

        //busca todos los aeropuertos con aterrizajes pendientes
        [HttpGet]
        [Route("api/Aterrizaje/ObtenerAeropuertos")]
        public IHttpActionResult ObtenerAeropuertos()
        {
            try
            {
                var result = (from Aeropuertos in VuelosEntidad.Aeropuertos
                              select new
                              {
                                  Aeropuerto = Aeropuertos.Nombre
                              }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener aeropuertos: {ex.Message}");
                return InternalServerError();
            }
        }

        //Obtiene el dominio para las imagenes
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

        //Obitene informacion de vuelos
        [HttpGet]
        [Route("api/Aterrizaje/InfoVuelo")]
        public IHttpActionResult ObtenerVuelo(string codigoVuelo)
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
                              where vuelo.NumeroVuelo == codigoVuelo
                              select new
                              {
                                  idaero = aeronave.IdAeronave,
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
                                  Lat = aeronave.Latitud,
                                  lon = aeronave.Longitud
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

        //Obtiene datos minimos
        [HttpGet]
        [Route("api/Aterrizaje/DatosMinimos")]
        public IHttpActionResult ObtenerDatosMinimos()
        {
            try
            {
                var result = (from DatosMinimosAterrizaje in VuelosEntidad.DatosMinimosAterrizaje
                              select new
                              {
                                  idDatos = DatosMinimosAterrizaje.IdDatosMinimos,
                                  VelocidadMin = DatosMinimosAterrizaje.VelocidadMinima,
                                  AltitudMin = DatosMinimosAterrizaje.AltitudMinima,
                                  CombustibleMin = DatosMinimosAterrizaje.CombustibleMinimo,
                                  AngDescenso = DatosMinimosAterrizaje.AnguloDescensoMinimo,
                                  PermisoAproximacion = DatosMinimosAterrizaje.PermisoTorreAproximaciones
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos minimos: {ex.Message}");
                return InternalServerError();
            }
        }

        //Obtiene informacion de las pistas segun el aeropuerto
        [HttpGet]
        [Route("api/Aterrizaje/InfoPistas")]
        public IHttpActionResult ObtenerPista(string CodAeropuerto)
        {
            try
            {
                var result = (from Pista in VuelosEntidad.Pistas

                              join Aeropuerto in VuelosEntidad.Aeropuertos on Pista.IdAeropuerto equals Aeropuerto.IdAeropuerto
                              join EstPista in VuelosEntidad.EstadoPista on Pista.IdPista equals EstPista.IdPista
                              where Aeropuerto.Nombre == CodAeropuerto
                              select new
                              {
                                  idestadoPista = EstPista.IdEstadoPista,
                                  Pista = Pista.IdPista,
                                  EstPista = EstPista.Estado,
                                  Disponibilidad = EstPista.Disponible,
                                  Longi = Pista.Longitud,
                                  AnchoPista = Pista.Ancho,
                                  Comentarios = EstPista.Observaciones
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las pistas: {ex.Message}");
                return InternalServerError();
            }
        }

        //Obtiene el numero de secuencias de aterrizaje
        [HttpGet]
        [Route("api/Aterrizaje/Secuencia")]
        public IHttpActionResult ObtenerSecuencias()
        {
            try
            {
                var result = (from Secuencias in VuelosEntidad.SecuenciaAterrizaje
                              select new
                              {
                                  idSecuencia = Secuencias.IDSecuencia
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos minimos: {ex.Message}");
                return InternalServerError();
            }
        }

        //Obtiene el numero de secuencias de aterrizaje
        [HttpGet]
        [Route("api/Aterrizaje/Aterrizajes")]
        public IHttpActionResult ObtenerAterrizajes()
        {
            try
            {
                var result = (from Aterrizaje in VuelosEntidad.Aterrizajes
                              select new
                              {
                                  idAterrizaje = Aterrizaje.IdAterrizaje
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos minimos: {ex.Message}");
                return InternalServerError();
            }
        }

        //Obtiene el numero de secuencias de aterrizaje
        [HttpGet]
        [Route("api/Aterrizaje/Clima")]
        public IHttpActionResult ObtenerClima()
        {
            try
            {
                var result = (from Clima in VuelosEntidad.InformacionMeteorologica
                              select new
                              {
                                  idClima = Clima.IdInformacionMetereologica,
                                  InfFechaHora = Clima.FechaHora,
                                  InfTemperatura = Clima.Temperatura,
                                  InfVientoDir = Clima.VientoDireccion,
                                  InfVientoVel = Clima.VientoVelocidad,
                                  InfVisible = Clima.Visibilidad,
                                  InfLluvia = Clima.Precipitacion
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos minimos: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/Aterrizaje/Prioridad")]
        public IHttpActionResult ObtenerPrioridad()
        {
            try
            {
                var result = (from Prioridad in VuelosEntidad.PrioridadesAterrizajes
                              select new
                              {
                                  IdPrioridad = Prioridad.IdPrioridadAterrizaje,
                                  Nombre = Prioridad.Descripcion
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos minimos: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Emergencias/CrearSecuencia")]
        public IHttpActionResult Secuencia([FromBody] Models.SecuenciaAterrizaje InfoSecuencia)
        {
            try
            {
                if (InfoSecuencia == null)
                {
                    return BadRequest("Los datos de la secuencia son nulos.");
                }

               /* int ultimoIdClima = VuelosEntidad.SecuenciaAterrizaje
                   .OrderByDescending(e => e.)
                   .Select(e => e.IdInformacionMetereologica)
                   .FirstOrDefault();
                int nuevoIdClima = ultimoIdClima + 1;*/

                var nuevo = new ClasesData.SecuenciaAterrizaje
                {
                    IDSecuencia = InfoSecuencia.IDSecuencia,
                    IdAeronave = InfoSecuencia.IdAeronave,
                    ETA = InfoSecuencia.ETA,
                    IDClima = InfoSecuencia.IDClima,
                    Instrucciones_especiales = InfoSecuencia.Instrucciones_especiales,
                    Prioridad = InfoSecuencia.Prioridad
                };

                // Agregar la nueva emergencia al contexto y guardar cambios en la base de datos
                VuelosEntidad.Configuration.ValidateOnSaveEnabled = false;
                VuelosEntidad.SecuenciaAterrizaje.Add(nuevo);
                VuelosEntidad.SaveChanges();
                VuelosEntidad.Configuration.ValidateOnSaveEnabled = true;

                return Ok("Clima registrado.");
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al registrar clima: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Emergencias/CrearAterrizaje")]
        public IHttpActionResult Secuencia([FromBody] Aterrizaje InfoAterrizaje)
        {
            
            try
            {
                if (InfoAterrizaje == null)
                {
                    return BadRequest("Los datos de aterrizaje son nulos.");
                }

                var nuevo = new ClasesData.Aterrizajes
                {
                    IdAterrizaje = InfoAterrizaje.IdAterrizaje,
                    IDSecuencia = InfoAterrizaje.IdSecuencia,
                    IdDatosMinimos = InfoAterrizaje.IdDatosMinimos,
                    IdEstadoPista = InfoAterrizaje.IdEstadoPista,
                    idemergencia = InfoAterrizaje.idemergencia,
                    PermisoAterrizaje = InfoAterrizaje.PermisoAterrizaje
                };

                // Agregar la nueva emergencia al contexto y guardar cambios en la base de datos
                VuelosEntidad.Configuration.ValidateOnSaveEnabled = false;
                VuelosEntidad.Aterrizajes.Add(nuevo);
                VuelosEntidad.SaveChanges();
                VuelosEntidad.Configuration.ValidateOnSaveEnabled = true;

                return Ok("Aterrizaje registrado.");
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al registrar clima: {ex.Message}");
                return InternalServerError();
            }
        }

    }
}
