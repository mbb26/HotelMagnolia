﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelMagnolia.UI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HotelMagnoliaEntities : DbContext
    {
        public HotelMagnoliaEntities()
            : base("name=HotelMagnoliaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTIVIDAD> ACTIVIDADs { get; set; }
        public virtual DbSet<ARTICULO> ARTICULOes { get; set; }
        public virtual DbSet<BITACORA> BITACORAs { get; set; }
        public virtual DbSet<CLIENTE> CLIENTEs { get; set; }
        public virtual DbSet<CONSECUTIVO> CONSECUTIVOes { get; set; }
        public virtual DbSet<ESTADO_RESERVACION> ESTADO_RESERVACION { get; set; }
        public virtual DbSet<PRECIO> PRECIOs { get; set; }
        public virtual DbSet<RESERVACION> RESERVACIONs { get; set; }
        public virtual DbSet<ROL> ROLs { get; set; }
        public virtual DbSet<TIPO_BITACORA> TIPO_BITACORA { get; set; }
        public virtual DbSet<TIPO_HABITACION> TIPO_HABITACION { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
        public virtual DbSet<HABITACION> HABITACIONs { get; set; }
    
        public virtual int InsertActividad(string nombre, string descripcion, string img, string lOG_UserID, Nullable<int> lOG_Tipo, string lOG_Desc, string lOG_Detalle)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imgParameter = img != null ?
                new ObjectParameter("Img", img) :
                new ObjectParameter("Img", typeof(string));
    
            var lOG_UserIDParameter = lOG_UserID != null ?
                new ObjectParameter("LOG_UserID", lOG_UserID) :
                new ObjectParameter("LOG_UserID", typeof(string));
    
            var lOG_TipoParameter = lOG_Tipo.HasValue ?
                new ObjectParameter("LOG_Tipo", lOG_Tipo) :
                new ObjectParameter("LOG_Tipo", typeof(int));
    
            var lOG_DescParameter = lOG_Desc != null ?
                new ObjectParameter("LOG_Desc", lOG_Desc) :
                new ObjectParameter("LOG_Desc", typeof(string));
    
            var lOG_DetalleParameter = lOG_Detalle != null ?
                new ObjectParameter("LOG_Detalle", lOG_Detalle) :
                new ObjectParameter("LOG_Detalle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertActividad", nombreParameter, descripcionParameter, imgParameter, lOG_UserIDParameter, lOG_TipoParameter, lOG_DescParameter, lOG_DetalleParameter);
        }
    
        public virtual int InsertBitacora(string iD_Usuario, Nullable<int> tipo, string descripcion, string registro_en_detalle, string codigo)
        {
            var iD_UsuarioParameter = iD_Usuario != null ?
                new ObjectParameter("ID_Usuario", iD_Usuario) :
                new ObjectParameter("ID_Usuario", typeof(string));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var registro_en_detalleParameter = registro_en_detalle != null ?
                new ObjectParameter("Registro_en_detalle", registro_en_detalle) :
                new ObjectParameter("Registro_en_detalle", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertBitacora", iD_UsuarioParameter, tipoParameter, descripcionParameter, registro_en_detalleParameter, codigoParameter);
        }
    
        public virtual int InsertHabitacion(Nullable<int> numero, string nombre, Nullable<int> tipo_Habitacion, string iD_Precio, string descripcion, string foto, string lOG_UserID, Nullable<int> lOG_Tipo, string lOG_Desc, string lOG_Detalle)
        {
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("Numero", numero) :
                new ObjectParameter("Numero", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var tipo_HabitacionParameter = tipo_Habitacion.HasValue ?
                new ObjectParameter("Tipo_Habitacion", tipo_Habitacion) :
                new ObjectParameter("Tipo_Habitacion", typeof(int));
    
            var iD_PrecioParameter = iD_Precio != null ?
                new ObjectParameter("ID_Precio", iD_Precio) :
                new ObjectParameter("ID_Precio", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var fotoParameter = foto != null ?
                new ObjectParameter("Foto", foto) :
                new ObjectParameter("Foto", typeof(string));
    
            var lOG_UserIDParameter = lOG_UserID != null ?
                new ObjectParameter("LOG_UserID", lOG_UserID) :
                new ObjectParameter("LOG_UserID", typeof(string));
    
            var lOG_TipoParameter = lOG_Tipo.HasValue ?
                new ObjectParameter("LOG_Tipo", lOG_Tipo) :
                new ObjectParameter("LOG_Tipo", typeof(int));
    
            var lOG_DescParameter = lOG_Desc != null ?
                new ObjectParameter("LOG_Desc", lOG_Desc) :
                new ObjectParameter("LOG_Desc", typeof(string));
    
            var lOG_DetalleParameter = lOG_Detalle != null ?
                new ObjectParameter("LOG_Detalle", lOG_Detalle) :
                new ObjectParameter("LOG_Detalle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertHabitacion", numeroParameter, nombreParameter, tipo_HabitacionParameter, iD_PrecioParameter, descripcionParameter, fotoParameter, lOG_UserIDParameter, lOG_TipoParameter, lOG_DescParameter, lOG_DetalleParameter);
        }
    
        public virtual int InsertPrecios(string tipo_Precio, Nullable<int> precio, string lOG_UserID, Nullable<System.DateTime> lOG_fecha, Nullable<int> lOG_Tipo, string lOG_Desc, string lOG_Detalle)
        {
            var tipo_PrecioParameter = tipo_Precio != null ?
                new ObjectParameter("Tipo_Precio", tipo_Precio) :
                new ObjectParameter("Tipo_Precio", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(int));
    
            var lOG_UserIDParameter = lOG_UserID != null ?
                new ObjectParameter("LOG_UserID", lOG_UserID) :
                new ObjectParameter("LOG_UserID", typeof(string));
    
            var lOG_fechaParameter = lOG_fecha.HasValue ?
                new ObjectParameter("LOG_fecha", lOG_fecha) :
                new ObjectParameter("LOG_fecha", typeof(System.DateTime));
    
            var lOG_TipoParameter = lOG_Tipo.HasValue ?
                new ObjectParameter("LOG_Tipo", lOG_Tipo) :
                new ObjectParameter("LOG_Tipo", typeof(int));
    
            var lOG_DescParameter = lOG_Desc != null ?
                new ObjectParameter("LOG_Desc", lOG_Desc) :
                new ObjectParameter("LOG_Desc", typeof(string));
    
            var lOG_DetalleParameter = lOG_Detalle != null ?
                new ObjectParameter("LOG_Detalle", lOG_Detalle) :
                new ObjectParameter("LOG_Detalle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertPrecios", tipo_PrecioParameter, precioParameter, lOG_UserIDParameter, lOG_fechaParameter, lOG_TipoParameter, lOG_DescParameter, lOG_DetalleParameter);
        }
    
        public virtual int InsertReservacion(Nullable<int> iD_Cliente, Nullable<System.DateTime> fecha_Entrada, Nullable<System.DateTime> fecha_Salida, Nullable<int> tipo_Habitacion, Nullable<int> estado, string lOG_UserID, Nullable<System.DateTime> lOG_fecha, Nullable<int> lOG_Tipo, string lOG_Desc, string lOG_Detalle)
        {
            var iD_ClienteParameter = iD_Cliente.HasValue ?
                new ObjectParameter("ID_Cliente", iD_Cliente) :
                new ObjectParameter("ID_Cliente", typeof(int));
    
            var fecha_EntradaParameter = fecha_Entrada.HasValue ?
                new ObjectParameter("Fecha_Entrada", fecha_Entrada) :
                new ObjectParameter("Fecha_Entrada", typeof(System.DateTime));
    
            var fecha_SalidaParameter = fecha_Salida.HasValue ?
                new ObjectParameter("Fecha_Salida", fecha_Salida) :
                new ObjectParameter("Fecha_Salida", typeof(System.DateTime));
    
            var tipo_HabitacionParameter = tipo_Habitacion.HasValue ?
                new ObjectParameter("Tipo_Habitacion", tipo_Habitacion) :
                new ObjectParameter("Tipo_Habitacion", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            var lOG_UserIDParameter = lOG_UserID != null ?
                new ObjectParameter("LOG_UserID", lOG_UserID) :
                new ObjectParameter("LOG_UserID", typeof(string));
    
            var lOG_fechaParameter = lOG_fecha.HasValue ?
                new ObjectParameter("LOG_fecha", lOG_fecha) :
                new ObjectParameter("LOG_fecha", typeof(System.DateTime));
    
            var lOG_TipoParameter = lOG_Tipo.HasValue ?
                new ObjectParameter("LOG_Tipo", lOG_Tipo) :
                new ObjectParameter("LOG_Tipo", typeof(int));
    
            var lOG_DescParameter = lOG_Desc != null ?
                new ObjectParameter("LOG_Desc", lOG_Desc) :
                new ObjectParameter("LOG_Desc", typeof(string));
    
            var lOG_DetalleParameter = lOG_Detalle != null ?
                new ObjectParameter("LOG_Detalle", lOG_Detalle) :
                new ObjectParameter("LOG_Detalle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertReservacion", iD_ClienteParameter, fecha_EntradaParameter, fecha_SalidaParameter, tipo_HabitacionParameter, estadoParameter, lOG_UserIDParameter, lOG_fechaParameter, lOG_TipoParameter, lOG_DescParameter, lOG_DetalleParameter);
        }
    
        public virtual int InsertUsuarios(string nombre, string apellido1, string apellido2, string correo, Nullable<int> telefono, string password, string user_name, Nullable<int> id_rol)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellido1Parameter = apellido1 != null ?
                new ObjectParameter("apellido1", apellido1) :
                new ObjectParameter("apellido1", typeof(string));
    
            var apellido2Parameter = apellido2 != null ?
                new ObjectParameter("apellido2", apellido2) :
                new ObjectParameter("apellido2", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var user_nameParameter = user_name != null ?
                new ObjectParameter("User_name", user_name) :
                new ObjectParameter("User_name", typeof(string));
    
            var id_rolParameter = id_rol.HasValue ?
                new ObjectParameter("Id_rol", id_rol) :
                new ObjectParameter("Id_rol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUsuarios", nombreParameter, apellido1Parameter, apellido2Parameter, correoParameter, telefonoParameter, passwordParameter, user_nameParameter, id_rolParameter);
        }
    
        public virtual ObjectResult<string> ValidateUser(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("ValidateUser", usernameParameter, passwordParameter);
        }
    
        public virtual int DecodeString(string decodeIn, ObjectParameter decodeOut)
        {
            var decodeInParameter = decodeIn != null ?
                new ObjectParameter("DecodeIn", decodeIn) :
                new ObjectParameter("DecodeIn", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DecodeString", decodeInParameter, decodeOut);
        }
    
        public virtual int EncodeString(string encodeIn, ObjectParameter encodeOut)
        {
            var encodeInParameter = encodeIn != null ?
                new ObjectParameter("EncodeIn", encodeIn) :
                new ObjectParameter("EncodeIn", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EncodeString", encodeInParameter, encodeOut);
        }
    
        public virtual ObjectResult<InsertUsuarioE_Result> InsertUsuarioE(string nombre, string apellido1, string apellido2, string correo, Nullable<int> telefono, string password, string user_name, Nullable<int> id_rol)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellido1Parameter = apellido1 != null ?
                new ObjectParameter("apellido1", apellido1) :
                new ObjectParameter("apellido1", typeof(string));
    
            var apellido2Parameter = apellido2 != null ?
                new ObjectParameter("apellido2", apellido2) :
                new ObjectParameter("apellido2", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var user_nameParameter = user_name != null ?
                new ObjectParameter("User_name", user_name) :
                new ObjectParameter("User_name", typeof(string));
    
            var id_rolParameter = id_rol.HasValue ?
                new ObjectParameter("Id_rol", id_rol) :
                new ObjectParameter("Id_rol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InsertUsuarioE_Result>("InsertUsuarioE", nombreParameter, apellido1Parameter, apellido2Parameter, correoParameter, telefonoParameter, passwordParameter, user_nameParameter, id_rolParameter);
        }
    
        public virtual ObjectResult<string> UsernameAvailable(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("UsernameAvailable", usernameParameter);
        }
    }
}
