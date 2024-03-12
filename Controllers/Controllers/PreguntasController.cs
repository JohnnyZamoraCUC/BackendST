using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ClasesData;
using Controllers.Models;

namespace Controllers.Controllers
{
    public class PreguntasApiController : ApiController
    {
        private tiusr26pl_cardsEntities Preguntitas = new tiusr26pl_cardsEntities(); // Instancia del contexto de base de datos
        private tiusr26pl_cardsEntities Respuestitas = new tiusr26pl_cardsEntities(); // Instancia del contexto de base de datos


        public PreguntasApiController()
        {
            Preguntitas.Configuration.LazyLoadingEnabled = false;
            Preguntitas.Configuration.ProxyCreationEnabled = false;
            Respuestitas.Configuration.LazyLoadingEnabled = false;
            Respuestitas.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        [Route("api/Preguntas/Pregunta")]
        public IHttpActionResult GetPreguntas()
        {
            try
            {
                // Realizar la consulta utilizando LINQ y ordenar aleatoriamente antes de tomar 10 preguntas
                var query = (from pregunta in Preguntitas.Preguntas
                             join respuesta in Preguntitas.Respuestas
                             on pregunta.PreguntaID equals respuesta.PreguntaID into respuestasPregunta
                             select new
                             {
                                 PreguntaID = pregunta.PreguntaID,
                                 DescripcionPregunta = pregunta.Pregunta,
                                 Respuestas = respuestasPregunta.Select(r => new { RespuestaID = r.id, DescripcionRespuesta = r.Respuesta }).ToList()
                             }).OrderBy(x => Guid.NewGuid()).Take(10);

                return Ok(query); // Devolver los resultados de la consulta
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Manejar cualquier excepción
            }
        }




        [HttpPost]
        [Route("api/Preguntas/VerificarRespuesta")]
        public IHttpActionResult VerificarRespuesta(int preguntaId, int respuestaId)
        {
            try
            {
                // Buscar la pregunta por su ID
                var pregunta = Preguntitas.Preguntas.FirstOrDefault(p => p.PreguntaID == preguntaId);

                if (pregunta == null)
                {
                    // Devolver un mensaje de error si la pregunta no existe
                    return BadRequest("La pregunta especificada no fue encontrada.");
                }

                // Verificar si la respuesta seleccionada es la correcta
                // Buscar la respuesta seleccionada y verificar si es la correcta
                var respuestaSeleccionada = Preguntitas.Respuestas.FirstOrDefault(r => r.PreguntaID == preguntaId && r.id == respuestaId);

                if (respuestaSeleccionada != null)
                {
                    // Verificar si la respuesta seleccionada es la correcta
                    bool esCorrecta = (bool)respuestaSeleccionada.Correcta;

                    // Devolver el resultado (1 para verdadero, 0 para falso)
                    return Ok(esCorrecta ? 1 : 0);
                }
                else
                {
                    // No se encontró la respuesta seleccionada, devolver 0
                    return Ok(0);
                }

            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                return InternalServerError(ex);
            }
        }





    }
}
