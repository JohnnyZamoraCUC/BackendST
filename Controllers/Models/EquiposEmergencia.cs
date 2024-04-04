using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClasesData;
using Newtonsoft.Json;
namespace Controllers.Models
{
    public partial class EquiposEmergencia
    {
        [JsonIgnore]
        public virtual TipoEmergencia TipoEmergencia { get; set; }
    }
}

