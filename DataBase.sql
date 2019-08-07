/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     6/10/2019 9:04:40 PM                          */
/*==============================================================*/


if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('ARTICULO') and o.name = 'FK_ARTICULO_REFERENCE_PRECIO')
alter table ARTICULO
   drop constraint FK_ARTICULO_REFERENCE_PRECIO
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('BITACORA') and o.name = 'FK_BITACORA_REFERENCE_USER')
alter table BITACORA
   drop constraint FK_BITACORA_REFERENCE_USER
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('BITACORA') and o.name = 'FK_BITACORA_REFERENCE_TIPO_BITACORA')
alter table BITACORA
   drop constraint FK_BITACORA_REFERENCE_TIPO_BITACORA
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('CLIENTE') and o.name = 'FK_CLIENTE_REFERENCE_HABITACION')
alter table CLIENTE
   drop constraint FK_CLIENTE_REFERENCE_HABITACION
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('HABITACION') and o.name = 'FK_HABITACI_REFERENCE_PRECIO')
alter table HABITACION
   drop constraint FK_HABITACI_REFERENCE_PRECIO
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('HABITACION') and o.name = 'FK_HABITACI_REFERENCE_TIPO')
alter table HABITACION
   drop constraint FK_HABITACI_REFERENCE_TIPO
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('RESERVACION') and o.name = 'FK_RESERVAC_REFERENCE_USUARIO')
alter table RESERVACION
   drop constraint FK_RESERVAC_REFERENCE_USUARIO
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('RESERVACION') and o.name = 'FK_RESERVAC_REFERENCE_TIPO')
alter table RESERVACION
   drop constraint FK_RESERVAC_REFERENCE_TIPO
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_REFERENCE_ROL')
alter table USUARIO
   drop constraint FK_USUARIO_REFERENCE_ROL
go

if exists (select 1
from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
where r.fkeyid = object_id('RESERVACION') and o.name = 'FK_RESERVAC_REFERENCE_CLIENTE')
alter table RESERVACION
   drop constraint FK_RESERVAC_REFERENCE_CLIENTE
go



if exists (select 1
from sysobjects
where  id = object_id('ACTIVIDAD')
   and type = 'U')
   drop table ACTIVIDAD
go

if exists (select 1
from sysobjects
where  id = object_id('ARTICULO')
   and type = 'U')
   drop table ARTICULO
go

if exists (select 1
from sysobjects
where  id = object_id('BITACORA')
   and type = 'U')
   drop table BITACORA
go

if exists (select 1
from sysobjects
where  id = object_id('CLIENTE')
   and type = 'U')
   drop table CLIENTE
go

if exists (select 1
from sysobjects
where  id = object_id('CONSECUTIVO')
   and type = 'U')
   drop table CONSECUTIVO
go

if exists (select 1
from sysobjects
where  id = object_id('HABITACION')
   and type = 'U')
   drop table HABITACION
go


if exists (select 1
from sysobjects
where  id = object_id('PRECIO')
   and type = 'U')
   drop table PRECIO
go

if exists (select 1
from sysobjects
where  id = object_id('RESERVACION')
   and type = 'U')
   drop table RESERVACION
go

if exists (select 1
from sysobjects
where  id = object_id('TIPO_BITACORA')
   and type = 'U')
   drop table TIPO_BITACORA
go

if exists (select 1
from sysobjects
where  id = object_id('TIPO_HABITACION')
   and type = 'U')
   drop table TIPO_HABITACION
go


if exists (select 1
from sysobjects
where  id = object_id('ROL')
   and type = 'U')
   drop table ROL
go



if exists (select 1
from sysobjects
where  id = object_id('USUARIO')
   and type = 'U')
   drop table USUARIO
go



if exists (select 1
from sysobjects
where  id = object_id('ESTADO_RESERVACION')
   and type = 'U')
   drop table ESTADO_RESERVACION
go

/*==============================================================*/
/* Table: ACTIVIDAD                                             
==============================================================*/
create table ACTIVIDAD
(
   ID_ACTIVIDAD varchar(100) not null,
   NOMBRE varchar(Max) null,
   DESCRIPCION varchar(Max) null,
   IMG varchar(Max) null,
   constraint PK_ACTIVIDAD primary key (ID_ACTIVIDAD)
)
go

