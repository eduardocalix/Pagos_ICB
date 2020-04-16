USE DBICB
GO
--Creación de las vistas para las colsultas 
--Vista para mostrar todos los alumnos
CREATE VIEW [dbo].[VistaAlumnos]
AS
SELECT        Cuentas.Alumno.idAlumno, Cuentas.Alumno.identidad, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.Grado.nombreGrado, Cuentas.Alumno.beca
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Periodo ON Cuentas.Alumno.idPeriodo = Cuentas.Periodo.idPeriodo
WHERE        (Cuentas.Alumno.estado = 1)
GO
--Vista Matricula
CREATE VIEW [dbo].[VistaMatricula]
AS
SELECT        Cuentas.Grado.nombreGrado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.Pago.total, Cuentas.Pago.recibo, Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Descuento.nombreDescuento, 
                         Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Descuento ON Cuentas.Pago.idDescuento = Cuentas.Descuento.idDescuento INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 1) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Bolsa Escolar
CREATE VIEW [dbo].[VistaBolsaEscolar]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.Pago.total, Cuentas.Pago.recibo, Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN

                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Periodo ON Cuentas.Alumno.idPeriodo = Cuentas.Periodo.idPeriodo
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 2) AND (Cuentas.Periodo.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS PeriodoActual)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Septiembre
CREATE VIEW [dbo].[VistaSeptiembre]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 3) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Octubre
CREATE VIEW [dbo].[VistaOctubre]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 4) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Noviembre
CREATE VIEW [dbo].[VistaNoviembre]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 5) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Diciembre
CREATE VIEW [dbo].[VistaDiciembre]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 6) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Enero
CREATE VIEW [dbo].[VistaEnero]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 7) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Febrero
CREATE VIEW [dbo].[VistaFebrero]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 8) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Marzo
CREATE VIEW [dbo].[VistaMarzo]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 9) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Abril
CREATE VIEW [dbo].[VistaAbril]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 10) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Mayo
CREATE VIEW [dbo].[VistaMayo]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 11) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista Junio
CREATE VIEW [dbo].[VistaJunio]
AS
SELECT        Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.TipoPago.valor AS Valor, Cuentas.Mora.valor AS Mora, Cuentas.Pago.total AS Total, Cuentas.Pago.recibo, 
                         Cuentas.Pago.fechaPago AS [Fecha de Pago], Cuentas.Pago.observacion
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Pago ON Cuentas.Alumno.idAlumno = Cuentas.Pago.idAlumno INNER JOIN
                         Cuentas.Periodo AS Periodo_1 ON Cuentas.Alumno.idPeriodo = Periodo_1.idPeriodo INNER JOIN
                         Cuentas.TipoPago ON Cuentas.Grado.idGrado = Cuentas.TipoPago.idGrado AND Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago INNER JOIN
                         Cuentas.Mora ON Cuentas.Pago.idMora = Cuentas.Mora.idMora
WHERE        (Cuentas.TipoPago.idNombreTipoPago = 12) AND (Periodo_1.idPeriodo =
                             (SELECT        MAX(idPeriodo) AS Mayor
                               FROM            Cuentas.Periodo AS Periodo)) AND (Cuentas.Alumno.estado = 1)
GO

--Vista AlumnoResumenFinal
CREATE VIEW [dbo].[VistaResumen1]
AS
SELECT        TOP (100) PERCENT Cuentas.Grado.nombreGrado AS Grado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos
FROM            Cuentas.Alumno INNER JOIN
                         Cuentas.Grado ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN
                         Cuentas.Periodo ON Cuentas.Alumno.idPeriodo = Cuentas.Periodo.idPeriodo
GROUP BY Cuentas.Grado.idGrado, Cuentas.Alumno.idAlumno, Cuentas.Grado.nombreGrado, Cuentas.Alumno.nombres, Cuentas.Alumno.apellidos, Cuentas.Alumno.estado
HAVING        (Cuentas.Alumno.estado = 1)
GO

