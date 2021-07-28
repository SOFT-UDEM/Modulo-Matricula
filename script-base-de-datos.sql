/*
			****** Script Base de datos ********
				**** Módulo Matrícula ****
*/

USE master
GO

--Comprobar si existe la base de datos.
IF EXISTS(SELECT * FROM sys.databases WHERE name='bdsistema')
BEGIN
	ALTER DATABASE bdsistema SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE bdsistema
END
GO

--Creamos la base de datos.
CREATE DATABASE bdsistema
GO

--Crear y asignar usuarios.
IF EXISTS(SELECT name FROM master.dbo.syslogins WHERE name='userbdsistema')
BEGIN
	DROP LOGIN userbdsistema
END
GO

--Crear login para el servidor.
CREATE LOGIN userbdsistema WITH PASSWORD = '$Udem2021*', DEFAULT_DATABASE = bdsistema
GO

USE bdsistema
GO

--Crear usuario para base de datos.
CREATE USER userbdsistema FOR LOGIN userbdsistema
GO

--Asignar rol de usuario.
EXEC sp_addrolemember 'db_owner', 'userbdsistema'
GO

/*
	Creación de tablas.
*/

-- Tabla Usuarios.
CREATE TABLE Usuarios (
	IdUsuario INT IDENTITY,
	Nombre Varchar(80),
	Apellido VARCHAR(80),
	Usuario VARCHAR(30),
	Contrasena VARCHAR(200),
	Estado Bit,
	CONSTRAINT pk_Usuarios_IdUsuario PRIMARY KEY NONCLUSTERED(IdUsuario)
)
GO

-- Tabla alumno.
CREATE TABLE Alumnos (
	IdAlumno INT IDENTITY,
	Nombre VARCHAR(80),
	Apellido VARCHAR(80),
	Direccion VARCHAR(255),
	FechaDeNacimiento DATE,
	Sexo VARCHAR(10),
	Religion VARCHAR(20),
	IglesiaAlaQueAsiste VARCHAR(60),
	EnfermedadCronica VARCHAR(100),
	CONSTRAINT pk_Alumnos_IdAlumno PRIMARY KEY NONCLUSTERED(IdAlumno)
)
GO

-- Tabla Matricula
CREATE TABLE Matricula (
	IdMatricula INT IDENTITY,
	IdAlumno INT,
	FechaRegistro DATE,
	IdUsuario INT,
	CONSTRAINT pk_Matricula_IdMatricula PRIMARY KEY NONCLUSTERED(IdMatricula),
	CONSTRAINT fk_Matricula_IdAlumno FOREIGN KEY(IdAlumno) REFERENCES Alumnos(IdAlumno) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT fk_Matricula_IdUsuario FOREIGN KEY(IdUsuario) REFERENCES Usuarios(IdUsuario) ON UPDATE CASCADE ON DELETE CASCADE
)
GO

-- Tabla ResponsabeLegal
CREATE TABLE ResponsableLegal (
	IdResponsable INT IDENTITY,
	IdAlumno INT,
	Nombre VARCHAR(80),
	Parentesco VARCHAR(20),
	NumeroDeCedula VARCHAR(20),
	Ocupacion VARCHAR(30),
	LugarDeTrabajo VARCHAR(60),
	Telefono VARCHAR(30),
	CorreoElectronico VARCHAR(100),
	DireccionDelResponsable VARCHAR(255),
	CONSTRAINT pk_ResponsableLegal_IdResponsable PRIMARY KEY NONCLUSTERED(IdResponsable),
	CONSTRAINT fk_ResponsableLegal_IdAlumno FOREIGN KEY(IdAlumno) REFERENCES Alumnos(IdAlumno) ON UPDATE CASCADE ON DELETE CASCADE
)
GO

