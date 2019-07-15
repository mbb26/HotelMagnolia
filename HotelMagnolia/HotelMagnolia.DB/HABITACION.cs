namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HABITACION")]
    public partial class HABITACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HABITACION()
        {
            RESERVACIONs = new HashSet<RESERVACION>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_HABITAICIONES { get; set; }

        public int NUMERO { get; set; }

        [Required]
        public string NOMBRE { get; set; }

        [Required]
        public byte[] DESCRIPCION { get; set; }

        public virtual CONSECUTIVO CONSECUTIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVACION> RESERVACIONs { get; set; }
    }
}
