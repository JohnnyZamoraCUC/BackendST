using System;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Web.Http;
using ClasesData;
using Controllers.Models; // Asegúrate de tener la referencia correcta a tu modelo de datos
/*
namespace Controllers.Controllers
{
    public class RegistroController : ApiController
    {
        private tiusr26pl_cardsEntities usuario = new tiusr26pl_cardsEntities();

        [HttpPost]
        [Route("api/Usuario/RegistrarUsuario")]
        public IHttpActionResult AgregarCategoria(Registro nuevoregistro)
        {
            try
            {
                var usuarioexistente = usuario.Usuarios.FirstOrDefault(c => c.Nombre == nuevoregistro.Nombre);

                if (usuarioexistente != null)
                {
                    return Conflict();
                }
                string codigoUsuario = GenerarCodigoUsuario();

                var nuevousuario = new Usuarios
                {
                    Nombre = nuevoregistro.Nombre,
                    Apellido = nuevoregistro.Apellido,
                    Codigousuario= codigoUsuario

                };

                usuario.Usuarios.Add(nuevousuario);
                usuario.SaveChanges();
                return Ok(new { Codigousuario = codigoUsuario });
            }
            catch (DbException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        public string GenerarCodigoUsuario()
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            string codigoUsuario = new string(Enumerable.Repeat(caracteresPermitidos, 4)
                                              .Select(s => s[random.Next(s.Length)]).ToArray());
            return codigoUsuario;
        }


    }
}
*/