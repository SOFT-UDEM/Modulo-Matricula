//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modulo_Matricula
{
    using System;
    using System.Collections.Generic;
    
    public partial class Matricula
    {
        public int IdMatricula { get; set; }
        public Nullable<int> IdAlumno { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        public virtual Alumnos Alumnos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