/*==============================================================*/
/* Table: Articulo                                             
==============================================================*/
create table ARTICULO
(
   ID_ARTICULO int not null,
   DESCRIPCION_ varchar(Max) not null,
   ID_PRECIO varchar(100) not null,
   IMG Varchar(Max) null,
   constraint PK_ARTICULO primary key (ID_ARTICULO)
)
go
/*==============================================================*/
/* Table: Bitacora                                             
==============================================================*/
create table BITACORA
(
   ID_BITACORA varchar(100) not null,
   ID_USUARIO varchar(100) not null,
   FECHA smalldatetime not null,
   CODIGO int IDENTITY(1,1) not null,
   TIPO int not null,
   Descripcion varchar(Max) not null,
   Registro_en_detalle varchar(MAX) not null,
   constraint PK_BITACORA primary key (ID_BITACORA)
)
go
/*==============================================================*/
/* Table: CLIENTE                                             
==============================================================*/
create table CLIENTE
(
   ID_CLIENTE int IDENTITY(1,1) not null,
   NOMBRE varchar(Max) null,
   ACTIVO bit not null,
   ID_HABITACION varchar(100) null,
   constraint PK_Cliente primary key (ID_CLIENTE)
)
go
/*==============================================================*/
/* Table: Consecutivo                                             
==============================================================*/
create table CONSECUTIVO
(
   ID_CONSECUTIVOS int not null,
   NOMBRE varchar(Max) null,
   VALOR int not null,
   TIENE_PREFIJO bit not null,
   PREFIJO varchar(Max) null,
   POSEE_RANGO bit not null,
   RANGO_INICIAL int null,
   RANGO_FINAL int null,
   constraint PK_CONSECUTIVO primary key (ID_CONSECUTIVOS)
)
go

/*==============================================================*/
/* Table: Estado reservacion                                             
==============================================================*/
create table ESTADO_RESERVACION
(
   ID_ESTADO int not null,
   NOMBRE varchar(Max) not null,
   constraint PK_ESTADO_RESERVACION primary key (ID_ESTADO)
)
go



/*==============================================================*/
/* Table: Habitacion                                             
==============================================================*/
create table HABITACION
(
   ID_HABITACION varchar(100) not null,
   NUMERO int not null,
   NOMBRE varchar(Max) not null,
   DESCRIPCION varchar(max) not null,
   FOTO varchar(max) not null,
   TIPO_HABITACION int not null,
   ID_PRECIO varchar(100) not null,
   constraint PK_HABITACION primary key (ID_HABITACION)
)
go


/*==============================================================*/
/* Table: Precio                                             
==============================================================*/
create table PRECIO
(
   ID_PRECIO varchar(100) not null,
   TIPO_PRECIO varchar(Max) not null,
   PRECIO int not null,
   constraint PK_PRECIO primary key (ID_PRECIO)
)
go



/*==============================================================*/
/* Table: Reservacion                                             
==============================================================*/
create table RESERVACION
(
   ID_RESERVACION varchar(100) not null,
   ID_CLIENTE int not null,
   FECHA_ENTRADA date not null,
   FECHA_SALIDA date not null,
   TIPO_HABITACION int not null,
   ESTADO_RESERVACION int not null

      constraint PK_RESERVACION primary key (ID_RESERVACION)
)
go

/*==============================================================*/
/* Table: TIPO BITACORA                                           
==============================================================*/
create table TIPO_BITACORA
(
   ID_TIPO_BITACORA int not null,
   NOMBRE varchar(100) not null,

   constraint PK_TIPO_BITACORA primary key (ID_TIPO_BITACORA)
)
go

/*==============================================================*/
/* Table: TIPO HABITACION                                            
==============================================================*/
create table TIPO_HABITACION
(
   ID_TIPO_HABITACION int IDENTITY(1,1) not null,
   NOMBRE varchar(100) not null,
   DESCRIPCION varchar(max) not null

      constraint PK_TIPO_HABITACION primary key (ID_TIPO_HABITACION)
)
go



