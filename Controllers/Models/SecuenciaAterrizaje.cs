using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controllers.Models
{
    public class SecuenciaAterrizaje
    {
        public string IDSecuencia { get; set; }
        public int IdAeronave { get; set; }
        public string ETA { get; set; }
        public int IDClima { get; set; }
        public string Instrucciones_especiales { get; set; }
        public string Prioridad { get; set; }
    }
}
