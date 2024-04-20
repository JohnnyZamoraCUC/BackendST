using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controllers.Models
{
    public class Aterrizaje
    {
        public int IdAterrizaje { get; set; }
        public int IdDatosMinimos { get; set; }
        public int IdEstadoPista { get; set; }
        public int Idemergencia { get; set; }
        public string IdSecuencia { get; set; }
        public bool PermisoAterrizaje { get; set; }
    }
}
