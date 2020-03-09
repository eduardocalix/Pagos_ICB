USE DBICB
GO
--Insercion de los principales datos
--Agregando Roles

--SP_InsertarUsuario(nombre, apellido, usuario, clave, tipoArea)
EXEC SP_InsertarUsuario 'eduardo','calix','nose', 1
--Agregar Categorias 

EXEC SP_AgregarCategoriaProducto 'Licores'
EXEC SP_AgregarCategoriaProducto 'Bebidas'
EXEC SP_AgregarCategoriaProducto 'Comidas'
--Agregar Tipo productos
EXEC SP_InsertarTipoProducto 'Elaborado'
EXEC SP_InsertarTipoProducto 'Artificial'
--EXEC SP_InsertarTipoProducto 'Dieciocho'
--Agregar NombreTipoPagos
EXEC SP_AgregarNombreTipoPago 'Matricula'
EXEC SP_AgregarNombreTipoPago 'Bolsa'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 3'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 4'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 5'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 6'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 7'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 8'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 9'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 10'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 11'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 12'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 13'
EXEC SP_AgregarNombreTipoPago 'NombreTipoPago 14'


--SP_AgregarMesero(identidad,nombre, apellido)
EXEC SP_AgregarMesero '1111-1111-11111','Pedro','Picapiedra'
--SP_AgregarProveedor(nombre,telefono,direccion)
EXEC SP_AgregarProveedor 'Pablo Marmol','9999-9999','Piedra Dura'
-- SP_InsertarTipoUnidad(descripcion)
EXEC SP_InsertarTipoUnidad 'Libras'
EXEC SP_InsertarTipoUnidad 'Unidades'
EXEC SP_InsertarTipoUnidad 'Docena'
--SP_AgregarInsumo(nombre,costo,idTipoUnidad, descripcion,proveedor)
EXEC SP_AgregarInsumo 'tomate',10,5,1,1,'para condimentar',1
EXEC SP_AgregarInsumo 'Pescado',50,15,3,2,'de 100 lempiras',1
--SP_AgregarInventario(	descripcion,costo,precioVenta ,cantidad,cantidadMinima,idCategoria,idTipoProducto,idProveedor )

EXEC SP_AgregarInventario 'Pescado', 60, 100, 3, 1, 3, 1, 1
EXEC SP_AgregarInventario 'Fresco', 15, 20, 3, 1, 1, 2, 1
EXEC SP_AgregarInventario 'Pollo', 50, 70, 3, 1, 3, 1, 1
EXEC SP_AgregarInventario 'Chuleta', 55, 80, 3, 3, 1, 1, 1


INSERT INTO Restaurante.ServicioPublico
(
    Descripcion
)
VALUES
('Agua'),('Luz'),('Gas'),('Otro')

    
	GO
--SP_AgregarPedido(fecha, idNombreTipoPago, RTN, NombreCliente, idMesero)
--EXEC SP_AgregarPedido '28/11/2018', 5, '03181998011792', 'Norman', 1
----SP_AgregarDetallePedido(idPedido, idInventario, cantidad)
--EXEC SP_AgregarDetallePedido 1, 1, 2
----SP_AgregarFactura(idPedido, idUsuario, subTotal, descuento, exento, iva15, iva18, total)
--EXEC SP_AgregarFactura 1, 1, 1, 100, 0, 0, 10, 0, 110