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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    ///* Agregamos las librerias (using System.ComponentModel;using System.ComponentModel.DataAnnotations;)
    // para utilizar las dataNotation para validar y utilizar ciertas caracteristicas que nor permitiran
    // un mejor manejo de los datos que se ingresaran en los formularios.
    //*/

    public partial class Matricula
    {
        ///*      
        //   *[Required(ErrorMessage = "Este campo esta Vacío.")] --campo requerido y un mensaje de error.
        //   *[Compare("Contrasena")] --nos funciona para comparar con otro imput o campo.

        //   *[DataType(DataType.Date)] --para dar formato de fecha al campo.

        //   *[DisplayName(" ")] --cambia el nobre del campo en el formulario.

        //   *[MaxLengthAttribute(length: 80)] --definimos el maximo de caracteres que se pueden ingresar.

        //   *[EmailAddress] --Valida si es un correo electronico.

        //   *[DataType(DataType.Password)] --lo utilizamos para que la contraseña no sea legible (es decir Pass:*****).
        //   *[StringLength(8, ErrorMessage = ".... ", MinimumLength = 8)] --definimos la cantidad de caracteres  a ingresar y mandamos un mensaje de error. 
        //   *[RegularExpression(@"^((?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])(?=.*d)).+$")] --utilizamos una expresion regular para validar si hay 1 numero, 1 simbolo y 1 letra en Mayuscula
        // */

        public int IdMatricula { get; set; }

        [DisplayName("Id del Alumno: ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        public Nullable<int> IdAlumno { get; set; }

        [DisplayName("Fecha de registro:  ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FechaRegistro { get; set; }

        [DisplayName("Id del Usuario Que lo registro: ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        public Nullable<int> IdUsuario { get; set; }
    
        public virtual Alumnos Alumnos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
