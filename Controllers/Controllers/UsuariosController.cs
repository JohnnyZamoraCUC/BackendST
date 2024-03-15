using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using ClasesData;
using Controllers.Models;
using Google.Authenticator;

namespace Controllers.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly tiusr26pl_ProyectoSitiosEntities UsuarioEntidad = new tiusr26pl_ProyectoSitiosEntities();

        public UsuariosController()
        {
            UsuarioEntidad.Configuration.LazyLoadingEnabled = false;
            UsuarioEntidad.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        [Route("api/Usuarios/ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            try
            {
                var AllUsers = UsuarioEntidad.Usuarios.ToList();
                return Ok(AllUsers);
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al obtener todos los usuarios: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Usuarios/Login")]
        public IHttpActionResult ValidarLogin([FromBody] Usuario login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos de inicio de sesión no válidos");
            }

            var usuario = UsuarioEntidad.Usuarios.FirstOrDefault(u => u.Correo == login.Correo);

            if (usuario == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            if (usuario.Contrasena != login.Contrasena)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }

            string token = GenerarTokenDobleFactor();
            usuario.CodigoVerificacion = token;
            UsuarioEntidad.Configuration.ValidateOnSaveEnabled = false;
            UsuarioEntidad.SaveChanges();
            UsuarioEntidad.Configuration.ValidateOnSaveEnabled = true; // Vuelve a habilitar la validación después de guardar

            EnviarToken(usuario.Correo, token);
            var tokenModel = new TokenModel { Correo = usuario.Correo, Token = token };
            return Ok(tokenModel);
            /*
            var tokenModel = new TokenModel { Correo = usuario.Correo, Token = token };
            return ValidarDobleFactor(tokenModel);
            */
            
        }

        [HttpPost]
        [Route("api/Usuarios/ValidarDobleFactor")]
        public IHttpActionResult ValidarDobleFactor([FromBody] TokenModel tokenModel)
        {
            var usuario = UsuarioEntidad.Usuarios.FirstOrDefault(u => u.Correo == tokenModel.Correo);

            if (usuario == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            if (tokenModel.Token != usuario.CodigoVerificacion)
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }

            usuario.CodigoVerificacion = null;
            UsuarioEntidad.SaveChanges();

            return Ok("Token de doble factor válido");
        }

        private string GenerarTokenDobleFactor()
        {
   
            var secretKey = Guid.NewGuid().ToString().Replace("-", "");
            return secretKey;
        }

        private void EnviarToken(string correo, string token)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.titan.email")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("prograiv2023@spestechnical.com", "CursoCUC2023"),
                    EnableSsl = true,
                };

                var message = new MailMessage("prograiv2023@spestechnical.com", correo)
                {
                    Subject = "Código de verificación",
                    Body = $"Su código de verificación es: {token}"
                };

                smtpClient.Send(message);
                Console.WriteLine("Correo enviado correctamente");
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
