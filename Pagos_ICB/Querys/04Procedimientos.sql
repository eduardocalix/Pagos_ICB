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
	@estado INT
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
----------------------------------------------------------
--Modulo de los periodos

CREATE PROCEDURE SP_AgregarPeriodo
(
	@nombrePeriodo NVARCHAR(30)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Periodo.idPeriodo) FROM Cuentas.Periodo WHERE nombrePeriodo = @nombrePeriodo;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un Periodo con el nombrePeriodo  "%s"', 16, 1, @nombrePeriodo);
			RETURN 0			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Periodo(nombrePeriodo)
				VALUES(@nombrePeriodo)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarPeriodo
(
	@idPeriodo INT,
	@nombrePeriodo NVARCHAR(30)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Periodo.idPeriodo) FROM Cuentas.Periodo WHERE idPeriodo = @idPeriodo;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Periodo con el id %d"', 16, 1, @idPeriodo);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Periodo
				SET 	nombrePeriodo = @nombrePeriodo
					WHERE idPeriodo = @idPeriodo;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarPeriodo1
(
	@idPeriodo INT,
	@estado INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Periodo.idPeriodo) FROM Cuentas.Periodo WHERE idPeriodo = @idPeriodo;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Periodo con el id %d"', 16, 1, @idPeriodo);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Periodo SET estado=@estado	WHERE idPeriodo = @idPeriodo;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarPeriodo
(
	@idPeriodo INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Periodo.idPeriodo) FROM Cuentas.Periodo WHERE idPeriodo = @idPeriodo;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Periodo con el id %d"', 16, 1, @idPeriodo);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Periodo	WHERE idPeriodo = @idPeriodo;
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
	@idPeriodo INT,
	@beca NVARCHAR(3) 
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Alumno.idAlumno) FROM Cuentas.Alumno WHERE nombres = @nombres AND apellidos = @apellidos;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe Un Alumno con el mismo nombre %s"', 16, 1, @nombres);
			RETURN 0		
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Alumno(identidad, nombres, apellidos, idGrado,idPeriodo,beca)
				VALUES(	@identidad, @nombres, @apellidos, @idGrado,@idPeriodo,@beca)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarAlumno
