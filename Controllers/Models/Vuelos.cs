using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controllers.Models
{
    public class Vuelos
    {
        public int IdVuelo { get; set; }
        public string NumeroVuelo { get; set; }
        public int IdAerolinea { get; set; }
        public int IdAeronave { get; set; }
        public int IdEstadoVuelo { get; set; }
        public int IdPiloto { get; set; }
        public int IdPrioridad { get; set; }
        public int IDTipoVuelo { get; set; }
        public int IDOrigen { get; set; }
        public int IDDestino { get; set; }
        public string Ruta { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraLlegada { get; set; }
        public int DuracionEstimada { get; set; }
  
    }
}