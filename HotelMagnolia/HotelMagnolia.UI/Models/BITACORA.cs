//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class BITACORA
    {
        public string ID_BITACORA { get; set; }
        public string ID_USUARIO { get; set; }
        public System.DateTime FECHA { get; set; }
        public string CODIGO { get; set; }
        public int TIPO { get; set; }
        public string Descripcion { get; set; }
        public string Registro_en_detalle { get; set; }
    
        public virtual TIPO_BITACORA TIPO_BITACORA { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
