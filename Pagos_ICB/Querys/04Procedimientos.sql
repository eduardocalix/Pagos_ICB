USE DBICB
GO


--Procedimientos Almacenados para cada modulo
--Modulo Usuarios
CREATE PROCEDURE SP_BuscarUsuario
(
    @usuario NVARCHAR(25)
)
AS
BEGIN
    DECLARE @existe INT
    SELECT @existe = COUNT(Acceso.Usuario.usuario) FROM Acceso.Usuario WHERE usuario = @usuario;
    RETURN @existe;
END
GO

CREATE PROCEDURE SP_InsertarUsuario
(
    @nombre NVARCHAR(25),
    @apellido NVARCHAR(25),
    @clave NVARCHAR(20)
    
)
AS
BEGIN
    DECLARE @existe int;
    DECLARE @Usuario nVarchar(26);
    SET @existe = 0;
    IF (@nombre = '' OR @apellido = '' )
        BEGIN
            RAISERROR(N'Hay campos abligatorios sin llenar', 16, 1, @nombre, @apellido);
            RETURN 0
        END
    ELSE
        BEGIN
            SET @usuario = UPPER(LEFT(@nombre, 1)) + Utilidad.NombrePropios(@apellido)

            SELECT @existe = COUNT(Acceso.Usuario.usuario) FROM Acceso.Usuario WHERE usuario = @usuario;
            IF (@existe > 0)
                BEGIN
                    RAISERROR(N'Ya existe un usuario con el nombre  "%s %s"', 16, 1, @nombre, @apellido);
                    RETURN 0
                END     
            ELSE
                BEGIN
                    INSERT INTO Acceso.Usuario(nombre, apellido, usuario, clave)
                        VALUES (    Utilidad.NombrePropios(@nombre),
                                    Utilidad.NombrePropios(@apellido), 
                                    @usuario, 
                                    @clave)
                    RETURN 1
                END
            
        END
END
GO

CREATE PROCEDURE SP_ModificarUsuario
(
    @usuarioAnterior NVARCHAR(26),
    @nombre NVARCHAR(25),
    @apellido NVARCHAR(25),
    @clave NVARCHAR(20)
)
AS
BEGIN
    DECLARE @existe int;
    DECLARE @Usuario nVarchar(26);
    SET @existe = 0;
    IF (@nombre = '' OR @apellido = '')
        BEGIN
            RAISERROR(N'Hay campos abligatorios sin llenar', 16, 1, @nombre, @apellido);
            RETURN 0
        END
    ELSE
        BEGIN
            SET @usuario = UPPER(LEFT(@nombre, 1)) + Utilidad.NombrePropios(@apellido)

            SELECT @existe = COUNT(Acceso.Usuario.usuario) FROM Acceso.Usuario WHERE usuario = @usuarioAnterior;
            IF (@existe = 0)
                BEGIN
                    RAISERROR(N'No existe un usuario con el nombre  "%s %s"', 16, 1, @nombre, @apellido);
                    RETURN 0
                END     
            ELSE
                BEGIN
                    UPDATE Acceso.Usuario
                        SET     nombre = Utilidad.NombrePropios(@nombre),
                                apellido = Utilidad.NombrePropios(@apellido), 
                                usuario =   @usuario, 
                                clave = @clave
                            WHERE usuario = @usuarioAnterior;
                    RETURN 1
                END          
        END
END
GO

