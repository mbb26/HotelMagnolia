namespace HotelMagnolia.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            BITACORAs = new HashSet<BITACORA>();
            TARJETAs = new HashSet<TARJETA>();
            RESERVACIONs = new HashSet<RESERVACION>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_USUARIO { get; set; }

        [Required]
        public string NOMBRE { get; set; }

        [Required]
        public string APELLIDO1 { get; set; }

        [Required]
        public string APELLIDO2 { get; set; }

        [Required]
        public string CORREO { get; set; }

        public int TELEFONO { get; set; }

        [Required]
        public string PASSWORD { get; set; }

        [Required]
        public string USER_NAME { get; set; }

        public int? ID_ROL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BITACORA> BITACORAs { get; set; }

        public virtual ROL ROL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TARJETA> TARJETAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVACION> RESERVACIONs { get; set; }
    }
}
