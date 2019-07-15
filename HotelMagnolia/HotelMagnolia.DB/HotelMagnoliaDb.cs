namespace HotelMagnolia.DB
{
    using System.Data.Entity;

    public partial class HotelMagnoliaDb : DbContext
    {
        public HotelMagnoliaDb()
            : base("name=HotelMagnolia")
        {
        }

        public virtual DbSet<ACTIVIDAD> ACTIVIDADs { get; set; }
        public virtual DbSet<ARTICULO> ARTICULOes { get; set; }
        public virtual DbSet<BITACORA> BITACORAs { get; set; }
        public virtual DbSet<CONSECUTIVO> CONSECUTIVOes { get; set; }
        public virtual DbSet<HABITACION> HABITACIONs { get; set; }
        public virtual DbSet<PERMISO> PERMISOes { get; set; }
        public virtual DbSet<PRECIO> PRECIOs { get; set; }
        public virtual DbSet<ROL> ROLs { get; set; }
        public virtual DbSet<TARJETA> TARJETAs { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
        public virtual DbSet<EasyPay> EasyPays { get; set; }
        public virtual DbSet<RESERVACION> RESERVACIONs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}