/*==============================================================*/
/* Table: Rol                                             
==============================================================*/
create table ROL
(
   ID_ROL int not null,
   NOMBRE varchar(Max) null,
   constraint PK_ROL primary key (ID_ROL)
)
go



/*==============================================================*/
/* Table: Usuario                                             
==============================================================*/
create table USUARIO
(
   ID_USUARIO varchar(100) not null,
   NOMBRE varchar(Max) not null,
   APELLIDO1 varchar(Max) not null,
   APELLIDO2 varchar(Max) not null,
   CORREO varchar(Max) not null,
   TELEFONO int not null,
   PASSWORD varchar(Max) not null,
   USER_NAME varchar(Max) not null,
   ID_ROL int null,
   constraint PK_USUARIO primary key (ID_USUARIO)


)
go



/*==============================================================*/
/* Table: Foreign Keys                                             
==============================================================*/

alter table ARTICULO
   add constraint FK_ARTICULO_REFERENCE_PRECIO foreign key (ID_PRECIO)
      references PRECIO (ID_PRECIO)
go

alter table BITACORA
    add CONSTRAINT FK_BITACORA_REFERENCE_USER FOREIGN key (ID_USUARIO)
    references USUARIO (ID_USUARIO)
go

alter table BITACORA
    add CONSTRAINT FK_BITACORA_REFERENCE_TIPO_BITACORA FOREIGN key (TIPO)
    references TIPO_BITACORA (ID_TIPO_BITACORA)
go

alter table CLIENTE
    add CONSTRAINT FK_CLIENTE_REFERENCE_HABITACION FOREIGN key (ID_HABITACION)
    references HABITACION (ID_HABITACION)
go


alter table HABITACION
   add constraint FK_HABITACI_REFERENCE_PRECIO foreign key (ID_PRECIO)
      references PRECIO (ID_PRECIO)
go

alter table HABITACION
   add constraint FK_HABITACI_REFERENCE_TIPO foreign key (TIPO_HABITACION)
      references TIPO_HABITACION (ID_TIPO_HABITACION)
go


alter table RESERVACION
   add constraint FK_RESERVAC_REFERENCE_CLIENTE foreign key (ID_CLIENTE)
      references CLIENTE (ID_CLIENTE)
go

alter table RESERVACION
   add constraint FK_RESERVAC_REFERENCE_ESTADO_RESERVACION foreign key (ESTADO_RESERVACION)
      references ESTADO_RESERVACION (ID_ESTADO)
go

alter table RESERVACION
   add constraint FK_RESERVAC_REFERENCE_TIPO foreign key (TIPO_HABITACION)
      references TIPO_HABITACION (ID_TIPO_HABITACION)
go


alter table USUARIO
   add constraint FK_USUARIO_REFERENCE_ROL foreign key (ID_ROL)
      references ROL (ID_ROL)
go


/*==============================================================*/
/* Table: INSERTS                                           
==============================================================*/
/* Table: Roles*/

INSERT INTO ROL
   (ID_ROL, NOMBRE)
VALUES(01, 'Administrador');
INSERT INTO ROL
   (ID_ROL, NOMBRE)
VALUES(02, 'Seguridad');
INSERT INTO ROL
   (ID_ROL, NOMBRE)
VALUES(03, 'Consecutivo');
INSERT INTO ROL
   (ID_ROL, NOMBRE)
VALUES(04, 'Mantenimiento');
INSERT INTO ROL
   (ID_ROL, NOMBRE)
VALUES(05, 'Consulta');

/* Table: Consecutivos*/
INSERT INTO CONSECUTIVO
   (ID_CONSECUTIVOS, NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL)
VALUES(01, 'Habitacion', 100, 1, 'HAB', 1, 100, 500);
INSERT INTO CONSECUTIVO
   (ID_CONSECUTIVOS, NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL)
VALUES(02, 'Actividad', 100, 1, 'ACT', 1, 100, 1000);
INSERT INTO CONSECUTIVO
   (ID_CONSECUTIVOS, NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL)
VALUES(03, 'Precio', 100, 1, 'PRC', 1, 100, 1000);
INSERT INTO CONSECUTIVO
   (ID_CONSECUTIVOS, NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL)
VALUES(04, 'Reservacion', 100, 1, 'RSV', 1, 100, 500);
INSERT INTO CONSECUTIVO
   (ID_CONSECUTIVOS, NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL)
