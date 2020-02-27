/*Base de datos para el Instituto Católico Bilingue*/

IF EXISTS(SELECT * FROM DBO.SYSDATABASES WHERE NAME = 'DBICB')
    BEGIN
		USE MASTER
        DROP DATABASE DBICB 
    END
GO

CREATE DATABASE DBICB
GO

USE DBICB
GO

CREATE SCHEMA Cuentas --contiene todas las tablas del sistemas
GO


CREATE SCHEMA Utilidad --contiene las funciones que realizaremos
GO

CREATE SCHEMA Acceso --Contiene la informacion de acceso de los usuarios
GO

/*
	contiene todos los usuarios que manejaran el sistema, 
	teniendo acceso solo a lo pertinente segun sea
	es tipo de idArea de esa seccion

	esta tabla es manejada solo por el administrador principal
*/
IF OBJECT_ID('Acceso.Usuarios')	IS NOT NULL
	DROP TABLE Acceso.Usuarios
ELSE
	BEGIN
		CREATE TABLE Acceso.Usuarios(
			id  INT IDENTITY (1,1) NOT NULL, --index de los usuarios
			nombre NVARCHAR(25) NOT NULL,	--primer nombre del usuario
			apellido NVARCHAR(25) NOT NULL, --primer apellido del usuario
			usuario NVARCHAR(26) NOT NULL,	--Primera letra del nombre en mayusculas más el apellido
									--eje: Pedro Picapiedra (PPicapiedra)
			clave NVARCHAR(20) NOT NULL, --clave de acceso
			estado BIT DEFAULT 1 --El estado es por si está activo
		);
	END
GO

/*
	esta tabla controlara los modulos que seran disponibles por cada departamento

IF OBJECT_ID('Acceso.Roles')	IS NOT NULL
	DROP TABLE Acceso.Roles
ELSE
	BEGIN
		CREATE TABLE Acceso.Roles(
			id INT IDENTITY (1,1) NOT NULL,
			nombreRol NVARCHAR(20),
			agregarUsuario BIT,
			modificarUsuario BIT,
			eliminarUsuario BIT,
			consultarUsario BIT,
			agregarProveedor BIT,
			modificarProveedor BIT,
			eliminarProveedor BIT,
			consultarProveedor BIT,
			agregarMesero BIT,
			modificarMesero BIT,
			eliminarMesero BIT,
			consultarMesero BIT,
			anularPagos BIT,
			aperturaCaja BIT,
			cierreCaja BIT
			

			/*
				falta colorcar los campos de los modulos a los cuales tendra acceso
			*/
		);
	END
GO*/



/*
	Los alumnos cursan los Grados que 
	van insertadas en esta tabla
*/
IF OBJECT_ID('Cuentas.Grados')	IS NOT NULL
	DROP TABLE Cuentas.Grados
ELSE
	BEGIN
		CREATE TABLE Cuentas.Grados(
			idGrado INT IDENTITY (1, 1) NOT NULL, --index del Grado
			nombreGrado NVARCHAR(21) NOT NULL, --nombre del grado
			estado INT DEFAULT 1

		);
	END
GO


/*
	contiene la informacion de los alumnos matriculados
*/
IF OBJECT_ID('Cuentas.Alumnos')	IS NOT NULL
	DROP TABLE Cuentas.Alumnos
ELSE
	BEGIN
		CREATE TABLE Cuentas.Alumnos(
			id INT IDENTITY(1,10) NOT NULL,		--index del alumno
			identidad NVARCHAR(15) NOT NULL,	--identidad del alumno con formato (9999-9999-99999)	
			nombres NVARCHAR (25) NOT NULL,			--nombres 
			apellidos NVARCHAR (25) NOT NULL,			--apellidos
			idGrado INT NOT NULL, --es la relacion del alumno con el grado
			beca BIT DEFAULT 0 , --Esta seccion identifica si es becado o no.
			estado INT DEFAULT 1
		);
	END
GO

/*
	contienen los Descuento que se van generando,
	a que mesa se dirige el pedido y el mesero que 
	los esta atendiendo
*/
IF OBJECT_ID('Cuentas.Descuento')	IS NOT NULL
	DROP TABLE Cuentas.Descuento
ELSE
	BEGIN
		CREATE TABLE Cuentas.Descuento(
			idDescuento INT IDENTITY (1, 1) NOT NULL,					--index del pedido
			valor DECIMAL (6,2) NOT NULL,						--identificador del mesero que atendera la mesa
			estado INT DEFAULT 1
		);
	END
GO

IF OBJECT_ID('Cuentas.Pagos')	IS NOT NULL
	DROP TABLE Cuentas.Pagos
ELSE
	BEGIN
		CREATE TABLE Cuentas.Pagos(
			idPagos INT IDENTITY(1,1) NOT NULL,
			idAlumno INT NOT NULL,
			idTipo INT NOT NULL,
			idDescuento INT NOT NULL,
			idMora INT NOT NULL,
			idUsuario INT NOT NULL,
			pagoUno DECIMAL(6,2),
			PagoDos DECIMAL(6,2),
			subTotal DECIMAL (8,2),
			total DECIMAL (8,2)NOT NULL,
			estado INT DEFAULT 1,
		);
	END
GO

IF OBJECT_ID('Cuentas.tipoPago')	IS NOT NULL
	DROP TABLE Cuentas.tipoPago
ELSE
	BEGIN
		CREATE TABLE Cuentas.tipoPago(
			idTipo INT IDENTITY (1,1) NOT NULL,
			nombrePago NVARCHAR(20) NOT NULL,
			idGrado INT NOT NULL,
			Valor DECIMAL(6,2) NOT NULL,
			estado int DEFAULT 1
			
		);
	END
GO

IF OBJECT_ID('Cuentas.Mora')	IS NOT NULL
	DROP TABLE Cuentas.Mora
ELSE
	BEGIN
		CREATE TABLE Cuentas.Mora(
			idMora INT IDENTITY (1,1) NOT NULL,
			nombreMora NVARCHAR(20) NOT NULL,
			Valor DECIMAL(6,2) NOT NULL,
			estado int DEFAULT 1

		);
	END
GO