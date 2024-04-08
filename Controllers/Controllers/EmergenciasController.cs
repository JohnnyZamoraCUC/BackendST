using System;
using System.Linq;
using System.Web.Http;
using ClasesData;
using Controllers.Models;

namespace Controllers.Controllers
{
    public class EmergenciasController : ApiController
    {
        private readonly tiusr26pl_ProyectoSitiosEntities EmergenciasEntidad = new tiusr26pl_ProyectoSitiosEntities();

        [HttpGet]
        [Route("api/Emergencias/ObtenerTiposEquiposProcedimientos")]
        public IHttpActionResult ObtenerTiposEquiposProcedimientos()
        {
            try
            {
                var tiposEquiposProcedimientos = EmergenciasEntidad.TipoEmergencia
                    .Select(te => new
                    {
                        te.IdTipoEmergencia,
                        te.Tipo,
                        te.Descripcion,
                        Equipos = te.EquiposEmergencia.Select(ee => new
                        {
                            ee.IdEquipoEmergencia,
                            ee.NombreEquipo,
                            ee.Descripcion,
                            Procedimientos = ee.Procedimientos.Select(p => new
                            {
                                p.IdProcedimiento,
                                p.Nombre,
                                p.Descripcion,
                                p.Pasos,
                                p.Observaciones
                            }).ToList()
                        }).ToList()
                    }).ToList();

                return Ok(tiposEquiposProcedimientos);
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al obtener tipos de emergencia, equipos y procedimientos: {ex.Message}");
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("api/Emergencia/ObtenerReportes")]
        public IHttpActionResult ObtenerReportes()
        {
            try
            {


                var result = (from Reportes in EmergenciasEntidad.Emergencias

                              join TipoEmergencia in EmergenciasEntidad.TipoEmergencia on Reportes.idTipoProcedimiento equals TipoEmergencia.IdTipoEmergencia
                              join Vuelo in EmergenciasEntidad.Vuelos on Reportes.idvuelo equals Vuelo.IdVuelo
                              join AltitudE in EmergenciasEntidad.AltitudEmergencia on Reportes.idaltitudemergencia equals AltitudE.IdAltitudEmergencia
                              join PrioridadA in EmergenciasEntidad.PrioridadesAterrizajes on Reportes.idprioridadaterrizaje equals PrioridadA.IdPrioridadAterrizaje
                              join Usuario in EmergenciasEntidad.Usuarios on Reportes.IDUsuario equals Usuario.IdUsuario

                              select new
                              {
                                  Reportes.IdEmergencia,
                                  Reportes.FechaHoraInicio,
                                  Reportes.FechaHoraFin,
                                  Reportes.DescripcionReportada,
                                  DatoTipoE = TipoEmergencia.Descripcion,
                                  DatoVuelo = Vuelo.NumeroVuelo,
                                  DatoAltitud = AltitudE.Altitud,
                                  DatoPrioridad = PrioridadA.IdPrioridadAterrizaje,
                                  DatoUsuario = Usuario.Nombre,
                                  DatoUsuario2 = Usuario.Apellido
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
        [HttpGet]
        [Route("api/Emergencia/RealizarReportes")]
        public IHttpActionResult RealizarReportes()
        {
            try
            {


                var result = (from Reportes in EmergenciasEntidad.Emergencias

                              join TipoEmergencia in EmergenciasEntidad.TipoEmergencia on Reportes.idTipoProcedimiento equals TipoEmergencia.IdTipoEmergencia
                              join Vuelo in EmergenciasEntidad.Vuelos on Reportes.idvuelo equals Vuelo.IdVuelo
                              join AltitudE in EmergenciasEntidad.AltitudEmergencia on Reportes.idaltitudemergencia equals AltitudE.IdAltitudEmergencia
                              join PrioridadA in EmergenciasEntidad.PrioridadesAterrizajes on Reportes.idprioridadaterrizaje equals PrioridadA.IdPrioridadAterrizaje
                              join Usuario in EmergenciasEntidad.Usuarios on Reportes.IDUsuario equals Usuario.IdUsuario

                              select new
                              {
                                  Reportes.IdEmergencia,
                                  Reportes.FechaHoraInicio,
                                  Reportes.FechaHoraFin,
                                  Reportes.DescripcionReportada,
                                  DatoTipoE = TipoEmergencia.Descripcion,
                                  DatoVuelo = Vuelo.NumeroVuelo,
                                  DatoAltitud = AltitudE.Altitud,
                                  DatoPrioridad = PrioridadA.IdPrioridadAterrizaje,
                                  DatoUsuario = Usuario.Nombre,
                                  DatoUsuario2 = Usuario.Apellido

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


        /*
     {
  "IdEmergencia": 1,
  "FechaHoraInicio": "2024-04-07T02:27:14.396",
  "FechaHoraFin": "2024-04-07T02:27:14.396",
  "idTipoProcedimiento": 1,
  "idvuelo": 1,
  "idaltitudemergencia": 1,
  "idprioridadaterrizaje": "A",
  "DescripcionReportada": "Reporte Test",
  "IDUsuario": 1
}

*/
        [HttpPost]
        [Route("api/Emergencias/CrearEmergencia")]
        public IHttpActionResult CrearEmergencia([FromBody] RegistroE emergencia)
        {
            try
            {
                if (emergencia == null)
                {
                    return BadRequest("Los datos de la emergencia son nulos.");
                }

                int ultimoIdEmergencia = EmergenciasEntidad.Emergencias
                   .OrderByDescending(e => e.IdEmergencia)
                   .Select(e => e.IdEmergencia)
                   .FirstOrDefault();
                int nuevoIdEmergencia = ultimoIdEmergencia + 1;
                // Crear una nueva instancia de la entidad ClasesData.Emergencias
                var nuevaEmergencia = new ClasesData.Emergencias
                {
                    IdEmergencia = nuevoIdEmergencia,
                    FechaHoraInicio = emergencia.FechaHoraInicio,
                    FechaHoraFin = emergencia.FechaHoraFin,
                    idTipoProcedimiento = emergencia.idTipoProcedimiento,
                    idvuelo = emergencia.idvuelo,
                    idaltitudemergencia = emergencia.idaltitudemergencia,
                    idprioridadaterrizaje = emergencia.idprioridadaterrizaje,
                    DescripcionReportada = emergencia.DescripcionReportada,
                    IDUsuario = emergencia.IDUsuario
                };

                // Agregar la nueva emergencia al contexto y guardar cambios en la base de datos
                EmergenciasEntidad.Configuration.ValidateOnSaveEnabled = false;
                EmergenciasEntidad.Emergencias.Add(nuevaEmergencia);
                EmergenciasEntidad.SaveChanges();
                EmergenciasEntidad.Configuration.ValidateOnSaveEnabled = true;

                return Ok("Emergencia creada exitosamente.");
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al crear emergencia: {ex.Message}");
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("api/Emergencias/PrioridadAterizaje")]
        public IHttpActionResult PrioridadAterizaje()
        {
            try
            {
                var labels = EmergenciasEntidad.PrioridadesAterrizajes.Select(l => new { IdPrioridadAterrizaje = l.IdPrioridadAterrizaje, Descripcion = l.Descripcion }).ToList();
                return Ok(labels);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todas las etiquetas: {ex.Message}");
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("api/Emergencias/AltitudEmergencia")]
        public IHttpActionResult AltitudEmergencia()
        {
            try
            {
                var labels = EmergenciasEntidad.AltitudEmergencia.Select(l => new { IdAltitudEmergencia = l.IdAltitudEmergencia, Altitud = l.Altitud }).ToList();
                return Ok(labels);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todas las etiquetas: {ex.Message}");
                return InternalServerError();
            }


        }
    }
}
