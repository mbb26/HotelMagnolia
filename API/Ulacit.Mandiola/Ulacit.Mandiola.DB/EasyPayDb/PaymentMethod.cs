namespace Ulacit.Mandiola.DB.EasyPayDb
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PaymentMethod")]
    public partial class PaymentMethod
    {
        public int ID { get; set; }

        [Required]
        [StringLength(1000)]
        public string CardNumber { get; set; }


        [Required]
        [StringLength(1000)]
        public string ExpiredDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Cvv { get; set; }

        [Required]
        [StringLength(1000)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string Nombre { get; set; }
    }
}