(	
	@idAlumno INT,
	@identidad NVARCHAR(15),
	@nombres NVARCHAR(25),
	@apellidos NVARCHAR(25),
	@idGrado INT,
	@idPeriodo INT,
	@beca NVARCHAR(3)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Alumno.idAlumno) FROM Cuentas.Alumno WHERE idAlumno=@idAlumno;
	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Alumno con el mismo id %d"', 16, 1, @idAlumno);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Alumno
				SET 	identidad = @identidad,
						nombres = @nombres,
						apellidos = @apellidos,
						idGrado = @idGrado,
						idPeriodo =@idPeriodo,
						beca = @beca
					WHERE idAlumno = @idAlumno;
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
				UPDATE Cuentas.Alumno SET estado=@estado WHERE idAlumno=@idAlumno;
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
/*
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
*/
-------------------------------------------------------------------------------------------------------------------
--Modulo Pago 
CREATE PROCEDURE SP_AgregarPago
(
	@recibo VARCHAR(15),
	@idAlumno INT,
	@idTipo INT,
	@idDescuento INT,
    @idMora INT,
	@idUsuario INT,
	@total DECIMAL (8,2),
	@fechaPago NVARCHAR(15),
	@observacion NVARCHAR(100)
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
			INSERT INTO Cuentas.Pago(recibo, idAlumno, idTipo, idDescuento, idMora,idUsuario,total, fechaPago,observacion)
				VALUES(@recibo,@idAlumno,@idTipo,@idDescuento,@idMora,@idUsuario,@total,@fechaPago,@observacion)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarPago
(
	@idPago INT,
	@recibo VARCHAR(15),
	@idAlumno INT,
	@idTipo INT,
	@idDescuento INT,
    @idMora INT,
	@idUsuario INT,
	@total DECIMAL (8,2),
	@fechaPago NVARCHAR(15),
	@observacion NVARCHAR(100)
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
						idTipo = @idTipo,
						idDescuento = @idDescuento,
						idMora = @idMora,
						idUsuario = @idUsuario,
						total = @total,
						fechaPago = @fechaPago,
						observacion=@observacion
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
--Tipo Pago 
CREATE PROCEDURE SP_AgregarTipoPago
(
    @idnombreTipoPago INT,
	@idGrado INT,
	@valor DECIMAL
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.TipoPago.idTipoPago) FROM Cuentas.TipoPago WHERE idNombreTipoPago = @idnombreTipoPago AND idGrado = @idGrado;
    IF (@existe > 0)
        BEGIN
            RAISERROR(N'Ya existe un TipoPago con el TipoPago %s"', 16, 1,@idnombreTipoPago);
            RETURN 0
            
        END
    ELSE
        BEGIN
            INSERT INTO Cuentas.TipoPago(idNombreTipoPago,idGrado,valor)
                VALUES(@idnombreTipoPago,@idGrado,@valor)
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_ModificarTipoPago
(
    @idTipoPago INT,
	@idNombreTipoPago INT,
	@idGrado INT,
	@valor DECIMAL (6,2)
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

     SELECT @existe = COUNT(Cuentas.TipoPago.idTipoPago) FROM Cuentas.TipoPago WHERE idTipoPago = @idTipoPago;
    IF (@existe = 0)
        BEGIN
            RAISERROR(N'Ya existe un TipoPago con el TipoPago %d"', 16, 1,@idTipoPago);
            RETURN 0
            
        END
    ELSE
        BEGIN
            UPDATE Cuentas.TipoPago
                SET   idNombreTipoPago = @idNombreTipoPago,
					  idGrado = @idGrado,
						valor = @valor

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
                RAISERROR(N'No existe el NombreTipoPago con el id %d"', 16, 1, @idTipoPago);
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
                RAISERROR(N'No existe el NombreTipoPago con el id %d"', 16, 1, @idTipoPago);
                RETURN 0
            END     
        ELSE
            BEGIN
                DELETE FROM Cuentas.TipoPago WHERE idTipoPago = @idTipoPago;
                RETURN 1
            END
END
GO

-----------------------------------------------------
--Nombre de Tipo Pago
CREATE PROCEDURE SP_AgregarNombreTipoPago
(
    @nombreTipoPago NVARCHAR(30),
	@fechaLimite NVARCHAR(15)
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
            INSERT INTO Cuentas.NombreTipoPago(nombreTipoPago,fechaLimite)
                VALUES(@nombreTipoPago,@fechaLimite)
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_ModificarNombreTipoPago
(
    @idNombreTipoPago INT,
    @nombreTipoPago NVARCHAR(30),
	@fechaLimite NVARCHAR(15)
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
                SET     nombreTipoPago = @nombreTipoPago,
						fechaLimite = @fechaLimite
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
--Reportes

CREATE PROCEDURE SP_MostrarReporte
(
	@fechaDe VARCHAR,
	@fechaHasta VARCHAR,
	@idNombre INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.Pago.idPago) FROM Cuentas.Pago;

    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe el pago ', 16, 1);
            RETURN 0
        END     
    ELSE
        BEGIN
            SELECT        Cuentas.Grado.nombreGrado AS GRADO, Cuentas.Alumno.nombres AS NOMBRES, Cuentas.Alumno.apellidos AS APELLIDOS, Cuentas.Pago.total AS TOTAL, 
						  Cuentas.Pago.recibo AS RECIBO, Cuentas.Pago.fechaPago AS FECHA,Cuentas.Mora.nombreMora AS RECARGO, Cuentas.Descuento.nombreDescuento AS DESCUENTO, 
                         Cuentas.Pago.observacion AS OBSERVACIÓN
			FROM         Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Descuento ON Cuentas.Pago.idDescuento = Cuentas.Descuento.idDescuento INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
			WHERE        (Cuentas.Pago.fechaPago > @fechaDE AND Cuentas.Pago.fechaPago <= @fechaHasta) AND (Cuentas.TipoPago.idNombreTipoPago = @idNombre) AND (Cuentas.Alumno.estado = 1)
        END
END
GO
--EXEC SP_MostrarReporteAlumnoPago 2
--Para nuevo reporte
CREATE PROCEDURE SP_MostrarReporteAlumnoPago
(
	@idAlumno INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.Pago.idPago) FROM Cuentas.Pago;

    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe el pago ', 16, 1);
            RETURN 0
        END     
    ELSE
        BEGIN
			SELECT					Cuentas.Pago.idPago         as Código,
                                    Cuentas.Grado.nombreGrado   as Grado,
                                    Cuentas.Alumno.nombres      as Nombres, 
                                    Cuentas.Alumno.apellidos    as Apellidos,
                                    Cuentas.Pago.recibo         as Recibo,
                                    Cuentas.NombreTipoPago.nombreTipoPago   as Pago,
                                    Cuentas.Mora.nombreMora     as Mora,
                                    Cuentas.Pago.total          as Total,
                                    Cuentas.Pago.observacion    as Observación
                            FROM Cuentas.Pago  INNER JOIN  Cuentas.Alumno ON 
                            Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno INNER JOIN Cuentas.Grado 
							ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN Cuentas.Mora ON
                            Cuentas.Pago.idMora = Cuentas.Mora.idMora INNER JOIN Cuentas.TipoPago 
							ON Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago
                            INNER JOIN Cuentas.NombreTipoPago 
							ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago AND
                            Cuentas.Pago.estado = 1 AND Cuentas.Pago.idAlumno =@idAlumno ORDER BY Cuentas.Pago.idPago DESC
		END
END
GO
--EXEC SP_MostrarReporte '13/4/2020','19/4/2020',1
--EXEC SP_MostrarSumaReporte '13/4/2020','15/4/2020',1
--SELECT * FROM Cuentas.Pago WHERE (Cuentas.Pago.fechaPago > '13/4/2020' AND Cuentas.Pago.fechaPago <='15/4/2020')

CREATE PROCEDURE SP_MostrarSumaReporte
(
	@fechaDe VARCHAR,
	@fechaHasta VARCHAR,
	@idNombre INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.Pago.idPago) FROM Cuentas.Pago;

    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe el pago ', 16, 1);
            RETURN 0
        END     
    ELSE
        BEGIN
            SELECT        SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago AS PAGO
			FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
			WHERE       (Cuentas.Pago.fechaPago > @fechaDE AND Cuentas.Pago.fechaPago <= @fechaHasta) AND (Cuentas.TipoPago.idNombreTipoPago = @idNombre)
			GROUP BY Cuentas.NombreTipoPago.nombreTipoPago			 
        END
END
GO
--
CREATE PROCEDURE SP_TotalPagos
AS
BEGIN
 DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.Pago.idPago) FROM Cuentas.Pago;

    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe el pago ', 16, 1);
            RETURN 0
        END     
    ELSE
        BEGIN

SELECT       COUNT(Cuentas.Pago.idPago) AS Cantidad, SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 1)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 2)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 3)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 4)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 5)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 6)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 7)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 8)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 9)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 10)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT        COUNT(Cuentas.Pago.idPago) AS Cantidad,SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 11)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT     COUNT(Cuentas.Pago.idPago) AS Cantidad, SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 12)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT     COUNT(Cuentas.Pago.idPago) AS Cantidad, SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 13)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
UNION
SELECT     COUNT(Cuentas.Pago.idPago) AS Cantidad, SUM(Cuentas.Pago.total) AS Total, Cuentas.NombreTipoPago.nombreTipoPago
FROM            Cuentas.TipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.NombreTipoPago ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 14)
GROUP BY Cuentas.NombreTipoPago.nombreTipoPago
END
END
GO