CREATE PROCEDURE SP_EliminarUsuario1
(
    @usuario NVARCHAR(26),
	@estado BIT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
            SELECT @existe = COUNT(Acceso.Usuario.usuario) FROM Acceso.Usuario WHERE usuario = @usuario;
            IF (@existe = 0)
                BEGIN
                    RAISERROR(N'No existe un usuario con el nombre "', 16, 1);
                    RETURN 0
                END     
            ELSE
                BEGIN
                    UPDATE Acceso.Usuario SET estado=@estado WHERE usuario = @usuario;
                    RETURN 1
                END
END
GO
CREATE PROCEDURE SP_EliminarUsuario
(
    @usuario NVARCHAR(26)
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

            SELECT @existe = COUNT(Acceso.Usuario.usuario) FROM Acceso.Usuario WHERE usuario = @usuario;
            IF (@existe = 0)
                BEGIN
                    RAISERROR(N'No existe un usuario con el nombre "', 16, 1);
                    RETURN 0
                END     
            ELSE
                BEGIN
                    DELETE FROM Acceso.Usuario WHERE usuario = @usuario;
                    RETURN 1
                END
END
GO
----------------------------------------------------------
--Modulo de los grados

CREATE PROCEDURE SP_AgregarGrado
(
	@nombreGrado NVARCHAR(30)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Grado.idGrado) FROM Cuentas.Grado WHERE nombreGrado = @nombreGrado;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un Grado con el nombreGrado  "%s"', 16, 1, @nombreGrado);
			RETURN 0			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Grado(nombreGrado)
				VALUES(@nombreGrado)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarGrado
(
	@idGrado INT,
	@nombreGrado NVARCHAR(30)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Grado.idGrado) FROM Cuentas.Grado WHERE idGrado = @idGrado;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Grado con el id %d"', 16, 1, @idGrado);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Grado
				SET 	nombreGrado = @nombreGrado
					WHERE idGrado = @idGrado;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarGrado1
(
	@idGrado INT,
	@estado INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Grado.idGrado) FROM Cuentas.Grado WHERE idGrado = @idGrado;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Grado con el id %d"', 16, 1, @idGrado);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Grado SET estado=@estado	WHERE idGrado = @idGrado;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarGrado
(
	@idGrado INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Grado.idGrado) FROM Cuentas.Grado WHERE idGrado = @idGrado;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Grado con el id %d"', 16, 1, @idGrado);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Grado	WHERE idGrado = @idGrado;
				RETURN 1
			END
END
GO
----------------------------------------------------------------------------------------
--Modulo Alumnos
CREATE PROCEDURE SP_AgregarAlumno
(
	@identidad NVARCHAR(15),
	@nombres NVARCHAR(25),
	@apellidos NVARCHAR(25),
	@idGrado INT,
	@beca NVARCHAR(3) 
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Alumno.identidad) FROM Cuentas.Alumno WHERE identidad = @identidad;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe Un Alumno con la identidad %s"', 16, 1, @identidad);
			RETURN 0		
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Alumno(identidad, nombres, apellidos, idGrado,beca)
				VALUES(	@identidad, @nombres, @apellidos, @idGrado,@beca)
			RETURN 1
		END
END
GO

Create PROCEDURE SP_ModificarAlumno
(	
	@idAlumno INT,
	@identidad NVARCHAR(15),
	@nombres NVARCHAR(25),
	@apellidos NVARCHAR(25),
	@idGrado INT,
	@beca NVARCHAR(3)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Alumno.identidad) FROM Cuentas.Alumno WHERE identidad=@identidad;
	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Alumno con la identidad %s"', 16, 1, @identidad);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Alumno
				SET 	
						nombres = @nombres,
						apellidos = @apellidos,
						idGrado = @idGrado,
						beca = @beca
					WHERE identidad = @identidad;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarAlumno1
(
	@idAlumno INT,
	@estado INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
			SELECT @existe = COUNT(Cuentas.Alumno.idAlumno) FROM Cuentas.Alumno WHERE idAlumno=@idAlumno;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Alumno con el id %d"', 16, 1, @idAlumno);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Alumno SET estado=@estado	WHERE idAlumno=@idAlumno;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarAlumno
(
	@idAlumno INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
			SELECT @existe = COUNT(Cuentas.Alumno.idAlumno) FROM Cuentas.Alumno WHERE idAlumno=@idAlumno;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Alumno con el id %d"', 16, 1, @idAlumno);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Alumno	WHERE idAlumno=@idAlumno;
				RETURN 1
			END
END
GO
-----------------------------------------------------------------------------------
USE DBICB
GO
----------------------------------------------------------
--Modulo de los Moras

CREATE PROCEDURE SP_AgregarMora
(
	@nombreMora NVARCHAR(30),
	@valor DECIMAL(6,2)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Mora.idMora) FROM Cuentas.Mora WHERE nombreMora = @nombreMora;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un Mora con el nombreMora  "%s"', 16, 1, @nombreMora);
			RETURN 0			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Mora(nombreMora,valor)
				VALUES(@nombreMora,@valor)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarMora
(
	@idMora INT,
	@nombreMora NVARCHAR(30),
	@valor DECIMAL(6,2)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Mora.idMora) FROM Cuentas.Mora WHERE idMora = @idMora;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Mora con el id %d"', 16, 1, @idMora);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Mora
				SET 	nombreMora = @nombreMora,
						valor = @valor
					WHERE idMora = @idMora;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarMora1
(
	@idMora INT,
	@estado INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Mora.idMora) FROM Cuentas.Mora WHERE idMora = @idMora;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Mora con el id %d"', 16, 1, @idMora);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Mora SET estado=@estado	WHERE idMora = @idMora;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarMora
(
	@idMora INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Mora.idMora) FROM Cuentas.Mora WHERE idMora = @idMora;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Mora con el id %d"', 16, 1, @idMora);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Mora	WHERE idMora = @idMora;
				RETURN 1
			END
END
GO
----------------------------------------------------------
--Modulo de los Descuentos

CREATE PROCEDURE SP_AgregarDescuento
(
	@nombreDescuento NVARCHAR(30),
	@valor DECIMAL(6,2)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Descuento.idDescuento) FROM Cuentas.Descuento WHERE nombreDescuento = @nombreDescuento;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un Descuento con el nombreDescuento  "%s"', 16, 1, @nombreDescuento);
			RETURN 0			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Descuento(nombreDescuento,valor)
				VALUES(@nombreDescuento,@valor)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarDescuento
(
	@idDescuento INT,
	@nombreDescuento NVARCHAR(30),
	@valor DECIMAL(6,2)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Descuento.idDescuento) FROM Cuentas.Descuento WHERE idDescuento = @idDescuento;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Descuento con el id %d"', 16, 1, @idDescuento);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Descuento
				SET 	nombreDescuento = @nombreDescuento,
						valor = @valor
					WHERE idDescuento = @idDescuento;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarDescuento1
(
	@idDescuento INT,
	@estado INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Descuento.idDescuento) FROM Cuentas.Descuento WHERE idDescuento = @idDescuento;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Descuento con el id %d"', 16, 1, @idDescuento);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Descuento SET estado=@estado	WHERE idDescuento = @idDescuento;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarDescuento
(
	@idDescuento INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Descuento.idDescuento) FROM Cuentas.Descuento WHERE idDescuento = @idDescuento;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Descuento con el id %d"', 16, 1, @idDescuento);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Descuento	WHERE idDescuento = @idDescuento;
				RETURN 1
			END
END
GO

-----------------------------------------------------
--Tipo Pago
CREATE PROCEDURE SP_AgregarTipoPago
(
    @idNombreTipoPago INT,
	@valor DECIMAL(6,2),
    @idGrado INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.TipoPago.idTipoPago) FROM Cuentas.TipoPago WHERE idNombreTipoPago = @idNombreTipoPago;
    IF (@existe > 0)
        BEGIN
            RAISERROR(N'Ya existe un TipoPago con el idTipoPago %s"', 16, 1,@idNombreTipoPago);
            RETURN 0
            
        END
    ELSE
        BEGIN
            INSERT INTO Cuentas.TipoPago(idNombreTipoPago,valor, idGrado)
                VALUES(@idNombreTipoPago, @valor, @idGrado)
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_ModificarTipoPago
(
    @idTipoPago INT,
    @idNombreTipoPago INT,
    @valor DECIMAL(6,2),
    @idGrado INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.TipoPago.idTipoPago) FROM Cuentas.TipoPago WHERE idTipoPago = @idTipoPago;

    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe el TipoPago con el id %d"', 16, 1, @idTipoPago);
            RETURN 0
        END     
    ELSE
        BEGIN
            UPDATE Cuentas.TipoPago
                SET     idNombreTipoPago = @idNombreTipoPago,
                        valor = @valor,
                        idGrado = @idGrado
                    WHERE idTipoPago = @idTipoPago;
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_EliminarTipoPago1
(
    @idTipoPago INT,
	@estado INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
        SELECT @existe = COUNT(Cuentas.TipoPago.idTipoPago) FROM Cuentas.TipoPago WHERE idTipoPago = @idTipoPago;
        IF (@existe = 0)
            BEGIN
                RAISERROR(N'No existe el TipoPago con el id %d"', 16, 1, @idTipoPago);
                RETURN 0
            END     
        ELSE
            BEGIN
                UPDATE Cuentas.TipoPago SET estado=@estado WHERE idTipoPago = @idTipoPago;
                RETURN 1
            END
END
GO

CREATE PROCEDURE SP_EliminarTipoPago
(
    @idTipoPago INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
        SELECT @existe = COUNT(Cuentas.TipoPago.idTipoPago) FROM Cuentas.TipoPago WHERE idTipoPago = @idTipoPago;
        IF (@existe = 0)
            BEGIN
                RAISERROR(N'No existe el TipoPago con el id %d"', 16, 1, @idTipoPago);
                RETURN 0
            END     
        ELSE
            BEGIN
                DELETE FROM Cuentas.TipoPago WHERE idTipoPago = @idTipoPago;
                RETURN 1
            END
END
GO

-------------------------------------------------------------------------------------------------------------------
--Modulo Pago 
CREATE PROCEDURE SP_AgregarPago
(
	@recibo VARCHAR(15),
	@idAlumno INT,
	@idTipoPago INT,
	@idDescuento INT,
    @idMora INT,
	@idUsuario INT,
	@total DECIMAL (8,2),
	@fechaPago DATE 
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Pago.idPago) FROM Cuentas.Pago WHERE recibo = @recibo;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un Pago con el recibo %s"', 16, 1,@recibo);
			RETURN 0
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Pago(recibo, idAlumno, idTipoPago, idDescuento, idMora,idUsuario,total, fechaPago)
				VALUES(@recibo,@idAlumno,@idTipoPago,@idDescuento,@idMora,@idUsuario,@total,@fechaPago)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarPago
(
	@idPago INT,
	@recibo VARCHAR(15),
	@idAlumno INT,
	@idTipoPago INT,
	@idDescuento INT,
    @idMora INT,
	@idUsuario INT,
	@total DECIMAL (8,2),
	@fechaPago DATE 
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Pago.idPago) FROM Cuentas.Pago WHERE idPago = @idPago;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Pago con el id %d"', 16, 1, @idPago);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Pago
				SET 	recibo = @recibo,
						idAlumno = @idAlumno,
						idTipoPago = @idTipoPago,
						idDescuento = @idDescuento,
						idMora = @idMora,
						idUsuario = @idUsuario,
						total = @total,
						fechaPago = @fechaPago
					WHERE idPago = @idPago;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarPago1
(
	@idPago INT,
	@estado BIT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Pago.idPago) FROM Cuentas.Pago WHERE idPago = @idPago;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Pago con el id %d"', 16, 1, @idPago);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Pago SET estado=@estado WHERE idPago = @idPago;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarPago
(
	@idPago INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Pago.idPago) FROM Cuentas.Pago WHERE idPago = @idPago;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Pago con el id %d"', 16, 1, @idPago);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Pago WHERE idPago = @idPago;
				RETURN 1
			END
END
GO



-----------------------------------------------------
--Nombre de Tipo Pago
CREATE PROCEDURE SP_AgregarNombreTipoPago
(
    @nombreTipoPago NVARCHAR(30)
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.NombreTipoPago.idNombreTipoPago) FROM Cuentas.NombreTipoPago WHERE nombreTipoPago = @nombreTipoPago;
    IF (@existe > 0)
        BEGIN
            RAISERROR(N'Ya existe un NombreTipoPago con el nombreTipoPago %s"', 16, 1,@nombreTipoPago);
            RETURN 0
            
        END
    ELSE
        BEGIN
            INSERT INTO Cuentas.NombreTipoPago(nombreTipoPago)
                VALUES(@nombreTipoPago)
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_ModificarNombreTipoPago
(
    @idNombreTipoPago INT,
    @nombreTipoPago NVARCHAR(30)
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.NombreTipoPago.idNombreTipoPago) FROM Cuentas.NombreTipoPago WHERE idNombreTipoPago = @idNombreTipoPago;

    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe el NombreTipoPago con el id %d"', 16, 1, @idNombreTipoPago);
            RETURN 0
        END     
    ELSE
        BEGIN
            UPDATE Cuentas.NombreTipoPago
                SET     nombreTipoPago = @nombreTipoPago
                    WHERE idNombreTipoPago = @idNombreTipoPago;
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_EliminarNombreTipoPago1
(
    @idNombreTipoPago INT,
	@estado INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
        SELECT @existe = COUNT(Cuentas.NombreTipoPago.idNombreTipoPago) FROM Cuentas.NombreTipoPago WHERE idNombreTipoPago = @idNombreTipoPago;
        IF (@existe = 0)
            BEGIN
                RAISERROR(N'No existe el NombreTipoPago con el id %d"', 16, 1, @idNombreTipoPago);
                RETURN 0
            END     
        ELSE
            BEGIN
                UPDATE Cuentas.NombreTipoPago SET estado=@estado WHERE idNombreTipoPago = @idNombreTipoPago;
                RETURN 1
            END
END
GO

CREATE PROCEDURE SP_EliminarNombreTipoPago
(
    @idNombreTipoPago INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
        SELECT @existe = COUNT(Cuentas.NombreTipoPago.idNombreTipoPago) FROM Cuentas.NombreTipoPago WHERE idNombreTipoPago = @idNombreTipoPago;
        IF (@existe = 0)
            BEGIN
                RAISERROR(N'No existe el NombreTipoPago con el id %d"', 16, 1, @idNombreTipoPago);
                RETURN 0
            END     
        ELSE
            BEGIN
                DELETE FROM Cuentas.NombreTipoPago WHERE idNombreTipoPago = @idNombreTipoPago;
                RETURN 1
            END
END
GO
--------------------------------------------------------------------------------------------
/*
--------------------------------------------------------------------------------------
--Modulo Pago
CREATE PROCEDURE SP_AgregarPago
(
@idPedido INT,
@idCaja INT,
@idUsuario INT,
@descuento DECIMAL(6,4),
@exento DECIMAL(6,4),
@isv15 DECIMAL(6,4),
@isv18 DECIMAL(6,4),
@total DECIMAL(8,4),
@tipoPago INT,
@subTotal DECIMAL(8,4)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Pagos.idPedido) FROM Cuentas.Pagos WHERE idPedido=@idPedido;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un pedido con el id "%d"', 16, 1,@idPedido);
			RETURN 0
			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Pagos
			(
			    idPedido,
				idCaja,
			    idUsuario,			    
			    descuento,
			    exento,
			    iva15,
			    iva18,
			    total,
				tipoPago,
				subTotal
			)
			VALUES
			(  @idPedido,@idCaja,@idUsuario,@descuento,@exento,@isv15,@isv18,@total,@tipoPago,@subTotal
			    )
			RETURN 1
		END
END
GO--Modulo Tipo de Unidad
CREATE PROCEDURE SP_InsertarTipoUnidad
(
    @descripcion NVARCHAR(100)
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.TipoUnidad.idTipoUnidad) FROM Cuentas.TipoUnidad WHERE descripcion=@descripcion;
    IF (@existe > 0)
        BEGIN
            RAISERROR(N'Ya existe un Tipo de Unidad con el nombrePago "%s"', 16, 1,@descripcion);
            RETURN 0          
        END
    ELSE
        BEGIN
            INSERT INTO Cuentas.TipoUnidad(descripcion)
                VALUES(@descripcion)
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_ModificarTipoUnidad
(
    @idTipoUnidad INT,
    @descripcion NVARCHAR(100)
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
    SELECT @existe = COUNT(Cuentas.TipoUnidad.idTipoUnidad) FROM Cuentas.TipoUnidad WHERE idTipoUnidad=@idTipoUnidad;
    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe ningún Tipo de Unidad con el id "%d"', 16, 1, @idTipoUnidad);
            RETURN 0
        END     
    ELSE
        BEGIN
            UPDATE Cuentas.TipoUnidad
                SET     descripcion = @descripcion
                    WHERE idTipoUnidad = @idTipoUnidad;
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_EliminarTipoUnidad1
(
    @idTipoUnidad INT,
	@estado BIT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
    SELECT @existe = COUNT(Cuentas.TipoUnidad.idTipoUnidad) FROM Cuentas.TipoUnidad WHERE idTipoUnidad=@idTipoUnidad;
    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe ningún Tipo de Unidad con el id "%d"', 16, 1, @idTipoUnidad);
            RETURN 0
        END     
    ELSE
        BEGIN
            UPDATE Cuentas.TipoUnidad SET estado=@estado WHERE idTipoUnidad = @idTipoUnidad;
            RETURN 1
        END
END
GO
CREATE PROCEDURE SP_EliminarTipoUnidad
(
    @idTipoUnidad INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
    SELECT @existe = COUNT(Cuentas.TipoUnidad.idTipoUnidad) FROM Cuentas.TipoUnidad WHERE idTipoUnidad=@idTipoUnidad;
    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe ningún Tipo de Unidad con el id "%d"', 16, 1, @idTipoUnidad);
            RETURN 0
        END     
    ELSE
        BEGIN
            DELETE FROM Cuentas.TipoUnidad  WHERE idTipoUnidad = @idTipoUnidad;
            RETURN 1
        END
END
GO
---------------------------------------------------------------------------------
--Modulo mesas

CREATE PROCEDURE SP_AgregarMesa
(
@estado NVARCHAR(21)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Mesas.estado) FROM Cuentas.Mesas WHERE estado=@estado;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe una area con el nombrePago "%s"', 16, 1,@estado);
			RETURN 0
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Mesas(estado)
				VALUES(@estado)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarMesa
(
@id INT,
@estado NVARCHAR(21)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Mesas.id) FROM Cuentas.Mesas WHERE id=@id;
	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe ninguna Mesa con el id "%d"', 16, 1, @id);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Mesas
				SET estado = @estado
					WHERE id = @id;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarMesa
(
@id INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Mesas.id) FROM Cuentas.Mesas WHERE id=@id;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe ninguna Mesa con el id "%d"', 16, 1);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Mesas SET estado=0 WHERE id=@id;
				RETURN 1
			END
END
GO
----------------------------------------------------------------------------------
--Modulo Pedidos de Comida

CREATE PROCEDURE SP_AgregarPedido
(
@fecha NVARCHAR(19),
@idMesa INT,
@RTN NVARCHAR(14),
@nombre NVARCHAR(50),
@IdAlumno INT
)
AS
BEGIN
	--DECLARE @existe int;
	--SET @existe = 0;

	--SELECT @existe = COUNT(Cuentas.Pedidos.id) FROM Cuentas.Pedidos WHERE id=@id;
	--IF (@existe > 0)
	--	BEGIN
	--		RAISERROR(N'No existe ninguna Mesa con el id "%d"', 16, 1,@idMesa);
	--		RETURN 0
			
	--	END
	--ELSE
		--BEGIN
			INSERT INTO Cuentas.Pedidos(Fecha,idMesa,RTN,NombreCliente,idAlumno)
				VALUES(@fecha,@idMesa,@RTN,@nombre,@IdAlumno)

			
			RETURN 1

		--END
END
GO

CREATE PROCEDURE SP_ModificarPedido
(
@id INT,
@estado INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Pedidos.id) FROM Cuentas.Pedidos WHERE id=@id;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe ningun pedido con el id "%d"', 16, 1,@id);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Pedidos
				SET estado=@estado
					WHERE id=@id;
			RETURN 1
		END	
END
GO

CREATE PROCEDURE SP_EliminarPedido
(
@id INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Pedidos.id) FROM Cuentas.Pedidos WHERE id=@id;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No se encuentra el pedido "%d"', 16, 1,@id);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Pedidos SET estado=0	WHERE id=@id;
				RETURN 1
			END
END
GO
-----------------------------------------------------------------------------------
--Modulo DetallePedido

CREATE PROCEDURE SP_AgregarDetallePedido
(
	@idPedido INT,
    @idPago INT,
    @cantidad INT,
	@subtotal DECIMAL
)
AS
BEGIN
            INSERT INTO Cuentas.DetallePedidos
            (
                idPedido,
                idPago,
                cantidad,
				subTotal
            )
            VALUES
            ( @idPedido,@idPago,@cantidad,@subtotal)
                
            RETURN 1
        --END
END
GO

CREATE PROCEDURE SP_ModificarDetallePedido
(
	@idDetalle INT,
	@estado INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.DetallePedidos.idDetallePedido) FROM Cuentas.DetallePedidos WHERE idDetallePedido=@idDetalle;

    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe un pedido con el id "%d"', 16, 1, @idDetalle);
            RETURN 0
        END     
    ELSE
        BEGIN
            UPDATE Cuentas.DetallePedidos
					SET estado=@estado
                    WHERE idDetallePedido=@idDetalle;
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_EliminarDetallePedido
(
    @idDetalle INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
        SELECT @existe = COUNT(Cuentas.DetallePedidos.idDetallePedido) FROM Cuentas.DetallePedidos WHERE idDetallePedido=@idDetalle;
        IF (@existe = 0)
            BEGIN
                RAISERROR(N'No existe el Detalle Pedido con el id %d"', 16, 1, @idDetalle);
                RETURN 0
            END     
        ELSE
            BEGIN
                UPDATE Cuentas.DetallePedidos SET estado=0 WHERE idDetallePedido=@idDetalle;
                RETURN 1
            END
END
GO*/

--------------------------------------------------------------------------------------------------------

/*
----------------------------------------------------------------------------------------------------------------
--SP para actualizar el stock dela Tabla Pago.Articulos 
CREATE PROCEDURE Pago.SPActualizarArticulos(
	@CodigoArticulo VARCHAR(15),
	@Stock INT
  )
AS
BEGIN
	DECLARE @Codigo INT
	DECLARE @CodigoProducto VARCHAR(15) = @CodigoArticulo

	EXEC @Codigo = Pago.SPEstadoDelArticulo @CodigoProducto
	IF @Codigo = 1
		PRINT 'Debe ingresar el codigo del Articulo'
	ELSE
		IF @Codigo = 2
			PRINT 'El Codigo del producto ingresado no es válido'
		ELSE
			IF @Codigo = 3
				PRINT 'No hay existencia de este producto'
			ELSE
				IF @Codigo = 0
					PRINT 'Producto encontrado'

	DECLARE @Stock1 INT 
	SELECT @Stock1 = Stock FROM Pago.Articulos
			WHERE Codigo = @CodigoProducto

UPDATE Pago.Articulos
SET Stock = @Stock1 + @Stock
FROM Pago.Articulos
WHERE Codigo = @CodigoProducto

END
--Probando con valores Incorrectos
EXEC Pago.SPActualizarArticulos '3 154141 194108';
--Probando Valores Correctos
EXEC Pago.SPActualizarArticulos '3 154141 194108',4;
GO
------------------------------------------------------------------------------------------------
	-- Creación de un Stored Procedure que se encarga de ingresar
	-- valores a la tabla Pago 
CREATE PROCEDURE SP_sPagos(
	@IdCliente CHAR(15)=NULL ,
	@IdVendedor INT = NULL
)
AS
BEGIN
	IF (@IdVendedor IS NULL) OR (@IdCliente IS NULL) 
		BEGIN
			RAISERROR('El Codigo de Vendedor, Cliente son requeridos.', 16, 1)
			RETURN 0
		END
	ELSE
		BEGIN
		--Declaramos las Variables las cuales nos serviran al momento de la inserción
		DECLARE @Vendedor INT  = @IdVendedor
		DECLARE @Cliente CHAR (15) = @IdCliente
		DECLARE @ImporteISV DECIMAL(10,2) = 0
		DECLARE @Impuesto DECIMAL(10,2) = 0
		DECLARE @Total DECIMAL(10,2) = 0
		INSERT INTO Pagocion.Pago(IdVendedor,IdCliente, ImporteISV,Impuesto,Total )
				VALUES(@Vendedor,@Cliente,@ImporteISV,@Impuesto,@Total)
			RETURN 1
		END
END
GO



---------------------------------------------------------------------------------------
    -- Creación de un Stored Procedure que se encarga de ingresar
	-- valores a la tabla Detalle Pago 
CREATE PROCEDURE Pagocion.SPDetallePagos(
	@CodigoArticulo VARCHAR (15) = NULL, 
	@CantidadArticulo INT = NULL
)
AS
BEGIN
	IF (@CodigoArticulo IS NULL) OR (@CantidadArticulo IS NULL)
		BEGIN
			RAISERROR('El Codigo de Producto e igual que la Cantidad son requeridos.', 16, 1)
			RETURN 0
		END
	ELSE
--Declaramos las variables a utilizar
	DECLARE @NumeroPago INT
	DECLARE @Codigo INT
	DECLARE @CodigoArticulo1 VARCHAR(15) = @CodigoArticulo
	DECLARE @PrecioUnitario DECIMAL (10,2)
	DECLARE @SubTotal DECIMAL (10,2)

-- Verificar Codigo de Producto
	EXEC @Codigo = Pago.SPEstadoDelArticulo @CodigoArticulo1
	IF @Codigo = 1
		PRINT 'Debe ingresar el codigo del Articulo'
	ELSE
		IF @Codigo = 2
			PRINT 'El Codigo del producto ingresado no es válido'
		ELSE
			IF @Codigo = 3
				PRINT 'No hay existencia de este producto'
			ELSE
				IF @Codigo = 0
					PRINT 'Producto encontrado'
--BUSCANDO VALORES
		SET @NumeroPago = (SELECT MAX(Numero) FROM Pagocion.Pago)
		SELECT @PrecioUnitario = PrecioVenta FROM Pago.Articulos
		WHERE Codigo = @CodigoArticulo
		SET @SubTotal = @PrecioUnitario * @CantidadArticulo
		DECLARE @Impuesto DECIMAL(10,2)
		DECLARE @Importe DECIMAL(10,2)
--Ejecutamos los Stored Procedure de calculo de impuesto e importe
		EXEC Pagocion.SPCalculoImporte @CodigoArticulo,@SubTotal,@Importe OUTPUT
		EXEC Pagocion.SPExcentoImpuesto @CodigoArticulo,@Importe,@Impuesto OUTPUT
--Insertamos los datos en la tabla Detalle Pago
		INSERT INTO Pagocion.DetallePago(NumeroPago,CodigoArticulo,CantidadArticulo,PrecioUnitario,Subtotal) 
			VALUES (@NumeroPago,@CodigoArticulo1,@CantidadArticulo,@PrecioUnitario,@SubTotal)
		
				IF ((SELECT Stock FROM Pago.Articulos 
					WHERE Codigo = @CodigoArticulo1)<=(SELECT CantidadMinima FROM Pago.Articulos
					WHERE Codigo = @CodigoArticulo1))
				BEGIN
					PRINT 'Se ha alcanzado el Pago minimo para el producto '+ @CodigoArticulo1 +'. Considere contactar a su Grado.'
				END
--Actualizamos nuestro encabezado en la Tabla Pago para los campos
--IMPUESTO,IMPORTEISV,TOTAL		
		UPDATE Pagocion.Pago
		SET ImporteISV=@Importe,Impuesto = @Impuesto, Total = @SubTotal
		FROM Pagocion.Pago
		INNER JOIN Pagocion.DetallePago
		ON @NumeroPago=Numero
		WHERE Numero= @NumeroPago
END
GO


--Insertar Apertura de Caja
CREATE PROCEDURE SP_Agregar_AperturaCaja
(
	--@Apertura decimal(18,0),
	@Dolares DECIMAL(6,2),
	@POS DECIMAL(6,2),
	@Fiveh int,
	@Hundred int,
	@Fifty int,
	@Twenty int,
	@Ten int,
	@Five int,
	@Two int,
	@One int,
	@Estado INT,
	@Monto DECIMAL(6,2),
	@User nvarchar(20)
)
AS
BEGIN
	INSERT INTO Cuentas.Caja( dolares, POS, quinientos, cien, cincuenta,
								  veinte, diez, cinco, dos, uno, fecha,estado,Monto, Usuario)
		VALUES ( @Dolares, @POS,@Fiveh, @Hundred, @Fifty, @Twenty, @Ten, 
				@Five, @Two, @One,GETDATE(),@Estado, @Monto, @User)
END
GO

--Insertar Cierre de Caja
-- OJO!!!! Este SP esta funcional. Hay que agregarlo a la Base de Datos. Lo comente porque aqui da un error y para
-- que no lo de, lo comente. Si se omite este, no se podra hacer el cierre de caja.
CREATE PROCEDURE SP_AgregarCierreCaja
(
	--@Cierre decimal(18,0),
	@Dolares DECIMAL(6,2),
	@POS DECIMAL(6,2),
	@Fiveh int,
	@Hundred int,
	@Fifty int,
	@Twenty int,
	@Ten int,
	@Five int,
	@Two int,
	@One int,
	@Estado INT,
	@Monto DECIMAL(6,2),
	@User nvarchar(20)
)
AS
BEGIN
	INSERT INTO Cuentas.Caja( dolares, POS, quinientos, cien, cincuenta,
								  veinte, diez, cinco, dos, uno, fecha,estado,Monto, Usuario)
		VALUES ( @Dolares, @POS,@Fiveh, @Hundred, @Fifty, @Twenty, @Ten, 
				@Five, @Two, @One,GETDATE(),@Estado, @Monto, @User)
END
GO

--Insertar Pago de Servicio Publico
-- OJO!!!! Este SP esta funcional. Hay que agregarlo a la Base de Datos. Lo comente porque aqui da un error y para
-- que no lo de, lo comente. Si se omite este, no se podra hacer el cierre de caja.
CREATE PROCEDURE SP_InsertarPago_ServicioPublico
(
	@ServicioPublico nvarchar(50),
	@Monto decimal(8,2),
	@Usuario nvarchar(20)
)
AS
BEGIN
	DECLARE @id int
	SET @id = (SELECT id
	FROM Cuentas.ServicioPublico
	WHERE Descripcion = @ServicioPublico)

	INSERT INTO Cuentas.DetalleServicioPublico( Monto, fecha, Usuario,idServicioPublico)
		VALUES ( @Monto, GETDATE(), @Usuario,@id)
END
GO
--Insertar Salidas Varias
-- OJO!!!! Este SP esta funcional. Hay que agregarlo a la Base de Datos. Lo comente porque aqui da un error y para
-- que no lo de, lo comente. Si se omite este, no se podra hacer el cierre de caja.
CREATE PROCEDURE SP_InsertarPago_OtrasSalidas
(
	@Descripcion nvarchar(200),
	@Monto decimal(8,2),
	@Usuario nvarchar(20)
)
AS
BEGIN
	INSERT INTO Cuentas.OtrasSalidas(Descripcion, Monto, fecha, Usuario)
		VALUES (@Descripcion, @Monto, GETDATE(), @Usuario)
END
GO

--Insertar Servicios Publicos
-- OJO!!!! Este SP esta funcional. Hay que agregarlo a la Base de Datos. Lo comente porque aqui da un error y para
-- que no lo de, lo comente. Si se omite este, no se podra hacer el cierre de caja.
CREATE PROCEDURE SP_Agregar_ServicioPublico
(
	@Descripcion NVARCHAR (30)
)
AS
BEGIN
	INSERT INTO Cuentas.ServicioPublico (Descripcion)
		VALUES (@Descripcion)
END
GO*/