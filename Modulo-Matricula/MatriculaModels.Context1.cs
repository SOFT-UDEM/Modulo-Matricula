﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class bdsistemaEntities : DbContext
    {
        public bdsistemaEntities()
            : base("name=bdsistemaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<ResponsableLegal> ResponsableLegal { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    
        public virtual ObjectResult<SpAlumnos_Result> SpAlumnos(Nullable<int> idAlumno, string nombre, string apellido, string direccion, Nullable<System.DateTime> fechaDeNacimiento, string sexo, string religion, string iglesiaAlaQueAsiste, string enfermedadCronica, string w_Operacion, ObjectParameter o_Mensaje)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var fechaDeNacimientoParameter = fechaDeNacimiento.HasValue ?
                new ObjectParameter("FechaDeNacimiento", fechaDeNacimiento) :
                new ObjectParameter("FechaDeNacimiento", typeof(System.DateTime));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var religionParameter = religion != null ?
                new ObjectParameter("Religion", religion) :
                new ObjectParameter("Religion", typeof(string));
    
            var iglesiaAlaQueAsisteParameter = iglesiaAlaQueAsiste != null ?
                new ObjectParameter("IglesiaAlaQueAsiste", iglesiaAlaQueAsiste) :
                new ObjectParameter("IglesiaAlaQueAsiste", typeof(string));
    
            var enfermedadCronicaParameter = enfermedadCronica != null ?
                new ObjectParameter("EnfermedadCronica", enfermedadCronica) :
                new ObjectParameter("EnfermedadCronica", typeof(string));
    
            var w_OperacionParameter = w_Operacion != null ?
                new ObjectParameter("W_Operacion", w_Operacion) :
                new ObjectParameter("W_Operacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpAlumnos_Result>("SpAlumnos", idAlumnoParameter, nombreParameter, apellidoParameter, direccionParameter, fechaDeNacimientoParameter, sexoParameter, religionParameter, iglesiaAlaQueAsisteParameter, enfermedadCronicaParameter, w_OperacionParameter, o_Mensaje);
        }
    
        public virtual ObjectResult<SpGrado_Result> SpGrado(Nullable<int> idGrado, Nullable<int> idAlumno, string grupo, string codigoNacionalDeEstudiante, string estadoDelEstudiante, string centroDeProcedencia, string w_Operacion, ObjectParameter o_Mensaje)
        {
            var idGradoParameter = idGrado.HasValue ?
                new ObjectParameter("IdGrado", idGrado) :
                new ObjectParameter("IdGrado", typeof(int));
    
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var codigoNacionalDeEstudianteParameter = codigoNacionalDeEstudiante != null ?
                new ObjectParameter("CodigoNacionalDeEstudiante", codigoNacionalDeEstudiante) :
                new ObjectParameter("CodigoNacionalDeEstudiante", typeof(string));
    
            var estadoDelEstudianteParameter = estadoDelEstudiante != null ?
                new ObjectParameter("EstadoDelEstudiante", estadoDelEstudiante) :
                new ObjectParameter("EstadoDelEstudiante", typeof(string));
    
            var centroDeProcedenciaParameter = centroDeProcedencia != null ?
                new ObjectParameter("CentroDeProcedencia", centroDeProcedencia) :
                new ObjectParameter("CentroDeProcedencia", typeof(string));
    
            var w_OperacionParameter = w_Operacion != null ?
                new ObjectParameter("W_Operacion", w_Operacion) :
                new ObjectParameter("W_Operacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpGrado_Result>("SpGrado", idGradoParameter, idAlumnoParameter, grupoParameter, codigoNacionalDeEstudianteParameter, estadoDelEstudianteParameter, centroDeProcedenciaParameter, w_OperacionParameter, o_Mensaje);
        }
    
        public virtual ObjectResult<SpMatricula_Result> SpMatricula(Nullable<int> idMatricula, Nullable<int> idAlumno, Nullable<System.DateTime> fechaRegistro, Nullable<int> idUsuario, string w_Operacion, ObjectParameter o_Mensaje)
        {
            var idMatriculaParameter = idMatricula.HasValue ?
                new ObjectParameter("IdMatricula", idMatricula) :
                new ObjectParameter("IdMatricula", typeof(int));
    
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var fechaRegistroParameter = fechaRegistro.HasValue ?
                new ObjectParameter("FechaRegistro", fechaRegistro) :
                new ObjectParameter("FechaRegistro", typeof(System.DateTime));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var w_OperacionParameter = w_Operacion != null ?
                new ObjectParameter("W_Operacion", w_Operacion) :
                new ObjectParameter("W_Operacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpMatricula_Result>("SpMatricula", idMatriculaParameter, idAlumnoParameter, fechaRegistroParameter, idUsuarioParameter, w_OperacionParameter, o_Mensaje);
        }
    
        public virtual ObjectResult<SpResponsableLegal_Result> SpResponsableLegal(Nullable<int> idResponsable, Nullable<int> idAlumno, string nombre, string parentesco, string numeroDeCedula, string ocupacion, string lugarDeTrabajo, string telefono, string correoElectronico, string direccionDelResponsable, string w_Operacion, ObjectParameter o_Mensaje)
        {
            var idResponsableParameter = idResponsable.HasValue ?
                new ObjectParameter("IdResponsable", idResponsable) :
                new ObjectParameter("IdResponsable", typeof(int));
    
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var parentescoParameter = parentesco != null ?
                new ObjectParameter("Parentesco", parentesco) :
                new ObjectParameter("Parentesco", typeof(string));
    
            var numeroDeCedulaParameter = numeroDeCedula != null ?
                new ObjectParameter("NumeroDeCedula", numeroDeCedula) :
                new ObjectParameter("NumeroDeCedula", typeof(string));
    
            var ocupacionParameter = ocupacion != null ?
                new ObjectParameter("Ocupacion", ocupacion) :
                new ObjectParameter("Ocupacion", typeof(string));
    
            var lugarDeTrabajoParameter = lugarDeTrabajo != null ?
                new ObjectParameter("LugarDeTrabajo", lugarDeTrabajo) :
                new ObjectParameter("LugarDeTrabajo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var direccionDelResponsableParameter = direccionDelResponsable != null ?
                new ObjectParameter("DireccionDelResponsable", direccionDelResponsable) :
                new ObjectParameter("DireccionDelResponsable", typeof(string));
    
            var w_OperacionParameter = w_Operacion != null ?
                new ObjectParameter("W_Operacion", w_Operacion) :
                new ObjectParameter("W_Operacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpResponsableLegal_Result>("SpResponsableLegal", idResponsableParameter, idAlumnoParameter, nombreParameter, parentescoParameter, numeroDeCedulaParameter, ocupacionParameter, lugarDeTrabajoParameter, telefonoParameter, correoElectronicoParameter, direccionDelResponsableParameter, w_OperacionParameter, o_Mensaje);
        }
    
        public virtual ObjectResult<SpUsuarios_Result> SpUsuarios(Nullable<int> idUsuario, string nombre, string apellido, string usuario, string contrasena, Nullable<bool> estado, string w_Operacion, ObjectParameter o_Mensaje)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            var w_OperacionParameter = w_Operacion != null ?
                new ObjectParameter("W_Operacion", w_Operacion) :
                new ObjectParameter("W_Operacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpUsuarios_Result>("SpUsuarios", idUsuarioParameter, nombreParameter, apellidoParameter, usuarioParameter, contrasenaParameter, estadoParameter, w_OperacionParameter, o_Mensaje);
        }
    }
}
