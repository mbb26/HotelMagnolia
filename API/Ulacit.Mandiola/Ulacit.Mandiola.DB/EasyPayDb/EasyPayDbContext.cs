namespace Ulacit.Mandiola.DB.EasyPayDb
{
    using System.Data.Entity;

    public partial class EasyPayDbContext : DbContext
    {
        public EasyPayDbContext()
            : base("name=EasyPayDbContext")
        {
        }

        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}