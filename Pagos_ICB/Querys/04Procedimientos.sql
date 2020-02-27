USE DBICB
GO


--sin terminar
--Modulo Usuarios
CREATE PROCEDURE SP_BuscarUsuario
(
    @usuario NVARCHAR(25)
)
AS
BEGIN
    DECLARE @existe INT
    SELECT @existe = COUNT(Acceso.Usuarios.usuario) FROM Acceso.Usuarios WHERE usuario = @usuario;
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

            SELECT @existe = COUNT(Acceso.Usuarios.usuario) FROM Acceso.Usuarios WHERE usuario = @usuario;
            IF (@existe > 0)
                BEGIN
                    RAISERROR(N'Ya existe un usuario con el nombre  "%s %s"', 16, 1, @nombre, @apellido);
                    RETURN 0
                END     
            ELSE
                BEGIN
                    INSERT INTO Acceso.Usuarios(nombre, apellido, usuario, clave)
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

            SELECT @existe = COUNT(Acceso.Usuarios.usuario) FROM Acceso.Usuarios WHERE usuario = @usuarioAnterior;
            IF (@existe = 0)
                BEGIN
                    RAISERROR(N'No existe un usuario con el nombre  "%s %s"', 16, 1, @nombre, @apellido);
                    RETURN 0
                END     
            ELSE
                BEGIN
                    UPDATE Acceso.Usuarios
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
            SELECT @existe = COUNT(Acceso.Usuarios.usuario) FROM Acceso.Usuarios WHERE usuario = @usuario;
            IF (@existe = 0)
                BEGIN
                    RAISERROR(N'No existe un usuario con el nombre "', 16, 1);
                    RETURN 0
                END     
            ELSE
                BEGIN
                    UPDATE Acceso.Usuarios SET estado=@estado WHERE usuario = @usuario;
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

            SELECT @existe = COUNT(Acceso.Usuarios.usuario) FROM Acceso.Usuarios WHERE usuario = @usuario;
            IF (@existe = 0)
                BEGIN
                    RAISERROR(N'No existe un usuario con el nombre "', 16, 1);
                    RETURN 0
                END     
            ELSE
                BEGIN
                    DELETE FROM Acceso.Usuarios WHERE usuario = @usuario;
                    RETURN 1
                END
END
GO
----------------------------------------------------------
--Modulo 

CREATE PROCEDURE SP_AgregarProveedor
(
	@nombre NVARCHAR(100),
	@telefono NVARCHAR(9),
	@direccion NVARCHAR(300)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Proveedores.idProveedor) FROM Cuentas.Proveedores WHERE nombre = @nombre;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un proveedor con el nombre  "%s"', 16, 1, @nombre);
			RETURN 0			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Proveedores(nombre, telefono, direccion)
				VALUES(@nombre, @telefono, @direccion)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarProveedor
(
	@idProveedor INT,
	@nombre NVARCHAR(100),
	@telefono NVARCHAR(9),
	@direccion NVARCHAR(300)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Proveedores.idProveedor) FROM Cuentas.Proveedores WHERE idProveedor = @idProveedor;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el proveedor con el id %d"', 16, 1, @idProveedor);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Proveedores
				SET 	nombre = @nombre,
						telefono = @telefono,
						direccion = @direccion
					WHERE idProveedor = @idProveedor;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarProveedor1
(
	@idProveedor INT,
	@estado BIT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Proveedores.idProveedor) FROM Cuentas.Proveedores WHERE idProveedor = @idProveedor;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el proveedor con el id %d"', 16, 1, @idProveedor);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Proveedores SET estado=@estado	WHERE idProveedor = @idProveedor;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarProveedor
(
	@idProveedor INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Proveedores.idProveedor) FROM Cuentas.Proveedores WHERE idProveedor = @idProveedor;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el proveedor con el id %d"', 16, 1, @idProveedor);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Proveedores	WHERE idProveedor = @idProveedor;
				RETURN 1
			END
END
GO
----------------------------------------------------------------------------------------
--Modulo Alumnos
CREATE PROCEDURE SP_AgregarAlumnos
(
	@identidad NVARCHAR(15),
	@nombres NVARCHAR(25),
	@apellidos NVARCHAR(25),
	@idGrado INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Alumnos.identidad) FROM Cuentas.Alumnos WHERE identidad = @identidad;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe Un Alumno con la identidad %s"', 16, 1, @identidad);
			RETURN 0		
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Alumnos(identidad, nombres, apellidos, idGrado)
				VALUES(	@identidad, @nombres, @apellidos, @idGrado)
			RETURN 1
		END