VALUES(05, 'Cliente', 100, 1, 'CLN', 1, 100, 500);
INSERT INTO CONSECUTIVO
   (ID_CONSECUTIVOS, NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL)
VALUES(06, 'Bitacora', 100, 1, 'BTN', 1, 100, 500);
INSERT INTO CONSECUTIVO
   (ID_CONSECUTIVOS, NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL)
VALUES(07, 'Usuario', 100, 0, '', 0, 100, 500);

/* Table: Tipo Habitacion*/
INSERT INTO TIPO_HABITACION
   (NOMBRE,DESCRIPCION)
VALUES('Normal', 'Este tipo de habitación, cuenta con dos camas matrimoniales, un baño, dos almarios grandes, teléfono, microondas, coffee maker, televisión');
INSERT INTO TIPO_HABITACION
   (NOMBRE,DESCRIPCION)
VALUES('Deluxe', 'La habitación cuenta con tres salas, dos de ellas son cuartos con 2 camas matrimoniales, un almario grande, baño en cada cuarto, la tercera sala, es una de estar, donde se encuentra un desayunador, nevera grande, televisión, teléfono, microondas, coffee maker, además de una terraza');
INSERT INTO TIPO_HABITACION
   (NOMBRE,DESCRIPCION)
VALUES('Condominio', 'La habitación de este tipo contiene la misma descripción que la Deluxe, lo único diferente es, que cuenta con un jardín trasero donde los clientes pueden encontrar parrilla, lavadora y yacusi');
/* Table: Tipo Bitacora*/
INSERT INTO TIPO_BITACORA
   (ID_TIPO_BITACORA , NOMBRE)
VALUES(01, 'Agregar');
INSERT INTO TIPO_BITACORA
   (ID_TIPO_BITACORA , NOMBRE)
VALUES(02, 'Modificar');
INSERT INTO TIPO_BITACORA
   (ID_TIPO_BITACORA , NOMBRE)
VALUES(03, 'Eliminar');
/* Table: Estado Reservacion*/
INSERT INTO ESTADO_RESERVACION
   (ID_ESTADO , NOMBRE)
VALUES(01, 'Reservacion Paga');
INSERT INTO ESTADO_RESERVACION
   (ID_ESTADO , NOMBRE)
VALUES(02, 'Reservacion Sin Paga');

/* Table: USER*/
INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(01, 'Juanito', 'Pacheco', 'Mora', 'admin@hotelmandiola.com', 22222222, '123', 'admin', 01);
 GO

INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(02, 'Pedro', 'Pacheco', 'Mora', 'seguridad@hotelmandiola.com', 22222222, '123', 'seguridad', 02);
 GO

INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(03, 'Jose', 'Gomez', 'Ramirez', 'consecutivo@hotelmandiola.com', 22222222, '123', 'consecutivo', 03);
 GO

INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(04, 'Nidia', 'Agapito', 'Samanta', 'cantenimiento@hotelmandiola.com', 22222222, '123', 'mantenimiento', 04);
 GO

INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(05, 'Laurita', 'Ruperta', 'Luisita', 'consulta@hotelmandiola.com', 22222222, '123', 'consulta', 05);
 GO

/* Table: Precio*/


/* Table: Habitacion*/



/*==============================================================*/
/* Table: Stored Procedures TEST                                             
==============================================================*/

CREATE OR ALTER PROCEDURE InsertBitacora
   (
   @ID_Usuario varchar(200),
   @Fecha smalldatetime,
   @Tipo int,
   @Descripcion varchar(200),
   @Registro_en_detalle varchar(200)
)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Bitacora'

INSERT INTO [dbo].[BITACORA]
   ([ID_BITACORA],[ID_USUARIO],[Fecha],[Tipo],[Descripcion],[Registro_en_detalle])
VALUES
   (@ID, @ID_Usuario, @Fecha, @Tipo, @Descripcion, @Registro_en_detalle)

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Bitacora'
    GO

