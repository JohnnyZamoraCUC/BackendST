//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClasesData
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComunicacionesControladorAutoridad
    {
        public int ID { get; set; }
        public Nullable<int> ControladorID { get; set; }
        public Nullable<int> AutoridadID { get; set; }
        public string Mensaje { get; set; }
        public System.DateTime FechaHora { get; set; }
    
        public virtual Autoridades Autoridades { get; set; }
        public virtual Controladores Controladores { get; set; }
    }
}
