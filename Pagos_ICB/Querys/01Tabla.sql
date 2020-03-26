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
IF OBJECT_ID('Acceso.Usuario')	IS NOT NULL
	DROP TABLE Acceso.Usuario
ELSE
	BEGIN
		CREATE TABLE Acceso.Usuario(
			idUsuario  INT IDENTITY (1,1) NOT NULL, --index de los usuarios
			nombre NVARCHAR(25) NOT NULL,	--primer nombre del usuario
			apellido NVARCHAR(25) NOT NULL, --primer apellido del usuario
			usuario NVARCHAR(26) NOT NULL,	--Primera letra del nombre en mayusculas más el apellido
									--eje: Pedro Picapiedra (PPicapiedra)
			clave NVARCHAR(20) NOT NULL, --clave de acceso
			estado INT DEFAULT 1 --El estado es por si está activo
		);
	END
GO

/*
	Los alumnos cursan los Grados que 
	van insertadas en esta tabla
*/
IF OBJECT_ID('Cuentas.Grado')	IS NOT NULL
	DROP TABLE Cuentas.Grado
ELSE
	BEGIN
		CREATE TABLE Cuentas.Grado(
			idGrado INT IDENTITY (1, 1) NOT NULL, --index del Grado
			nombreGrado NVARCHAR(30) NOT NULL, --nombre del grado
			estado INT DEFAULT 1

		);
	END
GO


/*
	contiene la informacion de los alumnos matriculados
*/
IF OBJECT_ID('Cuentas.Alumno')	IS NOT NULL
	DROP TABLE Cuentas.Alumno
ELSE
	BEGIN
		CREATE TABLE Cuentas.Alumno(
			idAlumno INT IDENTITY(1,1) NOT NULL,	--index del alumno
			identidad NVARCHAR(15),		--identidad del alumno con formato (9999-9999-99999)	
			nombres NVARCHAR (25) NOT NULL,			--nombres 
			apellidos NVARCHAR (25) NOT NULL,		--apellidos
			idGrado INT NOT NULL, --es la relacion del alumno con el grado
			beca NVARCHAR(3), --Esta seccion identifica si es becado o no.
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
			idDescuento INT IDENTITY (1, 1) NOT NULL,		--index del pedido
			nombreDescuento VARCHAR(30),					--nombre del descuento
			valor DECIMAL (6,2) NOT NULL,					--identificador del mesero que atendera la mesa
			estado INT DEFAULT 1
		);
	END
GO
--Tabla Pagos es la tabla transaccional de la base
IF OBJECT_ID('Cuentas.Pago')	IS NOT NULL
	DROP TABLE Cuentas.Pago
ELSE
	BEGIN
		CREATE TABLE Cuentas.Pago(
			idPago INT IDENTITY(1,1) NOT NULL,
			recibo VARCHAR(15) NOT NULL,
			idAlumno INT NOT NULL,
			idTipo INT NOT NULL,
			idDescuento INT,
			idMora INT,
			idUsuario INT NOT NULL,
			total DECIMAL (8,2)NOT NULL,
			fechaPago VARCHAR(15) NOT NULL,
			observacion VARCHAR(100),
			fechaRegistro DATE DEFAULT GETDATE(),
			estado INT DEFAULT 1,
		);
	END
GO
/*Tabla Tipo de pago especifica el pago realizado*/
IF OBJECT_ID('Cuentas.TipoPago')	IS NOT NULL
	DROP TABLE Cuentas.TipoPago
ELSE
	BEGIN
		CREATE TABLE Cuentas.TipoPago(
			idTipoPago INT IDENTITY (1,1) NOT NULL,
			idNombreTipoPago INT NOT NULL,
			idGrado INT NOT NULL,
			valor DECIMAL(6,2) NOT NULL,
			estado INT DEFAULT 1		
		);
	END
GO
/*Tabla el nombre del Tipo de pago especifica el pago a realizar*/
IF OBJECT_ID('Cuentas.NombreTipoPago')	IS NOT NULL
	DROP TABLE Cuentas.NombreTipoPago
ELSE
	BEGIN
		CREATE TABLE Cuentas.NombreTipoPago(
			idNombreTipoPago INT IDENTITY (1,1) NOT NULL,
			nombreTipoPago NVARCHAR(20) NOT NULL,
			fechaLimite NVARCHAR(15) NOT NULL,
			estado INT DEFAULT 1		
		);
	END
GO
/*Tabla de mora es donde se añaden los 
	cargos por demorar en los pagos*/
IF OBJECT_ID('Cuentas.Mora')	IS NOT NULL
	DROP TABLE Cuentas.Mora
ELSE
	BEGIN
		CREATE TABLE Cuentas.Mora(
			idMora INT IDENTITY (1,1) NOT NULL,
			nombreMora NVARCHAR(20) NOT NULL,
			valor DECIMAL(6,2) NOT NULL,
			estado INT DEFAULT 1
		);
	END
GO