-- Tabla Grado
CREATE TABLE Grado (
	IdGrado INT IDENTITY,
	IdAlumno INT,
	Grupo VARCHAR(50),
	CodigoNacionalDeEstudiante VARCHAR(50),
	EstadoDelEstudiante VARCHAR(40),
	CentroDeProcedencia VARCHAR(100),
	CONSTRAINT pk_Grado_IdGrado PRIMARY KEY NONCLUSTERED(IdGrado),
	CONSTRAINT fk_Grado_IdAlumno FOREIGN KEY(IdAlumno) REFERENCES Alumnos(IdAlumno) ON UPDATE CASCADE ON DELETE CASCADE
)
GO

/**
	Procedimientos almacenados
**/

-- Procedimiento almacenado de Usuarios
CREATE PROCEDURE SpUsuarios
(
	@IdUsuario INT,
	@Nombre Varchar(80),
	@Apellido VARCHAR(80),
	@Usuario VARCHAR(30),
	@Contrasena VARCHAR(200),
	@Estado Bit,
	-- Variable de trabajo Work.
	@W_Operacion VARCHAR(10),
	-- Variable de salida OUTPUT.
	@O_Mensaje VARCHAR(255) OUTPUT
)
AS
BEGIN
	BEGIN TRY
	--Validar tipo de operación "I" es INSERT
	IF (@W_Operacion = 'I')
	BEGIN
		INSERT INTO Usuarios
		(
			Nombre,
			Apellido,
			Usuario,
			Contrasena,
			Estado
		)
		VALUES
		(
			@Nombre,
			@Apellido,
			@Usuario,
			@Contrasena,
			@Estado
		)
		SELECT @O_Mensaje = 'SE HA INSERTADO CORRECTAMENTE EN LA TABLA USUARIOS.'
	END
	--fin de isertado.
	--Validar tipo de operación "U" es UPDATE
	IF (@W_Operacion = 'U')
	BEGIN
		UPDATE Usuarios
			SET
				Nombre = @Nombre,
				Apellido = @Apellido,
				Contrasena = @Contrasena,
				Estado = @Estado
				WHERE IdUsuario = @IdUsuario
			SELECT @O_Mensaje = 'SE HA ACTUALIZADO CORRECTAMENTE UN REGISTRO DE LA TABLA USUARIOS.'
	END
	--fin de actualizado.
	--Validar tipo de operación "S" es SELECT.
	IF (@W_Operacion = 'S')
	BEGIN
		SELECT Nombre, Apellido, Usuario, Estado
			FROM Usuarios
		SELECT @O_Mensaje = 'SE REALIZO UN SELECT CORRECTAMENTE A LA TABLA USUARIOS.'
	END
	--fin de select.
	--Validar tipo de operación "D" es DELETE.
	IF (@W_Operacion = 'D')
	BEGIN
		DELETE Usuarios WHERE IdUsuario = @IdUsuario
		SELECT @O_Mensaje = 'SE HA ELIMINADO UN REGISTRO DE LA TABLA USUARIOS.'
	END
	--fin de delete.
	END TRY
	BEGIN CATCH
		-- Si ocurrio un error lo notificamos.
		SELECT @O_Mensaje = 'ERROR: ' + ERROR_MESSAGE() + 'EN LINEA: ' + CONVERT(VARCHAR, ERROR_LINE() )
	END CATCH
END
GO
-- Fin procedimiento almacenado Usuarios.

