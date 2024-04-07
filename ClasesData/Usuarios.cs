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
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.AsignacionDespeguesUsuario = new HashSet<AsignacionDespeguesUsuario>();
            this.Autoridades = new HashSet<Autoridades>();
            this.Controladores = new HashSet<Controladores>();
            this.CoordinadoresTierra = new HashSet<CoordinadoresTierra>();
            this.Emergencias = new HashSet<Emergencias>();
            this.EquipoEmergenciaTierra = new HashSet<EquipoEmergenciaTierra>();
            this.PersonalCarga = new HashSet<PersonalCarga>();
            this.PersonalMantenimiento = new HashSet<PersonalMantenimiento>();
            this.PersonalOperacionesAeropuerto = new HashSet<PersonalOperacionesAeropuerto>();
            this.PersonalServiciosTierra = new HashSet<PersonalServiciosTierra>();
            this.RegistroComunicaciones = new HashSet<RegistroComunicaciones>();
            this.ReporteFinalDespegues = new HashSet<ReporteFinalDespegues>();
        }
    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public int Rol { get; set; }
        public string CodigoVerificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsignacionDespeguesUsuario> AsignacionDespeguesUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autoridades> Autoridades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Controladores> Controladores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoordinadoresTierra> CoordinadoresTierra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emergencias> Emergencias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipoEmergenciaTierra> EquipoEmergenciaTierra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalCarga> PersonalCarga { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalMantenimiento> PersonalMantenimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalOperacionesAeropuerto> PersonalOperacionesAeropuerto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalServiciosTierra> PersonalServiciosTierra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroComunicaciones> RegistroComunicaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReporteFinalDespegues> ReporteFinalDespegues { get; set; }
        public virtual Rol Rol1 { get; set; }
    }
}
