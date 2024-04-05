using System;
using System.Linq;
using System.Web.Http;
using ClasesData;

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

                              join TipoEmergencia in EmergenciasEntidad.TipoEmergencia on Reportes.idTipoEmergencia equals TipoEmergencia.IdTipoEmergencia
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
    }
}
