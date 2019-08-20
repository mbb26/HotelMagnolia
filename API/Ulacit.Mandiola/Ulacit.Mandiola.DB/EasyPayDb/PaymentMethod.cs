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

        public DateTime ExpiredDate { get; set; }

        [Required]
        [StringLength(10)]
        public string Cvv { get; set; }

        [Required]
        [StringLength(1000)]
        public string Email { get; set; }
    }
}