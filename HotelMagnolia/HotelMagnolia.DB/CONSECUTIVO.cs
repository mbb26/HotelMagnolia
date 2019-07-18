namespace HotelMagnolia.DB
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CONSECUTIVO")]
    public partial class CONSECUTIVO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_CONSECUTIVOS { get; set; }

        public string NOMBRE { get; set; }

        public int VALOR { get; set; }

        public bool TIENE_PREFIJO { get; set; }

        public string PREFIJO { get; set; }

        public bool POSEE_RANGO { get; set; }

        public int? RANGO_INICIAL { get; set; }

        public int? RANGO_FINAL { get; set; }
    }
}