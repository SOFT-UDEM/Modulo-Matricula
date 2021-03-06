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

    public partial class Alumnos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumnos()
        {
            this.Grado = new HashSet<Grado>();
            this.Matricula = new HashSet<Matricula>();
            this.ResponsableLegal = new HashSet<ResponsableLegal>();
        }

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

        public int IdAlumno { get; set; }

        [DisplayName("Nombres de Alumno: ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [MaxLengthAttribute(length: 80)]
        public string Nombre { get; set; }

        [DisplayName(" Apellidos: ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [MaxLengthAttribute(length: 80)]
        public string Apellido { get; set; }

        [DisplayName("Direccion: ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [MaxLengthAttribute(length: 255)]
        public string Direccion { get; set; }

        [DisplayName("Fecha de ingreso: ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FechaDeNacimiento { get; set; }

        [DisplayName("Sexo: ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [MaxLengthAttribute(length:1, ErrorMessage ="solo puede ingresar 'F' o 'M'. ")]
        public string Sexo { get; set; }

        [DisplayName("Religion: ")]
        [Required(ErrorMessage = "(si no pertenese a una religion llene el campo con 'Ninguna')")]
        [MaxLengthAttribute(length: 20)]
        public string Religion { get; set; }

        [DisplayName("Nombre de la Iglesia: ")]
        [Required(ErrorMessage = "(si no pertenese a una Iglesia llene el campo con 'Ninguna').")]
        [MaxLengthAttribute(length: 60)]
        public string IglesiaAlaQueAsiste { get; set; }

        [DisplayName("Enfermedades cronicas: ")]
        [Required(ErrorMessage = "Este campo esta Vacío.")]
        [MaxLengthAttribute(length: 100, ErrorMessage ="El campo tiene un limite de 100 caracteres, Sea preciso con la descripcion de cada enfermedad.")]
        public string EnfermedadCronica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grado> Grado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResponsableLegal> ResponsableLegal { get; set; }
    }
}
