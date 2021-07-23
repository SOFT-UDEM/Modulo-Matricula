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
    using System.Text.RegularExpressions;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Matricula = new HashSet<Matricula>();
        }


        ///* Agregamos las librerias (using System.ComponentModel;using System.ComponentModel.DataAnnotations;)
        // para utilizar las dataNotation para validar y utilizar ciertas caracteristicas que nor permitiran
        // un mejor manejo de los datos que se ingresaran en los formularios.
        //*/

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



        public int IdUsuario { get; set; }
        
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [DisplayName("Nombre: ")]
        [MaxLengthAttribute(length: 80)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [DisplayName("Apellidos: ")]
        [MaxLengthAttribute(length: 80)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [DisplayName("Correo: ")]
        [EmailAddress]
        [MaxLengthAttribute(length: 30)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [DisplayName("Ingrese su Contraseña: ")]
        [StringLength(maximumLength: 64, MinimumLength = 8, ErrorMessage = "Solo se puede ingresar 8 caracteres")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^\A([^a-z][^A-Z][^0-9][^(!#$%&¡?¿@)])\Z$", ErrorMessage = "Debe contener Mayusculas,Numeros y Simbolos.")]
        
        public string Contrasena { get; set; }


        //agregaos este campo para confirmar contraseña.

        //[DisplayName("Confirmar tu Contraseña: ")]
        //[Compare("Contrasena")]
        //[DataType(DataType.Password)]
        //[StringLength(maximumLength: 64, MinimumLength = 8, ErrorMessage = "Solo se puede ingresar 8 caracteres")]
        //public string Contrasena2 { get; set; }


        [DisplayName("Rol de administrador:")]
        public Nullable<bool> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }
        public string _contrasena { get; private set; }
    }
}
