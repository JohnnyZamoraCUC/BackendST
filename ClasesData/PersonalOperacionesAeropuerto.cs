//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClasesData
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonalOperacionesAeropuerto
    {
        public int IdOperaciones { get; set; }
        public string IdUsuario { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
