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
    }
}
