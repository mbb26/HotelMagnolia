namespace Ulacit.Mandiola.DB.EasyPayDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        [Key]
        [StringLength(1000)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string LastName { get; set; }
    }
}