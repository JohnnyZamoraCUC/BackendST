using ClasesData;
using Controllers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
/*
namespace Controllers.Controllers
{
    public class CardsController : ApiController
    {
        private tiusr26pl_ProyectoSitiosEntities Cartitas = new tiusr26pl_ProyectoSitiosEntities();

        public CardsController()
        {
            Cartitas.Configuration.LazyLoadingEnabled = false;
            Cartitas.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        [Route("api/Cartas/ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            try
            {
                // Obtener todos los datos del modelo Final
                var todosLosDatos = Cartitas.Final.ToList();

                // Obtener el dominio del servidor
                var dominio = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

                // Modificar la ruta de la imagen
                foreach (var dato in todosLosDatos)
                {
                    // Concatenar el dominio y la ruta relativa
                    dato.rutaarchivo = dominio + "/API/" + dato.rutaarchivo;
                }

                // Devolver los datos en formato JSON
                return Ok(todosLosDatos);
            }
            catch (Exception)
            {
                // Manejar errores internos del servidor
                return InternalServerError();
            }
        }



    }
}
*/