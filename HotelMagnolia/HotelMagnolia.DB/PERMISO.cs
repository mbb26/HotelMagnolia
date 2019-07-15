namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERMISO")]
    public partial class PERMISO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PERMISO { get; set; }

        public string NOMBRE { get; set; }

        public string DESCRIPCION { get; set; }
    }
}
