using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controllers.Models
{
    public class RegistroE
    {

        public int IdEmergencia { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public int idTipoProcedimiento { get; set; }
        public int idvuelo { get; set; }
        public int idaltitudemergencia { get; set; }
        public string idprioridadaterrizaje { get; set; }
        public string DescripcionReportada { get; set; }
        public int IDUsuario { get; set; }

    }
}