-- Procedimiento almacenado de Alumnos
CREATE PROCEDURE SpAlumnos
(
	@IdAlumno INT,
	@Nombre VARCHAR(80),
	@Apellido VARCHAR(80),
	@Direccion VARCHAR(255),
	@FechaDeNacimiento DATE,
	@Sexo VARCHAR(10),
	@Religion VARCHAR(20),
	@IglesiaAlaQueAsiste VARCHAR(60),
	@EnfermedadCronica VARCHAR(100),
	-- Variable de trabajo Work.
	@W_Operacion VARCHAR(10),
	-- Variable de salida OUTPUT.
	@O_Mensaje VARCHAR(255) OUTPUT
)
AS
BEGIN
	BEGIN TRY
	--Validar tipo de operación "I" es INSERT
	IF (@W_Operacion = 'I')
	BEGIN
		INSERT INTO Alumnos
		(
			Nombre,
			Apellido,
			Direccion,
			FechaDeNacimiento,
			Sexo,
			Religion,
			IglesiaAlaQueAsiste,
			EnfermedadCronica
		)
		VALUES
		(
			@Nombre,
			@Apellido,
			@Direccion,
			@FechaDeNacimiento,
			@Sexo,
			@Religion,
			@IglesiaAlaQueAsiste,
			@EnfermedadCronica
		)
		SELECT @O_Mensaje = 'SE HA INSERTADO CORRECTAMENTE EN LA TABLA ALUMNOS.'
	END
	--fin de isertado.
	--Validar tipo de operación "U" es UPDATE
	IF (@W_Operacion = 'U')
	BEGIN
		UPDATE Alumnos
			SET
				Nombre = @Nombre,
				Apellido = @Apellido,
				Direccion = @Direccion,
				FechaDeNacimiento = @FechaDeNacimiento,
				Sexo = @Sexo,
				Religion = @Religion,
				IglesiaAlaQueAsiste = @IglesiaAlaQueAsiste,
				EnfermedadCronica = @EnfermedadCronica
				WHERE IdAlumno = @IdAlumno
			SELECT @O_Mensaje = 'SE HA ACTUALIZADO CORRECTAMENTE UN REGISTRO DE LA TABLA ALUMNOS.'
	END
	--fin de actualizado.
	--Validar tipo de operación "S" es SELECT.
	IF (@W_Operacion = 'S')
	BEGIN
		SELECT Nombre, Apellido, Direccion, FechaDeNacimiento, Sexo, Religion, IglesiaAlaQueAsiste, EnfermedadCronica
			FROM Alumnos
		SELECT @O_Mensaje = 'SE REALIZO UN SELECT CORRECTAMENTE A LA TABLA ALUMNOS.'
	END
	--fin de select.
	--Validar tipo de operación "D" es DELETE.
	IF (@W_Operacion = 'D')
	BEGIN
		DELETE Alumnos WHERE IdAlumno = @IdAlumno
		SELECT @O_Mensaje = 'SE HA ELIMINADO UN REGISTRO DE LA TABLA ALUMNOS.'
	END
	--fin de delete.
	END TRY
	BEGIN CATCH
		-- Si ocurrio un error lo notificamos.
		SELECT @O_Mensaje = 'ERROR: ' + ERROR_MESSAGE() + 'EN LINEA: ' + CONVERT(VARCHAR, ERROR_LINE() )
	END CATCH
END
GO
-- Fin procedimiento almacenado alumnos.

-- Procedimiento almacenado de Matricula
CREATE PROCEDURE SpMatricula
(
	@IdMatricula INT,
	@IdAlumno INT,
	@FechaRegistro DATE,
	@IdUsuario INT,
	-- Variable de trabajo Work.
	@W_Operacion VARCHAR(10),
	-- Variable de salida OUTPUT.
	@O_Mensaje VARCHAR(255) OUTPUT
)
AS
BEGIN
	BEGIN TRY
	--Validar tipo de operación "I" es INSERT
	IF (@W_Operacion = 'I')
	BEGIN
		INSERT INTO Matricula
		(
			IdAlumno,
			FechaRegistro,
			IdUsuario
		)
		VALUES
		(
			@IdAlumno,
			@FechaRegistro,
			@IdUsuario
		)
		SELECT @O_Mensaje = 'SE HA INSERTADO CORRECTAMENTE EN LA TABLA MATRICULA.'
	END
	--fin de isertado.
	--Validar tipo de operación "U" es UPDATE
	IF (@W_Operacion = 'U')
	BEGIN
		UPDATE Matricula
			SET
				IdAlumno = @IdAlumno,
				FechaRegistro = @FechaRegistro,
				IdUsuario = @IdUsuario
				WHERE IdMatricula = @IdMatricula
			SELECT @O_Mensaje = 'SE HA ACTUALIZADO CORRECTAMENTE UN REGISTRO DE LA TABLA MATRICULA.'
	END
	--fin de actualizado.
	--Validar tipo de operación "S" es SELECT.
	IF (@W_Operacion = 'S')
	BEGIN
		SELECT IdMatricula, IdAlumno, FechaRegistro, IdUsuario
			FROM Matricula
		SELECT @O_Mensaje = 'SE REALIZO UN SELECT CORRECTAMENTE A LA TABLA MATRICULAS.'
	END
	--fin de select.
	--Validar tipo de operación "D" es DELETE.
	IF (@W_Operacion = 'D')
	BEGIN
		DELETE Matricula WHERE IdMatricula = @IdMatricula
		SELECT @O_Mensaje = 'SE HA ELIMINADO UN REGISTRO DE LA TABLA MATRICULAS.'
	END
	--fin de delete.
	END TRY
	BEGIN CATCH
		-- Si ocurrio un error lo notificamos.
		SELECT @O_Mensaje = 'ERROR: ' + ERROR_MESSAGE() + 'EN LINEA: ' + CONVERT(VARCHAR, ERROR_LINE() )
	END CATCH
