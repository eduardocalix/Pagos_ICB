
USE DBICB
GO

--DEFINICION DE LLAVES PRIMARIAS
ALTER TABLE Acceso.Usuario
	ADD CONSTRAINT PK_Acceso_Usuarios_id
		PRIMARY KEY NONCLUSTERED(idUsuario);
GO

ALTER TABLE Cuentas.Grado
	ADD CONSTRAINT PK_Cuentas_Grados_id
		PRIMARY KEY NONCLUSTERED (idGrado);
GO

ALTER TABLE Cuentas.Alumno
	ADD CONSTRAINT PK_Cuentas_Alumnos_id
		PRIMARY KEY NONCLUSTERED (idAlumno);
GO

ALTER TABLE Cuentas.Pago
	ADD CONSTRAINT PK_Cuentas_Pagos_id
		PRIMARY KEY CLUSTERED (idPago);
GO 


ALTER TABLE Cuentas.Descuento
	ADD CONSTRAINT PK_Cuentas_Descuento_idDescuento
		PRIMARY KEY CLUSTERED (idDescuento);
GO

ALTER TABLE Cuentas.TipoPago
	ADD CONSTRAINT PK_Cuentas_tipoPago_idTipoPago
		PRIMARY KEY CLUSTERED (idTipo);
GO

ALTER TABLE Cuentas.Mora
	ADD CONSTRAINT PK_Cuentas_Mora_idMora
		PRIMARY KEY CLUSTERED(idMora);
GO

--DEFINICION DE LLAVES FORANEAS


ALTER TABLE Cuentas.Pago
	ADD CONSTRAINT FK_Cuentas_Pagos_idTipo$TieneUna$Cuentas_TipoPago
		FOREIGN KEY	(idTipo)
			REFERENCES Cuentas.TipoPago(idTipo);
GO

ALTER TABLE Cuentas.Pago
	ADD CONSTRAINT FK_Cuentas_Pago_idUsuario$TieneUn$Acceso_Usuario_idUsuario
		FOREIGN KEY	(idUsuario)
			REFERENCES Acceso.Usuario(idUsuario);
GO

ALTER TABLE Cuentas.Pago
	ADD CONSTRAINT FK_Cuentas_Alumno_id$HacenMuchos$Pagos_id
		FOREIGN KEY (idAlumno)
			REFERENCES Cuentas.Alumno(idAlumno);
GO

ALTER TABLE	Cuentas.Pago
	ADD CONSTRAINT FK_Cuentas_Pago_idDescuento$Tiene$Cuentas_Descuentos_idDescuento
		FOREIGN KEY (idDescuento)
			REFERENCES Cuentas.Descuento(idDescuento);
GO

ALTER TABLE	Cuentas.Pago
	ADD CONSTRAINT FK_Cuentas_Pagos_idMora$TieneUn$Cuentas_Mora_idMora
		FOREIGN KEY (idMora)
			REFERENCES Cuentas.Mora(idMora);
GO

ALTER TABLE	Cuentas.TipoPago
	ADD CONSTRAINT FK_Cuentas_TipoPago_idGrado$sonDe$Cuentas_Grado_idGrado
		FOREIGN KEY (idGrado)
			REFERENCES Cuentas.Grado(idGrado);
GO

ALTER TABLE	Cuentas.Alumno
	ADD CONSTRAINT FK_Cuentas_Alumno_idGrado$estaEn$Cuentas_Grado_idGrado
		FOREIGN KEY (idGrado)
			REFERENCES Cuentas.Grado(idGrado);
GO