CREATE OR ALTER PROCEDURE InsertActividadTEST
   (
   @Nombre varchar(200),
   @Descripcion varchar(200),
   @Img varchar(max),
   @LOG_UserID varchar(200),
   @LOG_fecha smalldatetime,
   @LOG_Tipo int,
   @LOG_Desc varchar(200)
)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Actividad'

INSERT INTO [dbo].[ACTIVIDAD]
   ([ID_ACTIVIDAD],[NOMBRE],[DESCRIPCION],[IMG])
VALUES
   (@ID, @Nombre, @Descripcion, @Img)

Declare @LOG_detalle VARCHAR(200) = ('Codigo:' + @ID + '| Nombre: ' + @Nombre + ' | Descripcion: ' + @Descripcion + '| FOTO: '+ @Img)

EXEC InsertBitacora @LOG_UserID,@LOG_fecha,@LOG_Tipo,@LOG_Desc, @LOG_Detalle

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Actividad'
    GO


CREATE OR ALTER PROCEDURE InsertHabitacionTEST
   (
   @Numero int,
   @Nombre varchar(200),
   @Tipo_Habitacion int,
   @ID_Precio varchar(100),
   @Descripcion varchar(250),
   @Foto varchar(250),
   @LOG_UserID varchar(200),
   @LOG_fecha smalldatetime,
   @LOG_Tipo int,
   @LOG_Desc varchar(200)

)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                    CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Habitacion'

INSERT INTO [dbo].[HABITACION]
   ([ID_HABITACION],[NUMERO],[NOMBRE],[DESCRIPCION],[FOTO],[TIPO_HABITACION],[ID_PRECIO])
VALUES
   (@ID, @Numero, @Nombre, @descripcion, @foto, @Tipo_Habitacion, @ID_Precio)

Declare @LOG_detalle VARCHAR(200) = ('Codigo:' + @ID + '| Numero: ' + CAST(@Numero AS VARCHAR(200)) + ' | Nombre: ' + @Nombre + '| Tipo Habitacion: ' + CAST(@Tipo_Habitacion AS VARCHAR(200)) + '| Desc: ' + @Descripcion +' | Foto: ' + @Foto)

EXEC InsertBitacora @LOG_UserID,@LOG_fecha,@LOG_Tipo,@LOG_Desc, @LOG_detalle

UPDATE [dbo].[CONSECUTIVO]
            SET Valor = Valor + 1
            WHERE Nombre ='Habitacion'
            
        GO

CREATE OR ALTER PROCEDURE InsertPreciosTEST
   (
   @Tipo_Precio varchar(200),
   @Precio int,
   @LOG_UserID varchar(200),
   @LOG_fecha smalldatetime,
   @LOG_Tipo int,
   @LOG_Desc varchar(200)

)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Precio'

INSERT INTO [dbo].[PRECIO]
   ([ID_PRECIO],[TIPO_PRECIO],[PRECIO])
VALUES
   (@ID, @Tipo_Precio, @Precio)

Declare @LOG_detalle VARCHAR(200) = ('Codigo:' + @ID + '| Tipo_Precio: ' + @Tipo_Precio + ' | Precio: ' + CAST(@Precio AS VARCHAR(200)))

EXEC InsertBitacora @LOG_UserID,@LOG_fecha,@LOG_Tipo,@LOG_Desc, @LOG_detalle

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Precio'
    GO

CREATE OR ALTER PROCEDURE InsertReservacionTEST
   (
   @ID_Cliente int,
   @Fecha_Entrada date,
   @Fecha_Salida date,
   @Tipo_Habitacion int,
   @Estado int,
   @LOG_UserID varchar(200),
   @LOG_fecha smalldatetime,
   @LOG_Tipo int,
   @LOG_Desc varchar(200)
)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Reservacion'

INSERT INTO [dbo].[RESERVACION]
   ([ID_RESERVACION],[ID_CLIENTE],[FECHA_ENTRADA],[FECHA_SALIDA],[TIPO_HABITACION],[ESTADO_RESERVACION])
VALUES
   (@ID, @ID_Cliente, @Fecha_Entrada, @Fecha_Salida, @Tipo_Habitacion, @Estado)