END
GO
-- Fin procedimiento almacenado matricula.

-- Procedimiento almacenado de ResponsableLegal
CREATE PROCEDURE SpResponsableLegal
(
	@IdResponsable INT,
	@IdAlumno INT,
	@Nombre VARCHAR(80),
	@Parentesco VARCHAR(20),
	@NumeroDeCedula VARCHAR(20),
	@Ocupacion VARCHAR(30),
	@LugarDeTrabajo VARCHAR(60),
	@Telefono VARCHAR(30),
	@CorreoElectronico VARCHAR(100),
	@DireccionDelResponsable VARCHAR(255),
	-- Variable de trabajo Work.
	@W_Operacion VARCHAR(10),
	-- Variable de salida OUTPUT.
	@O_Mensaje VARCHAR(255) OUTPUT
)
AS
BEGIN
	BEGIN TRY
	--Validar tipo de operación "I" es INSERT
	IF (@W_Operacion = 'I')
	BEGIN
		INSERT INTO ResponsableLegal
		(
			IdAlumno,
			Nombre,
			Parentesco,
			NumeroDeCedula,
			Ocupacion,
			LugarDeTrabajo,
			Telefono,
			CorreoElectronico,
			DireccionDelResponsable
		)
		VALUES
		(
			@IdAlumno,
			@Nombre,
			@Parentesco,
			@NumeroDeCedula,
			@Ocupacion,
			@LugarDeTrabajo,
			@Telefono,
			@CorreoElectronico,
			@DireccionDelResponsable
		)
		SELECT @O_Mensaje = 'SE HA INSERTADO CORRECTAMENTE EN LA TABLA RESPONSABLELEGAL.'
	END
	--fin de isertado.
	--Validar tipo de operación "U" es UPDATE
	IF (@W_Operacion = 'U')
	BEGIN
		UPDATE ResponsableLegal
			SET
				Nombre = @Nombre,
				Parentesco = @Parentesco,
				NumeroDeCedula = @NumeroDeCedula,
				Ocupacion = @Ocupacion,
				LugarDeTrabajo = @LugarDeTrabajo,
				Telefono = @Telefono,
				CorreoElectronico = @CorreoElectronico,
				DireccionDelResponsable = @DireccionDelResponsable
				WHERE IdResponsable = @IdResponsable
			SELECT @O_Mensaje = 'SE HA ACTUALIZADO CORRECTAMENTE UN REGISTRO DE LA TABLA RESPONSABLELEGAL.'
	END
	--fin de actualizado.
	--Validar tipo de operación "S" es SELECT.
	IF (@W_Operacion = 'S')
	BEGIN
		SELECT IdResponsable, IdAlumno, Nombre, Parentesco, NumeroDeCedula, Ocupacion, LugarDeTrabajo, Telefono, CorreoElectronico, DireccionDelResponsable
			FROM ResponsableLegal
		SELECT @O_Mensaje = 'SE REALIZO UN SELECT CORRECTAMENTE A LA TABLA RESPONSABLELEGAL.'
	END
	--fin de select.
	--Validar tipo de operación "D" es DELETE.
	IF (@W_Operacion = 'D')
	BEGIN
		DELETE ResponsableLegal WHERE IdResponsable = @IdResponsable
		SELECT @O_Mensaje = 'SE HA ELIMINADO UN REGISTRO DE LA TABLA RESPONSABLELEGAL.'
	END
	--fin de delete.
	END TRY
	BEGIN CATCH
		-- Si ocurrio un error lo notificamos.
		SELECT @O_Mensaje = 'ERROR: ' + ERROR_MESSAGE() + 'EN LINEA: ' + CONVERT(VARCHAR, ERROR_LINE() )
	END CATCH