--Vista MatriculaResumenFinal
CREATE VIEW [dbo].[VistaResumen2]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS MATRICULA
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 1)
GO
--Vista BolsaResumenFinal
CREATE VIEW [dbo].[VistaResumen3]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS [BOLSA ESCOLAR]
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 2)
GO
--Vista SeptiembreResumenFinal
CREATE VIEW [dbo].[VistaResumen4]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS SEPTIEMBRE
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 3)
GO
--Vista OctubreResumenFinal
CREATE VIEW [dbo].[VistaResumen5]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS OCTUBRE
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 4)
GO
--Vista NoviembreResumenFinal
CREATE VIEW [dbo].[VistaResumen6]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS NOVIEMBRE
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 5)
GO
--Vista DiciembreResumenFinal
CREATE VIEW [dbo].[VistaResumen7]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS DICIEMBRE
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 6)
GO
--Vista EneroResumenFinal
CREATE VIEW [dbo].[VistaResumen8]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS ENERO
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 7)
GO
--Vista FebreroResumenFinal
CREATE VIEW [dbo].[VistaResumen9]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS FEBRERO
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 8)
GO
--Vista MarzoResumenFinal
CREATE VIEW [dbo].[VistaResumen10]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS MARZO
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 9)
GO
--Vista AbrilResumenFinal
CREATE VIEW [dbo].[VistaResumen11]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS ABRIL
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 10)
GO
--Vista MayoResumenFinal
CREATE VIEW [dbo].[VistaResumen12]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS MAYO
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 11)
GO
--Vista JunioResumenFinal
CREATE VIEW [dbo].[VistaResumen13]
AS
SELECT        TOP (100) PERCENT Cuentas.Pago.total AS JUNIO
FROM            Cuentas.NombreTipoPago INNER JOIN
                         Cuentas.TipoPago ON Cuentas.NombreTipoPago.idNombreTipoPago = Cuentas.TipoPago.idNombreTipoPago INNER JOIN
                         Cuentas.Pago ON Cuentas.TipoPago.idTipoPago = Cuentas.Pago.idTipo INNER JOIN
                         Cuentas.Alumno ON Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno
GROUP BY Cuentas.Alumno.idAlumno, Cuentas.NombreTipoPago.idNombreTipoPago, Cuentas.Pago.total
HAVING        (Cuentas.NombreTipoPago.idNombreTipoPago = 12)
GO
--VISTA FINAL DEL RESUMEN
CREATE VIEW [dbo].[VistaResumen]
AS
SELECT        dbo.VistaResumen1.Grado AS GRADO, dbo.VistaResumen1.nombres AS NOMBRES, dbo.VistaResumen1.apellidos AS APELLIDOS, dbo.VistaResumen2.MATRICULA, dbo.VistaResumen3.[BOLSA ESCOLAR], 
                         dbo.VistaResumen4.SEPTIEMBRE, dbo.VistaResumen5.OCTUBRE, dbo.VistaResumen6.NOVIEMBRE, dbo.VistaResumen7.DICIEMBRE, dbo.VistaResumen8.ENERO, dbo.VistaResumen9.FEBRERO, 
                         dbo.VistaResumen10.MARZO, dbo.VistaResumen11.ABRIL, dbo.VistaResumen12.MAYO, dbo.VistaResumen13.JUNIO
FROM            dbo.VistaResumen1 CROSS JOIN
                         dbo.VistaResumen2 CROSS JOIN
                         dbo.VistaResumen3 CROSS JOIN
                         dbo.VistaResumen10 CROSS JOIN
                         dbo.VistaResumen11 CROSS JOIN
                         dbo.VistaResumen12 CROSS JOIN
                         dbo.VistaResumen13 CROSS JOIN
                         dbo.VistaResumen4 CROSS JOIN
                         dbo.VistaResumen5 CROSS JOIN
                         dbo.VistaResumen6 CROSS JOIN
                         dbo.VistaResumen7 CROSS JOIN
                         dbo.VistaResumen8 CROSS JOIN
                         dbo.VistaResumen9

GO

--VISTA MORA
CREATE VIEW [dbo].[VistaMora]
AS
SELECT        Cuentas.Mora.idMora AS ID, Cuentas.Mora.nombreMora AS RECARGO, Cuentas.Mora.valor AS VALOR
FROM            Cuentas.Mora 
WHERE         (Cuentas.Mora.estado = 1)
GO

--VISTA DESCUENTO
CREATE VIEW [dbo].[VistaDescuento]
AS
SELECT        Cuentas.Descuento.idDescuento AS ID, Cuentas.Descuento.nombreDescuento AS RECARGO, Cuentas.Descuento.valor AS VALOR
FROM            Cuentas.Descuento 
WHERE         (Cuentas.Descuento.estado = 1)
GO