Declare @LOG_detalle VARCHAR(200) = ('Codigo:' + @ID + '| Cliente: ' + CAST(@ID_Cliente AS VARCHAR(200)) + ' | Fecha Entrada: ' + CAST(@Fecha_Entrada AS VARCHAR(200)) +'| Fecha Salida: '+ CAST(@Fecha_Salida AS VARCHAR(200)) + '| Estado: ' + CAST(@Estado AS VARCHAR(200)))

EXEC InsertBitacora @LOG_UserID,@LOG_fecha,@LOG_Tipo,@LOG_Desc, @LOG_detalle

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Reservacion'
        
    GO






/*==============================================================*/
/* Table: Stored Procedures                                             
==============================================================*/




CREATE OR ALTER PROCEDURE InsertHabitacion
   (
   @Numero int,
   @Nombre varchar(200),
   @Tipo_Habitacion int,
   @ID_Precio varchar(100),
   @Descripcion varchar(250),
   @Foto varchar(250)

)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                    CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Habitacion'

INSERT INTO [dbo].[HABITACION]
   ([ID_HABITACION],[NUMERO],[NOMBRE],[DESCRIPCION],[FOTO],[TIPO_HABITACION],[ID_PRECIO])
VALUES
   (@ID, @Numero, @Nombre, @descripcion, @foto, @Tipo_Habitacion, @ID_Precio)


UPDATE [dbo].[CONSECUTIVO]
            SET Valor = Valor + 1
            WHERE Nombre ='Habitacion'
            
        GO



CREATE OR ALTER PROCEDURE InsertReservacion
   (
   @ID_Cliente int,
   @Fecha_Entrada date,
   @Fecha_Salida date,
   @Tipo_Habitacion int,
   @Estado int
)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Reservacion'

INSERT INTO [dbo].[RESERVACION]
   ([ID_RESERVACION],[ID_CLIENTE],[FECHA_ENTRADA],[FECHA_SALIDA],[TIPO_HABITACION],[ESTADO_RESERVACION])
VALUES
   (@ID, @ID_Cliente, @Fecha_Entrada, @Fecha_Salida, @Tipo_Habitacion, @Estado)

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Reservacion'
        
    GO

CREATE OR ALTER PROCEDURE InsertActividad
   (
   @Nombre varchar(200),
   @Descripcion varchar(200),
   @Img varchar(max)
)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Actividad'

INSERT INTO [dbo].[ACTIVIDAD]
   ([ID_ACTIVIDAD],[NOMBRE],[DESCRIPCION],[IMG])
VALUES
   (@ID, @Nombre, @Descripcion, @Img)

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Actividad'
    GO

CREATE OR ALTER PROCEDURE InsertPrecios
   (
   @Tipo_Precio varchar(200),
   @Precio int

)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Precio'

INSERT INTO [dbo].[PRECIO]
   ([ID_PRECIO],[TIPO_PRECIO],[PRECIO])
VALUES
   (@ID, @Tipo_Precio, @Precio)

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Precio'
    GO

CREATE OR ALTER PROCEDURE InsertUsuarios
   (
   @nombre varchar(200),
   @apellido1 varchar(200),
   @apellido2 varchar(200),
   @correo varchar(200),
   @telefono int,
   @password varchar(200),
   @User_name varchar(200),
   @Id_rol int

)
AS
DECLARE @ID varchar(200)

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Usuario'

INSERT INTO [dbo].[USUARIO]
   ([ID_USUARIO],[NOMBRE],[APELLIDO1],[APELLIDO2],[CORREO],[TELEFONO],[PASSWORD],[USER_NAME],[ID_ROL])
VALUES
   (@ID, @nombre, @apellido1, @apellido2, @correo, @telefono, @password, @User_name, @Id_rol)

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Usuario'
    GO

CREATE OR ALTER PROCEDURE ValidateUser
   (
   @Username NVARCHAR(20),
   @Password NVARCHAR(20)
)
AS
BEGIN
   SET NOCOUNT ON;
   DECLARE @UserId VARCHAR(max)

   SELECT @UserId = ID_USUARIO
   FROM [dbo].[USUARIO]
   WHERE USER_NAME = @Username AND [Password] = @Password

   IF @UserId IS NOT NULL
         BEGIN
      SELECT @UserId [UserId]
   END
         ELSE
         BEGIN
      SELECT '0'
   END
END