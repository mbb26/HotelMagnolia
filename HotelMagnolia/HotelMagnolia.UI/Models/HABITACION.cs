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
    
    public partial class HABITACION
    {
        public string ID_HABITACION { get; set; }
        public int NUMERO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string FOTO { get; set; }
        public int TIPO_HABITACION { get; set; }
        public string ID_PRECIO { get; set; }
        public Nullable<bool> DISPONIBLE { get; set; }
    
        public virtual PRECIO PRECIO { get; set; }
        public virtual TIPO_HABITACION TIPO_HABITACION1 { get; set; }
    }
}
