
USE DBICB
GO

--DEFINICION DE LLAVES PRIMARIAS
ALTER TABLE Acceso.Usuarios
	ADD CONSTRAINT PK_Acceso_Usuarios_id
		PRIMARY KEY NONCLUSTERED(id);
GO
/*
ALTER TABLE Acceso.Roles
	ADD CONSTRAINT PK_Acceso_Roles_id
		PRIMARY KEY NONCLUSTERED(id);
GO

ALTER TABLE Cuentas.Areas
	ADD CONSTRAINT PK_Cuentas_Areas_id
		PRIMARY KEY NONCLUSTERED (id)
GO*/

ALTER TABLE Cuentas.Grados
	ADD CONSTRAINT PK_Cuentas_Grados_id
		PRIMARY KEY NONCLUSTERED (idGrado);
GO

ALTER TABLE Cuentas.Alumnos
	ADD CONSTRAINT PK_Cuentas_Alumnos_id
		PRIMARY KEY NONCLUSTERED (id);
GO

ALTER TABLE Cuentas.Pagos
	ADD CONSTRAINT PK_Cuentas_Pagos_id
		PRIMARY KEY CLUSTERED (idPagos);
GO 


ALTER TABLE Cuentas.Descuento
	ADD CONSTRAINT PK_Cuentas_Descuento_idDescuento
		PRIMARY KEY CLUSTERED (idDescuento);
GO

ALTER TABLE Cuentas.tipoPago
	ADD CONSTRAINT PK_Cuentas_tipoPago_idtipoPago
		PRIMARY KEY CLUSTERED (idTipo);
GO

ALTER TABLE Cuentas.Mora
	ADD CONSTRAINT PK_Cuentas_Mora_idMora
		PRIMARY KEY CLUSTERED(idMora);
GO

--DEFINICION DE LLAVES FORANEAS
/*
ALTER TABLE Acceso.Usuarios
	ADD CONSTRAINT FK_Acceso_Roles_id$tiene$Acceso_Usuarios_id
		FOREIGN KEY	(idRol)
			REFERENCES Acceso.Roles(id);
GO


ALTER TABLE Cuentas.Grados
	ADD CONSTRAINT FK_Cuentas_Grados_id$TieneUna$Cuentas_Areas_id
		FOREIGN KEY (idArea)
			REFERENCES Cuentas.Areas(id);
GO*/


ALTER TABLE Cuentas.Pagos
	ADD CONSTRAINT FK_Cuentas_Pagos_idTipo$TieneUna$Cuentas_TipoPago
		FOREIGN KEY	(idTipo)
			REFERENCES Cuentas.tipoPago(idTipo);
GO

ALTER TABLE Cuentas.Pagos
	ADD CONSTRAINT FK_Cuentas_Pagos_idUsuario$TieneUn$Acceso_Usuarios_id
		FOREIGN KEY	(idUsuario)
			REFERENCES Acceso.Usuarios(id);
GO

ALTER TABLE Cuentas.Pagos
	ADD CONSTRAINT FK_Cuentas_Alumnos_id$HacenMuchos$Pagos_id
		FOREIGN KEY (idAlumno)
			REFERENCES Cuentas.Alumnos(id);
GO

ALTER TABLE	Cuentas.Pagos
	ADD CONSTRAINT FK_Cuentas_Pagos_idDescuento$Tiene$Cuentas_Descuentos_idDescuento
		FOREIGN KEY (idDescuento)
			REFERENCES Cuentas.Descuento(idDescuento);
GO

ALTER TABLE	Cuentas.Pagos
	ADD CONSTRAINT FK_Cuentas_Pagos_idMora$TieneUn$Cuentas_Mora_idMora
		FOREIGN KEY (idMora)
			REFERENCES Cuentas.Mora(idMora);
GO

ALTER TABLE	Cuentas.tipoPago
	ADD CONSTRAINT FK_Cuentas_TipoPago_idPago$sonEn$Cuentas_tipoPago_idTipo
		FOREIGN KEY (idGrado)
			REFERENCES Cuentas.Grados(idGrado);
GO

/*
ALTER TABLE Cuentas.Caja
	ADD CONSTRAINT PK_Caja_id
	PRIMARY KEY CLUSTERED (id)

--ALTER TABLE Cuentas.Caja
--	ADD CONSTRAINT FK_Caja$TieneUn$DetalleCaja
--	FOREIGN KEY (idDetalleCaja)
--	REFERENCES Cuentas.DetalleCaja(id)
--GO

ALTER TABLE Cuentas.tipoPago
	ADD CONSTRAINT FK_Cuentas_tipoPago_idtipoPago$TieneUn$Cuentas_Caja_id
		FOREIGN KEY (idCaja)
			REFERENCES Cuentas.Caja(id)
GO

ALTER TABLE Cuentas.DetalleServicioPublico
	ADD CONSTRAINT PK_DetalleServicioPublico_id
	PRIMARY KEY CLUSTERED (id)

ALTER TABLE Cuentas.ServicioPublico
	ADD CONSTRAINT PK_ServicioPublico_id
	PRIMARY KEY CLUSTERED (id)

ALTER TABLE Cuentas.DetalleServicioPublico
	ADD CONSTRAINT FK_DetalleServicioPublico$TieneUn$ServicioPublico
	FOREIGN KEY (idServicioPublico)
	REFERENCES Cuentas.ServicioPublico (id)

ALTER TABLE Cuentas.OtrasSalidas
	ADD CONSTRAINT PK_OtrasSalidas_id
	PRIMARY KEY CLUSTERED (id)
	*/