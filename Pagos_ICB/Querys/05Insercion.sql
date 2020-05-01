USE DBICB
GO
--Insercion de los principales datos
--Agregando Roles

--SP_InsertarUsuario(nombre, apellido, usuario, clave, tipoArea)
EXEC SP_InsertarUsuario 'eduardo','calix','icb1'
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
EXEC SP_AgregarGrado 'GRADUADOS'


--Agregar NombreTipoPagos
EXEC SP_AgregarNombreTipoPago 'MATRICULA','30/8/2020'
EXEC SP_AgregarNombreTipoPago 'BOLSA ESCOLAR','30/9/2020'
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
EXEC SP_AgregarNombreTipoPago 'GRADUACION','20/7/2020'
EXEC SP_AgregarNombreTipoPago 'PAGOS POR MORA','5/7/2020'

--Mora
EXEC SP_AgregarMora 'NINGUNA',0
EXEC SP_AgregarMora '1 MES',195
EXEC SP_AgregarMora '2 MESES',360
EXEC SP_AgregarMora '3 MESES',525
EXEC SP_AgregarMora '4 MESES',580
--Descuento
EXEC SP_AgregarDescuento 'NINGUNO',0
EXEC SP_AgregarDescuento '50 % DESCUENTO',50
EXEC SP_AgregarDescuento '30 % DESCUENTO',30
EXEC SP_AgregarDescuento '20 % DESCUENTO',20
EXEC SP_AgregarDescuento '25 % DESCUENTO',25
--Periodo
EXEC SP_AgregarPeriodo 'PERIODO 2019-2020'

