namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACTIVIDAD")]
    public partial class ACTIVIDAD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ACTIVIDAD { get; set; }

        public string NOMBRE { get; set; }

        public string DESCRIPCION { get; set; }

        public byte[] IMG { get; set; }

        public virtual CONSECUTIVO CONSECUTIVO { get; set; }
    }
}