END
GO
-- Fin procedimiento almacenado matricula.

-- Procedimiento almacenado de Grado
CREATE PROCEDURE SpGrado
(
	@IdGrado INT,
	@IdAlumno INT,
	@Grupo VARCHAR(50),
	@CodigoNacionalDeEstudiante VARCHAR(50),
	@EstadoDelEstudiante VARCHAR(40),
	@CentroDeProcedencia VARCHAR(100),
	-- Variable de trabajo Work.
	@W_Operacion VARCHAR(10),
	-- Variable de salida OUTPUT.
	@O_Mensaje VARCHAR(255) OUTPUT
)
AS
BEGIN
	BEGIN TRY
	--Validar tipo de operación "I" es INSERT
	IF (@W_Operacion = 'I')
	BEGIN
		INSERT INTO Grado
		(
			IdAlumno,
			Grupo,
			CodigoNacionalDeEstudiante,
			EstadoDelEstudiante,
			CentroDeProcedencia
		)
		VALUES
		(
			@IdAlumno,
			@Grupo,
			@CodigoNacionalDeEstudiante,
			@EstadoDelEstudiante,
			@CentroDeProcedencia
		)
		SELECT @O_Mensaje = 'SE HA INSERTADO CORRECTAMENTE EN LA TABLA GRADO.'
	END
	--fin de isertado.
	--Validar tipo de operación "U" es UPDATE
	IF (@W_Operacion = 'U')
	BEGIN
		UPDATE Grado
			SET
				IdAlumno = @IdAlumno,
				Grupo = @Grupo,
				CodigoNacionalDeEstudiante = @CodigoNacionalDeEstudiante,
				EstadoDelEstudiante = @EstadoDelEstudiante,
				CentroDeProcedencia = @CentroDeProcedencia
				WHERE IdGrado = @IdGrado
			SELECT @O_Mensaje = 'SE HA ACTUALIZADO CORRECTAMENTE UN REGISTRO DE LA TABLA GRADO.'
	END
	--fin de actualizado.
	--Validar tipo de operación "S" es SELECT.
	IF (@W_Operacion = 'S')
	BEGIN
		SELECT IdGrado, IdAlumno, CodigoNacionalDeEstudiante, EstadoDelEstudiante, CentroDeProcedencia
			FROM Grado
		SELECT @O_Mensaje = 'SE REALIZO UN SELECT CORRECTAMENTE A LA TABLA GRADO.'
	END
	--fin de select.
	--Validar tipo de operación "D" es DELETE.
	IF (@W_Operacion = 'D')
	BEGIN
		DELETE Grado WHERE IdGrado = @IdGrado
		SELECT @O_Mensaje = 'SE HA ELIMINADO UN REGISTRO DE LA TABLA GRADO.'
	END
	--fin de delete.
	END TRY
	BEGIN CATCH
		-- Si ocurrio un error lo notificamos.
		SELECT @O_Mensaje = 'ERROR: ' + ERROR_MESSAGE() + 'EN LINEA: ' + CONVERT(VARCHAR, ERROR_LINE() )
	END CATCH
END
GO
-- Fin procedimiento almacenado Grado.