--Tipo Pago
--nombre,grado, valor
--Matricula
EXEC SP_AgregarTipoPago 1,1,2550
EXEC SP_AgregarTipoPago 1,2,2550
EXEC SP_AgregarTipoPago 1,3,2550
EXEC SP_AgregarTipoPago 1,4,3845
EXEC SP_AgregarTipoPago 1,5,3845
EXEC SP_AgregarTipoPago 1,6,3845
EXEC SP_AgregarTipoPago 1,7,3845
EXEC SP_AgregarTipoPago 1,8,3845
EXEC SP_AgregarTipoPago 1,9,3845
EXEC SP_AgregarTipoPago 1,10,3950
EXEC SP_AgregarTipoPago 1,11,3950
EXEC SP_AgregarTipoPago 1,12,3950
EXEC SP_AgregarTipoPago 1,13,4050
EXEC SP_AgregarTipoPago 1,14,4050
--Bolsa
EXEC SP_AgregarTipoPago 2,1,1500
EXEC SP_AgregarTipoPago 2,2,1860
EXEC SP_AgregarTipoPago 2,3,2750
EXEC SP_AgregarTipoPago 2,4,3000
EXEC SP_AgregarTipoPago 2,5,3000
EXEC SP_AgregarTipoPago 2,6,3000
EXEC SP_AgregarTipoPago 2,7,3100
EXEC SP_AgregarTipoPago 2,8,3100
EXEC SP_AgregarTipoPago 2,9,3160
EXEC SP_AgregarTipoPago 2,10,3224
EXEC SP_AgregarTipoPago 2,11,3224
EXEC SP_AgregarTipoPago 2,12,3224
EXEC SP_AgregarTipoPago 2,13,3674
EXEC SP_AgregarTipoPago 2,14,3174
--Septiembre
EXEC SP_AgregarTipoPago 3,1,2550
EXEC SP_AgregarTipoPago 3,2,2550
EXEC SP_AgregarTipoPago 3,3,2550
EXEC SP_AgregarTipoPago 3,4,3845
EXEC SP_AgregarTipoPago 3,5,3845
EXEC SP_AgregarTipoPago 3,6,3845
EXEC SP_AgregarTipoPago 3,7,3845
EXEC SP_AgregarTipoPago 3,8,3845
EXEC SP_AgregarTipoPago 3,9,3845
EXEC SP_AgregarTipoPago 3,10,3950
EXEC SP_AgregarTipoPago 3,11,3950
EXEC SP_AgregarTipoPago 3,12,3950
EXEC SP_AgregarTipoPago 3,13,4050
EXEC SP_AgregarTipoPago 3,14,4050
--Octubre
EXEC SP_AgregarTipoPago 4,1,2550
EXEC SP_AgregarTipoPago 4,2,2550
EXEC SP_AgregarTipoPago 4,3,2550
EXEC SP_AgregarTipoPago 4,4,3845
EXEC SP_AgregarTipoPago 4,5,3845
EXEC SP_AgregarTipoPago 4,6,3845
EXEC SP_AgregarTipoPago 4,7,3845
EXEC SP_AgregarTipoPago 4,8,3845
EXEC SP_AgregarTipoPago 4,9,3845
EXEC SP_AgregarTipoPago 4,10,3950
EXEC SP_AgregarTipoPago 4,11,3950
EXEC SP_AgregarTipoPago 4,12,3950
EXEC SP_AgregarTipoPago 4,13,4050
EXEC SP_AgregarTipoPago 4,14,4050
--Noviembre
EXEC SP_AgregarTipoPago 5,1,2550
EXEC SP_AgregarTipoPago 5,2,2550
EXEC SP_AgregarTipoPago 5,3,2550
EXEC SP_AgregarTipoPago 5,4,3845
EXEC SP_AgregarTipoPago 5,5,3845
EXEC SP_AgregarTipoPago 5,6,3845
EXEC SP_AgregarTipoPago 5,7,3845
EXEC SP_AgregarTipoPago 5,8,3845
EXEC SP_AgregarTipoPago 5,9,3845
EXEC SP_AgregarTipoPago 5,10,3950
EXEC SP_AgregarTipoPago 5,11,3950
EXEC SP_AgregarTipoPago 5,12,3950
EXEC SP_AgregarTipoPago 5,13,4050
EXEC SP_AgregarTipoPago 5,14,4050
--Diciembre
EXEC SP_AgregarTipoPago 6,1,2550
EXEC SP_AgregarTipoPago 6,2,2550
EXEC SP_AgregarTipoPago 6,3,2550
EXEC SP_AgregarTipoPago 6,4,3845
EXEC SP_AgregarTipoPago 6,5,3845
EXEC SP_AgregarTipoPago 6,6,3845
EXEC SP_AgregarTipoPago 6,7,3845
EXEC SP_AgregarTipoPago 6,8,3845
EXEC SP_AgregarTipoPago 6,9,3845
EXEC SP_AgregarTipoPago 6,10,3950
EXEC SP_AgregarTipoPago 6,11,3950
EXEC SP_AgregarTipoPago 6,12,3950
EXEC SP_AgregarTipoPago 6,13,4050
EXEC SP_AgregarTipoPago 6,14,4050
--Enero
EXEC SP_AgregarTipoPago 7,1,2550
EXEC SP_AgregarTipoPago 7,2,2550
EXEC SP_AgregarTipoPago 7,3,2550
EXEC SP_AgregarTipoPago 7,4,3845
EXEC SP_AgregarTipoPago 7,5,3845
EXEC SP_AgregarTipoPago 7,6,3845
EXEC SP_AgregarTipoPago 7,7,3845
EXEC SP_AgregarTipoPago 7,8,3845
EXEC SP_AgregarTipoPago 7,9,3845
EXEC SP_AgregarTipoPago 7,10,3950
EXEC SP_AgregarTipoPago 7,11,3950
EXEC SP_AgregarTipoPago 7,12,3950
EXEC SP_AgregarTipoPago 7,13,4050
EXEC SP_AgregarTipoPago 7,14,4050
--Febrero
EXEC SP_AgregarTipoPago 8,1,2550
EXEC SP_AgregarTipoPago 8,2,2550
EXEC SP_AgregarTipoPago 8,3,2550
EXEC SP_AgregarTipoPago 8,4,3845
EXEC SP_AgregarTipoPago 8,5,3845
EXEC SP_AgregarTipoPago 8,6,3845
EXEC SP_AgregarTipoPago 8,7,3845
EXEC SP_AgregarTipoPago 8,8,3845
EXEC SP_AgregarTipoPago 8,9,3845
EXEC SP_AgregarTipoPago 8,10,3950
EXEC SP_AgregarTipoPago 8,11,3950
EXEC SP_AgregarTipoPago 8,12,3950
EXEC SP_AgregarTipoPago 8,13,4050
EXEC SP_AgregarTipoPago 8,14,4050
--Marzo
EXEC SP_AgregarTipoPago 9,1,2550
EXEC SP_AgregarTipoPago 9,2,2550
EXEC SP_AgregarTipoPago 9,3,2550
EXEC SP_AgregarTipoPago 9,4,3845
EXEC SP_AgregarTipoPago 9,5,3845
EXEC SP_AgregarTipoPago 9,6,3845
EXEC SP_AgregarTipoPago 9,7,3845
EXEC SP_AgregarTipoPago 9,8,3845
EXEC SP_AgregarTipoPago 9,9,3845
EXEC SP_AgregarTipoPago 9,10,3950
EXEC SP_AgregarTipoPago 9,11,3950
EXEC SP_AgregarTipoPago 9,12,3950
EXEC SP_AgregarTipoPago 9,13,4050
EXEC SP_AgregarTipoPago 9,14,4050
--Abril
EXEC SP_AgregarTipoPago 10,1,2550
EXEC SP_AgregarTipoPago 10,2,2550
EXEC SP_AgregarTipoPago 10,3,2550
EXEC SP_AgregarTipoPago 10,4,3845
EXEC SP_AgregarTipoPago 10,5,3845
EXEC SP_AgregarTipoPago 10,6,3845
EXEC SP_AgregarTipoPago 10,7,3845
EXEC SP_AgregarTipoPago 10,8,3845
EXEC SP_AgregarTipoPago 10,9,3845
EXEC SP_AgregarTipoPago 10,10,3950
EXEC SP_AgregarTipoPago 10,11,3950
EXEC SP_AgregarTipoPago 10,12,3950
EXEC SP_AgregarTipoPago 10,13,4050
EXEC SP_AgregarTipoPago 10,14,4050
--Mayo
EXEC SP_AgregarTipoPago 11,1,2550
EXEC SP_AgregarTipoPago 11,2,2550
EXEC SP_AgregarTipoPago 11,3,2550
EXEC SP_AgregarTipoPago 11,4,3845
EXEC SP_AgregarTipoPago 11,5,3845
EXEC SP_AgregarTipoPago 11,6,3845
EXEC SP_AgregarTipoPago 11,7,3845
EXEC SP_AgregarTipoPago 11,8,3845
EXEC SP_AgregarTipoPago 11,9,3845
EXEC SP_AgregarTipoPago 11,10,3950
EXEC SP_AgregarTipoPago 11,11,3950
EXEC SP_AgregarTipoPago 11,12,3950
EXEC SP_AgregarTipoPago 11,13,4050
EXEC SP_AgregarTipoPago 11,14,4050
--Junio
EXEC SP_AgregarTipoPago 12,1,2550
EXEC SP_AgregarTipoPago 12,2,2550
EXEC SP_AgregarTipoPago 12,3,2550
EXEC SP_AgregarTipoPago 12,4,3845
EXEC SP_AgregarTipoPago 12,5,3845
EXEC SP_AgregarTipoPago 12,6,3845
EXEC SP_AgregarTipoPago 12,7,3845
EXEC SP_AgregarTipoPago 12,8,3845
EXEC SP_AgregarTipoPago 12,9,3845
EXEC SP_AgregarTipoPago 12,10,3950
EXEC SP_AgregarTipoPago 12,11,3950
EXEC SP_AgregarTipoPago 12,12,3950
EXEC SP_AgregarTipoPago 12,13,4050
EXEC SP_AgregarTipoPago 12,14,4050


