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
   DESCRIPCION varchar(200) not null,
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
   DISPONIBLE bit null,
   constraint PK_HABITACION primary key (ID_HABITACION)
)
go

/*==============================================================*/
/* Table: Habitaciones En Reservacion                                             
==============================================================*/
CREATE TABLE HabitacionesEnReservacion
(
   ID_HabEnReserv int IDENTITY(1,1) not null,
   ID_HABITACION varchar (100) not null,
   ID_RESERVACION varchar(100) not null,
   constraint PK_HABITACION primary key (ID_HabEnReserv)
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

alter table HabitacionesEnReservacion
   add CONSTRAINT FK_HABITENRESERV_REFERENCE_HABITACION FOREIGN KEY (ID_HABITACION)
   references HABITACION(ID_HABITACION)
go

alter table HabitacionesEnReservacion
   add CONSTRAINT FK_HABITENRESERV_REFERENCE_RESERVACION FOREIGN KEY (ID_RESERVACION)
   references RESERVACION(ID_RESERVACION)
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
INSERT INTO CONSECUTIVO
   (ID_CONSECUTIVOS, NOMBRE,VALOR,TIENE_PREFIJO,PREFIJO,POSEE_RANGO,RANGO_INICIAL,RANGO_FINAL)
VALUES(08, 'Articulo', 100, 0, '', 0, 100, 500);

/* Table: Tipo Habitacion*/
INSERT INTO TIPO_HABITACION
   (NOMBRE,DESCRIPCION)
VALUES('Jla0izLm+VS6/DaDUE87QQ==', 'MY3LB4cRBzKTT2CUSAUDK49NWk4giX/9Vqszk/Vzmo6sHkpjELxTLCqtdcXNDMEQcFFzKlD5sDNJuaWwgifAuSXCnxr3hTS5Mj7cw8jlQxcdvI2I/I3gOH9F8nJIuTlnXI7auQmOmGuCggwvAhyUAHErai5eXC/cgay+2ryIDPl+/4blgQ+yJUoe5YWFjrZLlU8qU8taL6zISmXSoHnspNNpAoA7tZkFpq7EIxSY8J7Ctoe21TjM8Oa2MWc6f7z2ODBrLtAFT1Bsnod/uhUFU1eOqc4NIVKfDwmhRsr3WuNGtBjclKfug3DJRTSqSyOU4TxrTj9rDTocDJMbEtwIzZrZzw1Gg8t0y5CiRiRg955EJ2a2GMxOJQ==');
INSERT INTO TIPO_HABITACION
   (NOMBRE,DESCRIPCION)
VALUES('8PDQWpA7O65DpxNEJShYUg==', 'Uy59aiizgznbLhdM1x8twTGK6fsv4AuQBqS9SNjhoqq98hKaVjotbgpE8aE5/Knbte8KQpLOO0bhU4UjNi8yyAu58L4h0bdtADrrr3HQ07Bx9yGos9Hnl5KFg3shNu/TnodJwK5aDSs6IhlBGkBWs91xuSCXAoIwfHTLwjkkQa5wv4WLdw3Zzj19EdeRwWNNstFQ/ICNJysVP5eaFQnlVJZ4XwN/BVyuPuOnFSYizC1Tu/tFr/4EHSa/eree1pzjPfeqtcy7dKYIyHkniIRyoKMxuBXgDHAwolFcuWM53tWswy74zkCyS25o0aydrt8qEGMKDEGVjjwT6BhREpX0gyO3jAAKy4KwE+D/SfBDeQlYH64uwai4wMi5qz5dy4kbmyZvdzaAERM6p5MNKNXWPQ5qT2XtcOCM/nSI1ioY9nG8pZBxJ8kui5+mYuYf16rKkiuxSHZddAsSzEol0XVgIhS5cVaHIH2Sb4YhJ/IcVfW1MzVaE959ykWpWJ3a4FSI1R0s0AdHXrsII//21zrTO6s9O7EbnVYaPlxTByIgx6c58CCfr4CPfePtPmG2VT14BwfgVLJu26+SawPl79wzuwZ6DJBBIzZq/3xQi6SVfKZYDvxz5ywhpTQHKb5/bQyo0cBMZ0OkTpp8qYlKzy7dQNjsmthuWKsxqW5F6o7uUFfpXFCYT2OyOf2lHvdoXUWdDWqecxfa8183vkH6p8AAI++suJ6/5LieD3ampvb91HNfA3HMz3exnA==');
INSERT INTO TIPO_HABITACION
   (NOMBRE,DESCRIPCION)
VALUES('pXaRYnvoGDI9iZsBzUQLS165doabFhb7', 'Uy59aiizgznbLhdM1x8twTGK6fsv4AuQ4IFXzD3sPfmx70+i0Y4sHnpVc/3xmZdjLht7/6JszkyHH6LT4Rek8+q7RGDuYNS83SAOS937IUDQQ5qEUA9qH67cyNIzNWXTST+umbtOaaGu55969yFTVMhc3bvZWq7t/o1t3aP7e1P5AB6X4L3k/m5hr0h7kHa/LFcOOPo/oSZI98ymwDRUDVw1ExQ7ooSHFkoywMtMrJl9fVH4CJ16QmzmNlH8NODW65ND6sm3qCTJEZNVqdExY+x1/2k96qxzGLjTaQi9cfO4n70Zwspy9ZOBZwMkZFF+sWMZaCQIs92ZMdsjD2Gd6YSnys85W2Wpq7QmpeZKRwt5Cf/iguhXBbd9GIWo8EIXZvqlRpDbIKF1+NjG2r4pfkZsboLWkQb9bJVfFPjDKe/skHNelzGpsloYb0Cae2RcK03BE2WPlKwI1Lo3NwOElaDooyCyLFztSO+KssPc1crfzYf8pIeHmWyErUzoX0TD');

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
VALUES(01, 'Y5FrHuiJOeErdCkpPswXQg==', 'VgIrRi6JlvRbEMoR4OFjlw==', 'WZedEVww1hvcXr/P0KzRFw==', 'ISItMpbtDt0ywpulp9JmSZEFvbdoLI4zfcxKYUCq2iM=', 22222222, 'nq41fV2izSIbZijx4QojzA==', 'lK8zoyxCYvGqfjHlaxngBQ==', 01);
 GO

INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(02, 'oHNO3thWk+7el20CVXbVVw==', 'VgIrRi6JlvRbEMoR4OFjlw==', 'WZedEVww1hvcXr/P0KzRFw==', 'FxlINjFKRiDHOg7isJzxxI02t9pI1yxikUMZRuvGaqc=', 22222222, 'nq41fV2izSIbZijx4QojzA==', 'ikJNAMkyczGDsuUQmAL+Yg==', 02);
 GO

INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(03, 'XxVx+SvMm9N+CFcazfxQzg==', 'XxVx+SvMm9N+CFcazfxQzg==', 'kPmdfW8iTfXiVubEnqc89w==', 'TKlqo1kKZoyFrYyrx9x+3HUdVA6J6ZQ9G8VS2YVnUzQ=', 22222222, 'nq41fV2izSIbZijx4QojzA==', 'MhKjc4KM1KUBXpCe8l6KCg==', 03);
 GO

INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(04, 'Q08xU0kyV4jAL9WAYBZVLw==', 'lRL/ZH945+LM3tjTL1frnQ==', 'B8UiashgUeB2EoUOSW6ebA==', 'hrCjlXXyDHA07IKzSz9qdjry6zpr94vcl5fwGb+2eJI=', 22222222, 'nq41fV2izSIbZijx4QojzA==', '0hpu373H3ybfkdZld785SQ==', 04);
 GO

INSERT INTO USUARIO
   (ID_USUARIO, NOMBRE,APELLIDO1,APELLIDO2,CORREO,TELEFONO,PASSWORD,USER_NAME,ID_ROL)
VALUES(05, 'pozdVHfpUojpBB5ahU19kg==', '4jINuBjvWEiADoXOrKPmOw==', 'mwZCmnWbMY74uLZnRqtfig==', 'NRXmjveQnOdneonnyoumYWmQUnjncV2uEzCyfw2+q90=', 22222222, 'nq41fV2izSIbZijx4QojzA==', '5I27yKsLRWQoohgE4jmrew==', 05);
 GO

/* Table: Precio*/


/* Table: Habitacion*/



/*==============================================================*/
/* Table: Stored Procedures TEST                                             
==============================================================*/

CREATE OR ALTER PROCEDURE InsertBitacora
   (
   @ID_Usuario varchar(200),
   @Tipo int,
   @Descripcion varchar(200),
   @Registro_en_detalle varchar(200),
   @codigo varchar(200)
)
AS
DECLARE @ID varchar(200)
DECLARE @Fecha SMALLDATETIME

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Bitacora'

SELECT @Fecha = CAST(GETDATE() AS SMALLDATETIME)

INSERT INTO [dbo].[BITACORA]
   ([ID_BITACORA],[ID_USUARIO],[Fecha],[Codigo],[Tipo],[Descripcion],[Registro_en_detalle])
VALUES
   (@ID, @ID_Usuario, @Fecha, @Codigo, @Tipo, @Descripcion, @Registro_en_detalle)

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Bitacora'
    GO

CREATE OR ALTER PROCEDURE InsertActividad
   (
   @Nombre varchar(200),
   @Descripcion varchar(200),
   @Img varchar(max),
   @LOG_UserID varchar(200),
   @LOG_Tipo int,
   @LOG_Desc varchar(200),
   @LOG_Detalle varchar(200)
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


EXEC InsertBitacora @LOG_UserID, @LOG_Tipo, @LOG_Desc, @LOG_Detalle, @ID

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Actividad'

SELECT *
FROM [dbo].[ACTIVIDAD]
WHERE ID_ACTIVIDAD = @ID

GO



CREATE OR ALTER PROCEDURE InsertHabitacion
   (
   @Numero int,
   @Nombre varchar(200),
   @Tipo_Habitacion int,
   @ID_Precio varchar(100),
   @Descripcion varchar(250),
   @Foto varchar(250),
   @Disponible bit,
   @LOG_UserID varchar(200),
   @LOG_Tipo int,
   @LOG_Desc varchar(200),
   @LOG_Detalle varchar(200)

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


EXEC InsertBitacora @LOG_UserID, @LOG_Tipo, @LOG_Desc, @LOG_detalle, @ID

UPDATE [dbo].[CONSECUTIVO]
            SET Valor = Valor + 1
            WHERE Nombre ='Habitacion'
            
GO




CREATE OR ALTER PROCEDURE InsertPrecios
   (
   @Tipo_Precio varchar(200),
   @Precio int,
   @LOG_UserID varchar(200),
   @LOG_Tipo int,
   @LOG_Desc varchar(200),
   @LOG_Detalle varchar(200)

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


EXEC InsertBitacora @LOG_UserID, @LOG_Tipo, @LOG_Desc, @LOG_detalle, @ID

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Precio'
    GO

CREATE OR ALTER PROCEDURE InsertReservacion
   (
   @ID_Cliente int,
   @Fecha_Entrada date,
   @Fecha_Salida date,
   @Tipo_Habitacion int,
   @Estado int,
   @LOG_UserID varchar(200),
   @LOG_Tipo int,
   @LOG_Desc varchar(200),
   @LOG_Detalle varchar(200)
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


EXEC InsertBitacora @LOG_UserID, @LOG_Tipo, @LOG_Desc, @LOG_detalle

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Reservacion'
        
GO


-------------------------------------------------------

-------------------------------------------------------
CREATE OR ALTER PROCEDURE EncodeString
(
   @EncodeIn VARCHAR(200),
   @EncodeOut VARCHAR(200) output
)
AS
BEGIN

   SELECT @EncodeOut = 
      CAST(N'' AS XML).value(
            'xs:base64Binary(xs:hexBinary(sql:column("bin")))'
         , 'VARCHAR(MAX)'
      )
   FROM (
      SELECT CAST(@EncodeIn AS VARBINARY(MAX)) AS bin
   ) AS bin_sql_server_temp;

END
GO
-------------------------------------------------------
CREATE OR ALTER PROCEDURE DecodeString
(
   @DecodeIn VARCHAR(200),
   @DecodeOut VARCHAR(200) output
)
AS
BEGIN

   SELECT @DecodeOut = 
   CAST(
      CAST(N'' AS XML).value(
         'xs:base64Binary(sql:column("bin"))'
         , 'VARBINARY(MAX)'
      ) 
      AS VARCHAR(MAX)
   ) 
   FROM (
      SELECT CAST(@DecodeIn AS VARCHAR(MAX)) AS bin
   ) AS bin_sql_server_temp;

END
GO
-------------------------------------------------------
CREATE OR ALTER PROCEDURE ValidateUser
(
   @Username NVARCHAR(200),
   @Password NVARCHAR(200)
)
AS
BEGIN
   SET NOCOUNT ON;
   DECLARE 
      @UserId VARCHAR(MAX),
      @UsernameE VARCHAR(200),
      @PasswordE VARCHAR(200)

   EXEC EncodeString @Username, @UsernameE output
   EXEC EncodeString @Password, @PasswordE output

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
GO
-------------------------------------------------------
CREATE OR ALTER PROCEDURE UsernameAvailable
(
   @Username NVARCHAR(200)
)
AS
BEGIN
   SET NOCOUNT ON;
   DECLARE 
      @UserId VARCHAR(MAX)

   SELECT @UserId = ID_USUARIO
   FROM [dbo].[USUARIO]
   WHERE USER_NAME = @Username

   IF @UserId IS NOT NULL
   BEGIN
      SELECT 'false'
   END
   ELSE
   BEGIN
      SELECT 'true'
   END
END
GO
-------------------------------------------------------
CREATE OR ALTER PROCEDURE InsertUsuarioE
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
DECLARE 
   @ID varchar(200), 
   @nombreE varchar(200),
   @apellido1E varchar(200),
   @apellido2E varchar(200),
   @correoE varchar(200),
   @passwordE varchar(200),
   @User_nameE varchar(200)

EXEC EncodeString @nombre, @nombreE output
EXEC EncodeString @apellido1, @apellido1E output
EXEC EncodeString @apellido2, @apellido2E output
EXEC EncodeString @correo, @correoE output
EXEC EncodeString @password, @passwordE output
EXEC EncodeString @User_name, @User_nameE output

SELECT @ID = CAST(ISNULL([Prefijo],'') AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
FROM [dbo].[CONSECUTIVO]
WHERE Nombre = 'Usuario'

INSERT INTO [dbo].[USUARIO]
   ([ID_USUARIO],[NOMBRE],[APELLIDO1],[APELLIDO2],[CORREO],[TELEFONO],[PASSWORD],[USER_NAME],[ID_ROL])
VALUES
   (@ID, @nombreE, @apellido1E, @apellido2E, @correoE, @telefono, @passwordE, @User_nameE, @Id_rol)

UPDATE [dbo].[CONSECUTIVO]
        SET Valor = Valor + 1
        WHERE Nombre ='Usuario'

SELECT *
FROM [dbo].[USUARIO]
WHERE ID_USUARIO = @ID

GO
-------------------------------------------------------
CREATE OR ALTER PROCEDURE InsertReservacionAPI
   (
   @ID_Cliente int,
   @Fecha_Entrada date,
   @Fecha_Salida date,
   @Tipo_Habitacion int,
   @Estado int,
   @ID_Habitacion varchar(100)
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

SELECT *
FROM [dbo].[RESERVACION]
WHERE ID_RESERVACION = @ID

GO
---------------------------------------------------------
CREATE OR ALTER PROCEDURE EditReservacionAPI
(
   @ID_Reservacion varchar(200),
   @Fecha_Entrada date,
   @Fecha_Salida date,
   @Tipo_Habitacion int,
   @Estado int
)
AS
UPDATE [dbo].[RESERVACION] SET 
      FECHA_ENTRADA = @Fecha_Entrada,
      FECHA_SALIDA = @Fecha_Salida,
      TIPO_HABITACION = @Tipo_Habitacion,
      ESTADO_RESERVACION = @Estado
WHERE ID_RESERVACION = @ID_Reservacion

GO
-------------------------------------------------------
CREATE OR ALTER PROCEDURE DeleteReservacionAPI
(
   @ID_Reservacion varchar(200)
)
AS
DELETE FROM [dbo].[RESERVACION]
WHERE ID_RESERVACION = @ID_Reservacion

GO
-------------------------------------------------------
ALTER   PROCEDURE [dbo].[JoinReservacionHabitacion]
(
   @ID_Reservacion VARCHAR(200)
 
)
AS
BEGIN
	SELECT RESERVACION.ID_RESERVACION,RESERVACION.ID_CLIENTE,RESERVACION.FECHA_ENTRADA,RESERVACION.FECHA_SALIDA, HABITACION.ID_HABITACION
	FROM HabitacionesEnReservacion
	INNER JOIN HABITACION on HabitacionesEnReservacion.ID_HABITACION = HABITACION.ID_HABITACION
	INNER JOIN RESERVACION on HabitacionesEnReservacion.ID_RESERVACION = RESERVACION.ID_RESERVACION
	WHERE RESERVACION.ID_RESERVACION = @ID_Reservacion
  
END


-------------------------------------------------------

-------------------------------------------------------


-------------------------------------------------------
CREATE OR ALTER PROCEDURE GetDisponibles
AS
SELECT NOMBRE,ID_PRECIO,TIPO_HABITACION
FROM [dbo].[HABITACION]
WHERE DISPONIBLE != 0
GO




-- INSERT BASE USERS
EXEC InsertUsuarioE 'Armando', 'Arias', 'Alvarado', 'admin@mandiola.com', 12345678, '1234','admin', 1
EXEC InsertUsuarioE 'Sergio', 'Solera', 'Salas', 'seguridad@mandiola.com', 12345678, '1234','seguridad', 2
EXEC InsertUsuarioE 'Catalina', 'Corella', 'Crespo', 'consecutivo@mandiola.com', 12345678, '1234','consecutivo', 3
EXEC InsertUsuarioE 'Manfred', 'Mora', 'Molina', 'mantenimiento@mandiola.com', 12345678, '1234','mantenimiento', 4
EXEC InsertUsuarioE 'Carmen', 'Carrillos', 'Carranza', 'consulta@mandiola.com', 12345678, '1234','consulta', 5
GO