using System;
using System.Linq;
using System.Web.Http;
using Controllers.Models;
using ClasesData;
using System.Web;

namespace Controllers.Controllers
{
    public class AproximacionController : ApiController
    {
        private readonly tiusr26pl_ProyectoSitiosEntities VuelosEntidad = new tiusr26pl_ProyectoSitiosEntities();

        public AproximacionController()
        {
            VuelosEntidad.Configuration.LazyLoadingEnabled = false;
            VuelosEntidad.Configuration.ProxyCreationEnabled = false;
        }

        // Acción para crear una nueva aproximación
        [HttpPost]
        [Route("api/Aproximacion/CrearAproximacion")]
        public IHttpActionResult CrearAproximacion(Aproximaciones nuevaAproximacion)
        {
            try
            {
                // Verificar si la aproximación recibida es nula
                if (nuevaAproximacion == null)
                    return BadRequest("La aproximación recibida es nula.");

                // Lógica para guardar la nueva aproximación en la base de datos
                VuelosEntidad.Aproximaciones.Add(nuevaAproximacion);
                VuelosEntidad.SaveChanges();

                // Obtener el dominio para construir la respuesta
                var rutaDominio = ObtenerDominio();
                if (rutaDominio == null)
                    return InternalServerError();

                // Construir la respuesta con el dominio y un mensaje de éxito
                var respuesta = new
                {
                    Dominio = rutaDominio,
                    Mensaje = "Aproximación creada exitosamente."
                };

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al crear una nueva aproximación: {ex.Message}");
                return InternalServerError();
            }
        }

        // Método para obtener el dominio completo
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
    }
}
