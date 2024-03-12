using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controllers.Models
{
    public class Respuestas
    {
        public int id { get; set; }
        public int PreguntaID { get; set; }
        public string Respuesta { get; set; }
        public bool Correcta { get; set; }
    }
}