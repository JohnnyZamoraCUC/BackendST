using ClasesData;
using Controllers.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
/*
namespace Controllers.Controllers
{
    public class PuntajeController : ApiController
    {
        private tiusr26pl_cardsEntities Puntos = new tiusr26pl_cardsEntities();
        public PuntajeController()
        {
            Puntos.Configuration.LazyLoadingEnabled = false;
            Puntos.Configuration.ProxyCreationEnabled = false;
        }

        // Método POST para insertar un puntaje asociado a un usuario
        [HttpPost]
        [Route("api/Preguntas/InsertarPuntaje")]
        public IHttpActionResult InsertarPuntaje([FromBody] PuntajeData data)
        {
            try
            {
                if (data == null)
                {
                    return BadRequest("Los datos del puntaje son nulos.");
                }

                // Buscar el usuario por el código de usuario
                var usuario = Puntos.Usuarios.FirstOrDefault(u => u.Codigousuario == data.CodigoUsuario);

                if (usuario != null)
                {
                    // Crear un nuevo puntaje
                    var nuevoPuntaje = new Puntaje
                    {
                        UsuarioID = usuario.id,
                        Puntaje1 = data.Puntaje
                    };

                    // Agregar el nuevo puntaje a la tabla Puntaje
                    Puntos.Puntaje.Add(nuevoPuntaje);

                    // Guardar los cambios en la base de datos
                    Puntos.SaveChanges();

                    return Ok("Puntaje insertado correctamente.");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Preguntas/ObtenerPuntaje")]
        public IHttpActionResult ObtenerPuntajes()
        {
            try
            {
                var puntajesUsuarios = (from puntaje in Puntos.Puntaje
                                        join usuario in Puntos.Usuarios
                                        on puntaje.UsuarioID equals usuario.id
                                        orderby puntaje.Puntaje1 descending
                                        select new
                                        {
                                            Nombre = usuario.Nombre,
                                            Apellido = usuario.Apellido,
                                            Puntaje = puntaje.Puntaje1
                                        }).ToList();

                return Ok(puntajesUsuarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }





        public class PuntajeData
        {
            public string CodigoUsuario { get; set; }
            public int Puntaje { get; set; }
        }
    }
}

*/