END
GO

Create PROCEDURE SP_ModificarAlumno
(	
	@id INT,
	@identidad NVARCHAR(15),
	@nombres NVARCHAR(25),
	@apellidos NVARCHAR(25),
	@idGrado INT,
	@beca BIT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Alumnos.identidad) FROM Cuentas.Alumnos WHERE identidad=@identidad;
	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Alumno con la identidad %s"', 16, 1, @identidad);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Alumnos
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
	@id INT,
	@estado BIT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
			SELECT @existe = COUNT(Cuentas.Alumnos.id) FROM Cuentas.Alumnos WHERE id=@id;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Alumno con el id %d"', 16, 1, @id);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Alumnos SET estado=@estado	WHERE id=@id;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarAlumno
(
	@id INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
			SELECT @existe = COUNT(Cuentas.Alumnos.id) FROM Cuentas.Alumnos WHERE id=@id;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Alumno con el id %d"', 16, 1, @id);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Alumnos	WHERE id=@id;
				RETURN 1
			END
END
GO
-----------------------------------------------------------------------------------
--Modulo Insumos
USE DBICB
GO
CREATE PROCEDURE SP_AgregarInsumo
(
    @nombre NVARCHAR(100),
    @costo DECIMAL(4,2),
	@cantidad INT,
	@cantidadMinima INT,
    @idTipoUnidad INT,
    @descripcion NVARCHAR(200),
    @idProveedor INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.Insumos.idInsumo) FROM Cuentas.Insumos WHERE nombre = @nombre;
    IF (@existe > 0)
        BEGIN
            RAISERROR(N'Ya existe un Insumo con el nombre %s"', 16, 1,@nombre);
            RETURN 0
            
        END
    ELSE
        BEGIN
            INSERT INTO Cuentas.Insumos(nombre, costo, cantidad,cantidadMinima,idTipoUnidad, descripcion, idProveedor)
                VALUES(@nombre, @costo, @cantidad,@cantidadMinima,@idTipoUnidad, @descripcion, @idProveedor)
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_ModificarInsumo
(
    @idInsumo INT,
    @nombre NVARCHAR(100),
    @costo DECIMAL(4,2),
	@cantidad INT,
	@cantidadMinima INT,
    @idTipoUnidad INT,
    @descripcion NVARCHAR(200),
    @idProveedor INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.Insumos.IdInsumo) FROM Cuentas.Insumos WHERE IdInsumo = @idInsumo;

    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe el insumo con el id %d"', 16, 1, @idInsumo);
            RETURN 0
        END     
    ELSE
        BEGIN
            UPDATE Cuentas.Insumos
                SET     nombre = @nombre,
                        costo = @costo,
						cantidad=@cantidad,
						cantidadMinima=@cantidadMinima ,
                        idTipoUnidad = @idTipoUnidad,
                        descripcion = @descripcion,
                        idProveedor = @idProveedor
                    WHERE idInsumo = @idInsumo;
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_EliminarInsumo1
(
    @idInsumo INT,
	@estado BIT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
        SELECT @existe = COUNT(Cuentas.Insumos.IdInsumo) FROM Cuentas.Insumos WHERE IdInsumo = @idInsumo;
        IF (@existe = 0)
            BEGIN
                RAISERROR(N'No existe el insumo con el id %d"', 16, 1, @idInsumo);
                RETURN 0
            END     
        ELSE
            BEGIN
                UPDATE Cuentas.Insumos SET estado=@estado WHERE idInsumo = @idInsumo;
                RETURN 1
            END
END
GO

CREATE PROCEDURE SP_EliminarInsumo
(
    @idInsumo INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
        SELECT @existe = COUNT(Cuentas.Insumos.IdInsumo) FROM Cuentas.Insumos WHERE IdInsumo = @idInsumo;
        IF (@existe = 0)
            BEGIN
                RAISERROR(N'No existe el insumo con el id %d"', 16, 1, @idInsumo);
                RETURN 0
            END     
        ELSE
            BEGIN
                DELETE FROM Cuentas.Insumos WHERE idInsumo = @idInsumo;
                RETURN 1
            END
END
GO
--------------------------------------------------------------------------------------------
--Modulo Tipo de Unidad
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
            RAISERROR(N'Ya existe un Tipo de Unidad con el nombre "%s"', 16, 1,@descripcion);
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
            RAISERROR(N'No existe ning�n Tipo de Unidad con el id "%d"', 16, 1, @idTipoUnidad);
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
            RAISERROR(N'No existe ning�n Tipo de Unidad con el id "%d"', 16, 1, @idTipoUnidad);
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
            RAISERROR(N'No existe ning�n Tipo de Unidad con el id "%d"', 16, 1, @idTipoUnidad);
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
			RAISERROR(N'Ya existe una area con el nombre "%s"', 16, 1,@estado);
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
    @idInventario INT,
    @cantidad INT,
	@subtotal DECIMAL
)
AS
BEGIN
            INSERT INTO Cuentas.DetallePedidos
            (
                idPedido,
                idInventario,
                cantidad,
				subTotal
            )
            VALUES
            ( @idPedido,@idInventario,@cantidad,@subtotal)
                
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
GO
--------------------------------------------------------------------------------------
--Modulo Factura
CREATE PROCEDURE SP_AgregarFactura
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

	SELECT @existe = COUNT(Cuentas.Facturas.idPedido) FROM Cuentas.Facturas WHERE idPedido=@idPedido;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un pedido con el id "%d"', 16, 1,@idPedido);
			RETURN 0
			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Facturas
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
GO
-------------------------------------------------------------------------------------------------------------------
--Modulo Inventario 
CREATE PROCEDURE SP_AgregarInventario
(
	@descripcion NVARCHAR(100),
	@costo DECIMAL(8,2),
	@precioVenta DECIMAL(8,2),
	@cantidad DECIMAL(8,2),
	@cantidadMinima DECIMAL(8,2),
	@idCategoria INT,
	@idTipoProducto INT,
	@idProveedor INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.Inventario.idInventario) FROM Cuentas.Inventario WHERE descripcion = @descripcion;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un Insumo con el nombre %s"', 16, 1,@descripcion);
			RETURN 0
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.Inventario(descripcion, costo, precioVenta, cantidad,cantidadMinima,idCategoria, idTipoProducto, idProveedor)
				VALUES(@descripcion, @costo, @precioVenta, @cantidad,@cantidadMinima,@idCategoria, @idTipoProducto, @idProveedor)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarInventario
(
	@idInventario INT,
	@descripcion NVARCHAR(100),
	@costo DECIMAL(4,2),
	@precioVenta DECIMAL(4,2),
	@cantidad DECIMAL(4,2),
	@cantidadMinima DECIMAL(4,2),
	@idCategoria INT,
	@idTipoProducto INT,
	@idProveedor INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.Inventario.idInventario) FROM Cuentas.Inventario WHERE idInventario = @idInventario;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el Producto con el id %d"', 16, 1, @idInventario);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.Inventario
				SET 	descripcion = @descripcion,
						costo = @costo,
						precioVenta = @precioVenta,
						cantidad = @cantidad,
						cantidadMinima = @cantidadMinima,
						idCategoria = @idCategoria,
						idTipoProducto = @idTipoProducto,
						idProveedor = @idProveedor
					WHERE idInventario = @idInventario;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarInventario1
(
	@idInventario INT,
	@estado BIT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Inventario.idInventario) FROM Cuentas.Inventario WHERE idInventario = @idInventario;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Producto con el id %d"', 16, 1, @idInventario);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.Inventario SET estado=@estado WHERE idInventario = @idInventario;
				RETURN 1
			END
END
GO

CREATE PROCEDURE SP_EliminarInventario
(
	@idInventario INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.Inventario.idInventario) FROM Cuentas.Inventario WHERE idInventario = @idInventario;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el Producto con el id %d"', 16, 1, @idInventario);
				RETURN 0
			END 	
		ELSE
			BEGIN
				DELETE FROM Cuentas.Inventario WHERE idInventario = @idInventario;
				RETURN 1
			END
END
GO
--------------------------------------------------------------------------------------------------------
-- Modulo insumo Producto


CREATE PROCEDURE SP_AgregarInsumosProductos
(
	@idInsumo INT,
	@idInventario INT,
	@cantidad DECIMAL(8,2)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.InsumosProductos.idInsumoProducto) FROM Cuentas.InsumosProductos WHERE idInsumo = @idInsumo AND idInventario = @idInventario;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe ese Insumo', 16, 1);
			RETURN 0
			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.InsumosProductos(idInsumo, idInventario,cantidad)
				VALUES(@idInsumo, @idInventario,@cantidad)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarInsumosProductos
(
	@idInsumoProducto INT,
	@idInsumo INT,
	@idInventario INT,
	@cantidad DECIMAL(8,2)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.InsumosProductos.idInsumoProducto) FROM Cuentas.InsumosProductos WHERE idInsumoProducto = @idInsumoProducto;

	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe el insumo en el producto con el id %d"', 16, 1, @idInsumoProducto);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.InsumosProductos
				SET 	idInsumo = @idInsumo,
						idInventario = @idInventario,
						cantidad = @cantidad
					WHERE idInsumoProducto = @idInsumoProducto;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarInsumosProductos
(
	@idInsumoProducto INT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
		SELECT @existe = COUNT(Cuentas.InsumosProductos.idInsumoProducto) FROM Cuentas.InsumosProductos WHERE idInsumoProducto = @idInsumoProducto;
		IF (@existe = 0)
			BEGIN
				RAISERROR(N'No existe el insumo con el id %d"', 16, 1, @idInsumoProducto);
				RETURN 0
			END 	
		ELSE
			BEGIN
				UPDATE Cuentas.InsumosProductos SET estado=0 WHERE idInsumoProducto = @idInsumoProducto;
				RETURN 1
			END
END
GO
-------------------------------------------------
--Modulo Categoria de Producto
CREATE PROCEDURE SP_AgregarCategoriaProducto
(
	@descripcion NVARCHAR(100)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;

	SELECT @existe = COUNT(Cuentas.CategoriaProducto.idCategoria) FROM Cuentas.CategoriaProducto WHERE descripcion=@descripcion;
	IF (@existe > 0)
		BEGIN
			RAISERROR(N'Ya existe un Tipo de Unidad con el nombre "%s"', 16, 1,@descripcion);
			RETURN 0
			
		END
	ELSE
		BEGIN
			INSERT INTO Cuentas.CategoriaProducto(descripcion)
				VALUES(@descripcion)
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_ModificarCategoriaProducto
(
	@idCategoriaProducto INT,
	@descripcion NVARCHAR(100)
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.CategoriaProducto.idCategoria) FROM Cuentas.CategoriaProducto WHERE idCategoria=@idCategoriaProducto;
	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe ning�n Tipo de Unidad con el id "%d"', 16, 1, @idCategoriaProducto);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.CategoriaProducto
				SET 	descripcion = @descripcion
					WHERE idCategoria = @idCategoriaProducto;
			RETURN 1
		END
END
GO

CREATE PROCEDURE SP_EliminarCategoriaProducto1
(
	@idCategoriaProducto INT,
	@estado BIT
)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.CategoriaProducto.idCategoria) FROM Cuentas.CategoriaProducto WHERE idCategoria=@idCategoriaProducto;
	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe ning�n Tipo de Unidad con el id "%d"', 16, 1, @idCategoriaProducto);
			RETURN 0
		END 	
	ELSE
		BEGIN
			UPDATE Cuentas.CategoriaProducto SET estado=@estado WHERE idCategoria = @idCategoriaProducto;
			RETURN 1
		END
END
GO
CREATE PROCEDURE SP_EliminarCategoriaProducto
(
	@idCategoriaProducto INT

)
AS
BEGIN
	DECLARE @existe int;
	SET @existe = 0;
	SELECT @existe = COUNT(Cuentas.CategoriaProducto.idCategoria) FROM Cuentas.CategoriaProducto WHERE idCategoria=@idCategoriaProducto;
	IF (@existe = 0)
		BEGIN
			RAISERROR(N'No existe ning�n Tipo de Unidad con el id "%d"', 16, 1, @idCategoriaProducto);
			RETURN 0
		END 	
	ELSE
		BEGIN
			DELETE FROM Cuentas.CategoriaProducto WHERE idCategoria = @idCategoriaProducto;
			RETURN 1
		END
END
GO
-- Modulo caja
-- INSERTAR datos en la APERTURA de CAJA
--CREATE PROCEDURE SP_Agregar_AperturaCaja
--(
--	@Apertura decimal(18,0),
--	@idDetalleCaja int
--)
--AS
--BEGIN
--	INSERT INTO Cuentas.Caja (apertura, idDetalleCaja, fecha)
--		VALUES (@Apertura, @idDetalleCaja, GETDATE())
--END
--GO

---- INSERTAR datos en el CIERRE de CAJA
--CREATE PROCEDURE SP_Agregar_CierreCaja
--(
--	@Cierre decimal(18,0),
--	@idDetalleCaja int,
--	@Dolares decimal(18,0),
--	@POS decimal(18,0),
--	@Fiveh int,
--	@Hundred int,
--	@Fifty int,
--	@Twenty int,
--	@Ten int,
--	@Five int,
--	@Two int,
--	@One int
--)
--AS
--BEGIN
--	INSERT INTO Cuentas.Caja (cierre, dolares, POS, quinientos, cien, cincuenta,
--								  veinte, diez, cinco, dos, uno, fecha, idDetalleCaja)
--		VALUES (@Cierre, @Dolares, @POS, @Fiveh, @Hundred, @Fifty, @Twenty, @Ten, 
--				@Five, @Two, @One, GETDATE(), @idDetalleCaja)
--END
--GO
---------------------------------------------------------
--Modulo Tipo de Producto
CREATE PROCEDURE SP_InsertarTipoProducto
(
    @nombre NVARCHAR(100)
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;

    SELECT @existe = COUNT(Cuentas.TipoProducto.idTipoProducto) FROM Cuentas.TipoProducto WHERE nombre=@nombre;
    IF (@existe > 0)
        BEGIN
            RAISERROR(N'Ya existe un Tipo de Unidad con el nombre "%s"', 16, 1,@nombre);
            RETURN 0          
        END
    ELSE
        BEGIN
            INSERT INTO Cuentas.TipoProducto(nombre)
                VALUES(@nombre)
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_ModificarTipoProducto
(
    @idTipoProducto INT,
    @nombre NVARCHAR(100)
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
    SELECT @existe = COUNT(Cuentas.TipoProducto.idTipoProducto) FROM Cuentas.TipoProducto WHERE idTipoProducto=@idTipoProducto;
    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe ning�n Tipo de Unidad con el id "%d"', 16, 1, @idTipoProducto);
            RETURN 0
        END     
    ELSE
        BEGIN
            UPDATE Cuentas.TipoProducto
                SET     nombre = @nombre
                    WHERE idTipoProducto = @idTipoProducto;
            RETURN 1
        END
END
GO

CREATE PROCEDURE SP_EliminarTipoProducto
(
    @idTipoProducto INT
)
AS
BEGIN
    DECLARE @existe int;
    SET @existe = 0;
    SELECT @existe = COUNT(Cuentas.TipoProducto.idTipoProducto) FROM Cuentas.TipoProducto WHERE idTipoProducto=@idTipoProducto;
    IF (@existe = 0)
        BEGIN
            RAISERROR(N'No existe ning�n Tipo de Producto con el id "%d"', 16, 1, @idTipoProducto);
            RETURN 0
        END     
    ELSE
        BEGIN
            UPDATE Cuentas.TipoProducto SET estado=0 WHERE idTipoProducto = @idTipoProducto;
            RETURN 1
        END
END
GO
/*
----------------------------------------------------------------------------------------------------------------
--SP para actualizar el stock dela Tabla Inventario.Articulos 
CREATE PROCEDURE Inventario.SPActualizarArticulos(
	@CodigoArticulo VARCHAR(15),
	@Stock INT
  )
AS
BEGIN
	DECLARE @Codigo INT
	DECLARE @CodigoProducto VARCHAR(15) = @CodigoArticulo

	EXEC @Codigo = Inventario.SPEstadoDelArticulo @CodigoProducto
	IF @Codigo = 1
		PRINT 'Debe ingresar el codigo del Articulo'
	ELSE
		IF @Codigo = 2
			PRINT 'El Codigo del producto ingresado no es v�lido'
		ELSE
			IF @Codigo = 3
				PRINT 'No hay existencia de este producto'
			ELSE
				IF @Codigo = 0
					PRINT 'Producto encontrado'

	DECLARE @Stock1 INT 
	SELECT @Stock1 = Stock FROM Inventario.Articulos
			WHERE Codigo = @CodigoProducto

UPDATE Inventario.Articulos
SET Stock = @Stock1 + @Stock
FROM Inventario.Articulos
WHERE Codigo = @CodigoProducto

END
--Probando con valores Incorrectos
EXEC Inventario.SPActualizarArticulos '3 154141 194108';
--Probando Valores Correctos
EXEC Inventario.SPActualizarArticulos '3 154141 194108',4;
GO
------------------------------------------------------------------------------------------------
	-- Creaci�n de un Stored Procedure que se encarga de ingresar
	-- valores a la tabla Factura 
CREATE PROCEDURE SP_sFacturas(
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
		--Declaramos las Variables las cuales nos serviran al momento de la inserci�n
		DECLARE @Vendedor INT  = @IdVendedor
		DECLARE @Cliente CHAR (15) = @IdCliente
		DECLARE @ImporteISV DECIMAL(10,2) = 0
		DECLARE @Impuesto DECIMAL(10,2) = 0
		DECLARE @Total DECIMAL(10,2) = 0
		INSERT INTO Facturacion.Factura(IdVendedor,IdCliente, ImporteISV,Impuesto,Total )
				VALUES(@Vendedor,@Cliente,@ImporteISV,@Impuesto,@Total)
			RETURN 1
		END
END
GO



---------------------------------------------------------------------------------------
    -- Creaci�n de un Stored Procedure que se encarga de ingresar
	-- valores a la tabla Detalle Factura 
CREATE PROCEDURE Facturacion.SPDetalleFacturas(
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
	DECLARE @NumeroFactura INT
	DECLARE @Codigo INT
	DECLARE @CodigoArticulo1 VARCHAR(15) = @CodigoArticulo
	DECLARE @PrecioUnitario DECIMAL (10,2)
	DECLARE @SubTotal DECIMAL (10,2)

-- Verificar Codigo de Producto
	EXEC @Codigo = Inventario.SPEstadoDelArticulo @CodigoArticulo1
	IF @Codigo = 1
		PRINT 'Debe ingresar el codigo del Articulo'
	ELSE
		IF @Codigo = 2
			PRINT 'El Codigo del producto ingresado no es v�lido'
		ELSE
			IF @Codigo = 3
				PRINT 'No hay existencia de este producto'
			ELSE
				IF @Codigo = 0
					PRINT 'Producto encontrado'
--BUSCANDO VALORES
		SET @NumeroFactura = (SELECT MAX(Numero) FROM Facturacion.Factura)
		SELECT @PrecioUnitario = PrecioVenta FROM Inventario.Articulos
		WHERE Codigo = @CodigoArticulo
		SET @SubTotal = @PrecioUnitario * @CantidadArticulo
		DECLARE @Impuesto DECIMAL(10,2)
		DECLARE @Importe DECIMAL(10,2)
--Ejecutamos los Stored Procedure de calculo de impuesto e importe
		EXEC Facturacion.SPCalculoImporte @CodigoArticulo,@SubTotal,@Importe OUTPUT
		EXEC Facturacion.SPExcentoImpuesto @CodigoArticulo,@Importe,@Impuesto OUTPUT
--Insertamos los datos en la tabla Detalle Factura
		INSERT INTO Facturacion.DetalleFactura(NumeroFactura,CodigoArticulo,CantidadArticulo,PrecioUnitario,Subtotal) 
			VALUES (@NumeroFactura,@CodigoArticulo1,@CantidadArticulo,@PrecioUnitario,@SubTotal)
		
				IF ((SELECT Stock FROM Inventario.Articulos 
					WHERE Codigo = @CodigoArticulo1)<=(SELECT CantidadMinima FROM Inventario.Articulos
					WHERE Codigo = @CodigoArticulo1))
				BEGIN
					PRINT 'Se ha alcanzado el inventario minimo para el producto '+ @CodigoArticulo1 +'. Considere contactar a su proveedor.'
				END
--Actualizamos nuestro encabezado en la Tabla Factura para los campos
--IMPUESTO,IMPORTEISV,TOTAL		
		UPDATE Facturacion.Factura
		SET ImporteISV=@Importe,Impuesto = @Impuesto, Total = @SubTotal
		FROM Facturacion.Factura
		INNER JOIN Facturacion.DetalleFactura
		ON @NumeroFactura=Numero
		WHERE Numero= @NumeroFactura
END
GO
*/

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
GO