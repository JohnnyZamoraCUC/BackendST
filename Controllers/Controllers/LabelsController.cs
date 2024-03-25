using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using ClasesData;
using Controllers.Models;


namespace Controllers.Controllers
{
    public class LabelsController : ApiController
    {
        private readonly tiusr26pl_ProyectoSitiosEntities LabelsEntidad = new tiusr26pl_ProyectoSitiosEntities();

        public LabelsController()
        {
            LabelsEntidad.Configuration.LazyLoadingEnabled = false;
            LabelsEntidad.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        [Route("api/Labels/ObtenerLabels")]
        public IHttpActionResult ObtenerLabels()
        {
            try
            {
                var labels = LabelsEntidad.Labels.Select(l => new { Nombre = l.Nombre, Descripcion = l.Descripcion }).ToList();
                return Ok(labels);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todas las etiquetas: {ex.Message}");
                return InternalServerError();
            }
        }


        [HttpGet]
        [Route("api/Labels/ObtenerLabelsID")]
        public IHttpActionResult ObtenerLabelsID()
        {
            try
            {
                var AllLaberls = LabelsEntidad.Labels.ToList();
                return Ok(AllLaberls);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los usuarios: {ex.Message}");
                return InternalServerError();
            }
        }
        [HttpPost]
        [Route("api/Labels/AgregarLabel")]
        public IHttpActionResult AgregarLabel([FromBody] Models.Label nuevaLabel)
        {
            try
            {
                var existeLabel = LabelsEntidad.Labels.Any(l => l.Nombre == nuevaLabel.Nombre);
                if (existeLabel)
                {
                    return Conflict();
                }
                var nuevaLabelData = new ClasesData.Labels
                {
                    Nombre = nuevaLabel.Nombre,
                    Descripcion = nuevaLabel.Descripcion
                };
                LabelsEntidad.Labels.Add(nuevaLabelData);
                LabelsEntidad.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar la etiqueta: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("api/Labels/EliminarLabel/{id}")]
        public IHttpActionResult EliminarLabel(int id)
        {
            try
            {
                var label = LabelsEntidad.Labels.FirstOrDefault(l => l.IdLabel == id);
                if (label == null)
                {
                    return NotFound();
                }

                LabelsEntidad.Labels.Remove(label);
                LabelsEntidad.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la etiqueta: {ex.Message}");
                return InternalServerError();
            }
        }
        [HttpPut]
        [Route("api/Labels/ActualizarLabel/{id}")]
        public IHttpActionResult ActualizarLabel(int id, [FromBody] Models.Label labelData)
        {
            try
            {
                var label = LabelsEntidad.Labels.FirstOrDefault(l => l.IdLabel == id);
                if (label == null)
                {
                    return NotFound(); 
                }
                if (!string.IsNullOrWhiteSpace(labelData.Nombre))
                {
                    label.Nombre = labelData.Nombre;
                }
                if (!string.IsNullOrWhiteSpace(labelData.Descripcion))
                {
                    label.Descripcion = labelData.Descripcion;
                }

                LabelsEntidad.SaveChanges();

                return Ok(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la etiqueta: {ex.Message}");
                return InternalServerError();
            }
        }
    }
}