--Insercion alumnos
EXEC SP_AgregarAlumno '','Leana Camila',' Acosta Argueta',1,1,'No' 
EXEC SP_AgregarAlumno '','Zoe Yadira',' Rivera Oviedo',1,1,'No'
EXEC SP_AgregarAlumno '','Cristian Manuel',' Machado Ramirez',2,1,'No'
EXEC SP_AgregarAlumno '','Emilia Monserrath ','Rivera Dubon',2,1,'No'
EXEC SP_AgregarAlumno '','Milton Rodrigo ','Arias Amaya',2,1,'No'
EXEC SP_AgregarAlumno '','Nathalie Jimena ','Lazo Barralaga',2,1,'No'
EXEC SP_AgregarAlumno '','Adriana Argelia',' Miranda',3,1,'No'
EXEC SP_AgregarAlumno '','Allyson Samantha ','Mejia Mejia',3,1,'No'
EXEC SP_AgregarAlumno '','Clara ','Benitez Puerto',3,1,'Si'
EXEC SP_AgregarAlumno '','Emiliano Rodrigo',' Davila Izaguirre',3,1,'No'
EXEC SP_AgregarAlumno '','Juan Fernando ','Suazo Escobar',3,1,'No'
EXEC SP_AgregarAlumno '','wilder Danery',' Flores Velasquez',3,1,'No'
EXEC SP_AgregarAlumno '','Anthony Jafeth ','Chavarria Duarte',4,1,'No'
EXEC SP_AgregarAlumno '','Diego José ','Ruiz Andino',4,1,'No'
EXEC SP_AgregarAlumno '','Francisco André',' Lazo Barralaga',4,1,'No'
EXEC SP_AgregarAlumno '','Kelvin Francisco',' Argueta Castillo',4,1,'No'
EXEC SP_AgregarAlumno '','Alejandro Mateo ','Cerro',5,1,'No'
EXEC SP_AgregarAlumno '','Diego Alejandro ','Alvarez',5,1,'No'
EXEC SP_AgregarAlumno '','Emily Dayana ','Orellana Recarte',5,1,'No'
EXEC SP_AgregarAlumno '','Henry Isac ','Bonilla',5,1,'No'
EXEC SP_AgregarAlumno '','Jose Sebastian',' Meza Delcid',5,1,'No'
EXEC SP_AgregarAlumno '','Marjurie Ivannia ','Almendares Lizardo',5,1,'No'
EXEC SP_AgregarAlumno '','Alfonso Felipe Miguel ','Matute Barahona',6,1,'No'
EXEC SP_AgregarAlumno '','Jose Federico ','Benitez Puerto',6,1,'Si'
EXEC SP_AgregarAlumno '','Rebeca Isabel ','Morales Vega',6,1,'No'
EXEC SP_AgregarAlumno '','Sofia Alejandra ','Cruz Andino',6,1,'No'
EXEC SP_AgregarAlumno '','Alicia Mercedes ','Ortíz Rubio',7,1,'No'
EXEC SP_AgregarAlumno '','Ballardo Antonio ','Morales Vega',7,1,'No'
EXEC SP_AgregarAlumno '','Danna Paola ','Alvarez',7,1,'No'
EXEC SP_AgregarAlumno '','Lorielly Lineth',' Avila lagos',7,1,'No' 
EXEC SP_AgregarAlumno '','Mia Yuliana ','Chavarria Recarte',7,1,'No'
EXEC SP_AgregarAlumno '','Oscar Alejandro',' Vasquez Lopez',7,1,'No'
EXEC SP_AgregarAlumno '','Sady Andres ','Rivera Jaco',7,1,'No'
EXEC SP_AgregarAlumno '','Adriana María ','Ortíz Rubio',8,1,'No'
EXEC SP_AgregarAlumno '','Ana Giselle ','Chevez Cruz',8,1,'No'
EXEC SP_AgregarAlumno '','Carmen Daniela',' Lopez Perez',8,1,'No'
EXEC SP_AgregarAlumno '','Isabella Maria ','Linares Salgado',8,1,'No'
EXEC SP_AgregarAlumno '','Manuel Ernesto ','Rios Lagos',8,1,'No'
EXEC SP_AgregarAlumno '','Marianne Elizabeth',' Romero Pineda',8,1,'No'
EXEC SP_AgregarAlumno '','Mario Ricardo ','Umanzor Bonilla',8,1,'No'
EXEC SP_AgregarAlumno '','Milagro Alejandra',' Alvarado Diaz',8,1,'No'
EXEC SP_AgregarAlumno '','Angela Samantha ','Portillo Rivera',9,1,'No'
EXEC SP_AgregarAlumno '','Astrid Gabriela ','Bonilla Sierra',9,1,'No'
EXEC SP_AgregarAlumno '','Sarah Francel ','Lazo Barralaga',9,1,'No'
EXEC SP_AgregarAlumno '','Fabricio Josimar ','Palma Castillo',9,1,'No'
EXEC SP_AgregarAlumno '','Gracia Maria ','Machado Ramirez',9,1,'No'
EXEC SP_AgregarAlumno '','Maria Regina ','Benitez Puerto',9,1,'No'
EXEC SP_AgregarAlumno '','Nelson Jose ','Chevez Cruz',9,1,'No'
EXEC SP_AgregarAlumno '','Reniery David ','Almendarez Ramos',9,1,'No'
EXEC SP_AgregarAlumno '','Aldrin Leonel Santos',10,1,'No'
EXEC SP_AgregarAlumno '','Emy Dayana ','Hernández Fuentes',10,1,'No'
EXEC SP_AgregarAlumno '','Fernando Antonio',' Salinas Romero',10,1,'No'
EXEC SP_AgregarAlumno '','Jorge Alberto',' Lazo Barralaga ',10,1,'No'
EXEC SP_AgregarAlumno '','Miguel Edgardo',' Martinez Sarmientos',10,1,'No'
EXEC SP_AgregarAlumno '','Nazareth',' Maradiaga Irias',10,1,'No'
EXEC SP_AgregarAlumno '','Franklin Josiel',' Sanchez Bonilla',10,1,'No'
EXEC SP_AgregarAlumno '','Allie Suset ','Hernández Fuentes',11,1,'No'
EXEC SP_AgregarAlumno '','Andy Manuel ','Alvarado Bonilla',11,1,'No'
EXEC SP_AgregarAlumno '','Emily Nicolle ','Banegas Saravia ',11,1,'No'
EXEC SP_AgregarAlumno '','Montserrath ','Maradiaga Irias',11,1,'No'
EXEC SP_AgregarAlumno '','Alejandro Javier ','Cervantes Cruz',12,1,'No'
EXEC SP_AgregarAlumno '','David Andres ','Quezada Flores',12,1,'No'
EXEC SP_AgregarAlumno '','Diego Enrique Velasquez Umanzor',12,1,'No'
EXEC SP_AgregarAlumno '','Emilio Jose ','Rivera Alvarado',12,1,'No'
EXEC SP_AgregarAlumno '','Juan Diego ','Martinez Mejia',12,1,'No'
EXEC SP_AgregarAlumno '','Sebastian Andres',' Molina Letelier',12,1,'No'
EXEC SP_AgregarAlumno '','Angely Alejandra ','Torres Matute',13,1,'No'
EXEC SP_AgregarAlumno '','Claudio Alejandro ','Montoya Caceres',13,1,'No'
EXEC SP_AgregarAlumno '','Daniel Ernesto','Alvarado Cruz',13,1,'No'
EXEC SP_AgregarAlumno '','Denis Sady ','Santos',13,1,'No'
EXEC SP_AgregarAlumno '','Flavio Javier ','Rios Lagos',13,1,'No'
EXEC SP_AgregarAlumno '','Freddy Alberto ','Portillo Rivera',13,1,'No'
EXEC SP_AgregarAlumno '','Lastenia Isabel ','Andara Argueta',13,1,'No'
EXEC SP_AgregarAlumno '','Liliana Isabel ','Meza Delcid',13,1,'No'
EXEC SP_AgregarAlumno '','Marjorie Nicole ','Acosta Cooper',13,1,'No'
EXEC SP_AgregarAlumno '','Wilger Eduardo ','Flores Velasquez',13,1,'No'
EXEC SP_AgregarAlumno '','Ana Jose ','Santamaria Orellana',14,1,'No'
EXEC SP_AgregarAlumno '','Andrea Gisselle', 'Rodriguez David',14,1,'No'
EXEC SP_AgregarAlumno '','Angie Johanna ','Irias Doblado',14,1,'No'
EXEC SP_AgregarAlumno '','Anielska Marcela',' Villeda Aguilar',14,1,'No'
EXEC SP_AgregarAlumno '','Aldrina ','Santos Lagos',14,1,'No'
EXEC SP_AgregarAlumno '','Alejandro Jose',' Chan',14,1,'No'
EXEC SP_AgregarAlumno '','Claudia Elena ','Portillo Rivera',14,1,'No'
EXEC SP_AgregarAlumno '','Daniella Maria ','Salinas Romero',14,1,'No'
EXEC SP_AgregarAlumno '','Diana Isabel ','Banegas Morales',14,1,'No'
EXEC SP_AgregarAlumno '','Erika Marcela ','Lazo Barralaga',14,1,'No'
EXEC SP_AgregarAlumno '','Juan Carlos ','Zapata Ponce',14,1,'No'
EXEC SP_AgregarAlumno '','Marisabel ','Martinez Mejia',14,1,'No'
EXEC SP_AgregarAlumno '','Meylin Nicole ','Morales Alvarado',14,1,'No'
EXEC SP_AgregarAlumno '','Paola Nicolle',' Merino Adriano',14,1,'No'


/*
--SP_AgregarMesero(identidad,nombre, apellido)
EXEC SP_AgregarMesero '1111-1111-11111','Pedro','Picapiedra'
--SP_AgregarProveedor(nombre,telefono,direccion)
EXEC SP_AgregarProveedor 'Pablo Marmol','9999-9999','Piedra Dura'*/
