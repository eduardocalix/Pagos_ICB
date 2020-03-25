USE DBICB
GO
--Insercion de los principales datos
--Agregando Roles

--SP_InsertarUsuario(nombre, apellido, usuario, clave, tipoArea)
EXEC SP_InsertarUsuario 'eduardo','calix','nose'
--Agregar Categorias 

EXEC SP_AgregarGrado 'PREKINDER'
EXEC SP_AgregarGrado 'KINDER'
EXEC SP_AgregarGrado 'PREPARATORIA'
EXEC SP_AgregarGrado 'PRIMERO'
EXEC SP_AgregarGrado 'SEGUNDO'
EXEC SP_AgregarGrado 'TERCERO'
EXEC SP_AgregarGrado 'CUARTO'
EXEC SP_AgregarGrado 'QUINTO'
EXEC SP_AgregarGrado 'SEXTO'
EXEC SP_AgregarGrado 'SEPTIMO'
EXEC SP_AgregarGrado 'OCTAVO'
EXEC SP_AgregarGrado 'NOVENO'
EXEC SP_AgregarGrado 'DECIMO'
EXEC SP_AgregarGrado 'UNDECIMO'
--Agregar Tipo productos

--Agregar NombreTipoPagos
EXEC SP_AgregarNombreTipoPago 'MATRICULA'
EXEC SP_AgregarNombreTipoPago 'BOLSA ESCOLAR'
EXEC SP_AgregarNombreTipoPago 'SEPTIEMBRE','5/10/2019'
EXEC SP_AgregarNombreTipoPago 'OCTUBRE','5/11/2019'
EXEC SP_AgregarNombreTipoPago 'NOVIEMBRE','5/12/2019'
EXEC SP_AgregarNombreTipoPago 'DICIEMBRE','5/1/2020'
EXEC SP_AgregarNombreTipoPago 'ENERO','5/2/2020'
EXEC SP_AgregarNombreTipoPago 'FEBRERO','5/3/2020'
EXEC SP_AgregarNombreTipoPago 'MARZO','5/4/2020'
EXEC SP_AgregarNombreTipoPago 'ABRIL','5/5/2020'
EXEC SP_AgregarNombreTipoPago 'MAYO','5/6/2020'
EXEC SP_AgregarNombreTipoPago 'JUNIO','5/7/2020'

EXEC SP_AgregarMora 'NINGUNA',0
EXEC SP_AgregarMora '1 MES',195
EXEC SP_AgregarMora '2 MESES',360
EXEC SP_AgregarMora '3 MESES',525
EXEC SP_AgregarMora '4 MESES',580

EXEC SP_AgregarDescuento 'NINGUNO',0
EXEC SP_AgregarDescuento '50 % DESCUENTO',50
EXEC SP_AgregarDescuento '30 % DESCUENTO',30
EXEC SP_AgregarDescuento '20 % DESCUENTO',20

EXEC SP_Alumno


/*
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

    
	GO*/
--SP_AgregarPedido(fecha, idNombreTipoPago, RTN, NombreCliente, idMesero)
--EXEC SP_AgregarPedido '28/11/2018', 5, '03181998011792', 'Norman', 1
----SP_AgregarDetallePedido(idPedido, idInventario, cantidad)
--EXEC SP_AgregarDetallePedido 1, 1, 2
----SP_AgregarFactura(idPedido, idUsuario, subTotal, descuento, exento, iva15, iva18, total)
--EXEC SP_AgregarFactura 1, 1, 1, 100, 0