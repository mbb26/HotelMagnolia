namespace Ulacit.Mandiola.DB.MandiolaDb
{
    using System.Data.Entity;

    /// <summary>A mandiola database context.</summary>
    public partial class MandiolaDbContext : DbContext
    {
        /// <summary>Initializes a new instance of the Ulacit.Mandiola.DB.MandiolaDb.MandiolaDbContext class.</summary>
        public MandiolaDbContext()
            : base("name=MandiolaDbContext")
        {
        }

        /// <summary>Gets or sets the activida ds.</summary>
        /// <value>The activida ds.</value>
        public virtual DbSet<ACTIVIDAD> ACTIVIDADs { get; set; }

        /// <summary>Gets or sets the articul oes.</summary>
        /// <value>The articul oes.</value>
        public virtual DbSet<ARTICULO> ARTICULOes { get; set; }

        /// <summary>Gets or sets the bitacor as.</summary>
        /// <value>The bitacor as.</value>
        public virtual DbSet<BITACORA> BITACORAs { get; set; }

        /// <summary>Gets or sets the client es.</summary>
        /// <value>The client es.</value>
        public virtual DbSet<CLIENTE> CLIENTEs { get; set; }

        /// <summary>Gets or sets the consecutiv oes.</summary>
        /// <value>The consecutiv oes.</value>
        public virtual DbSet<CONSECUTIVO> CONSECUTIVOes { get; set; }

        /// <summary>Gets or sets the estado reservacion.</summary>
        /// <value>The estado reservacion.</value>
        public virtual DbSet<ESTADO_RESERVACION> ESTADO_RESERVACION { get; set; }

        /// <summary>Gets or sets the habitacio ns.</summary>
        /// <value>The habitacio ns.</value>
        public virtual DbSet<HABITACION> HABITACIONs { get; set; }

        /// <summary>Gets or sets the Habitaciones En Reservacion.</summary>
        /// <value>The Habitaciones En Reservacion.</value>
        public virtual DbSet<HabitacionesEnReservacion> HabitacionesEnReservacion { get; set; }

        /// <summary>Gets or sets the preci operating system.</summary>
        /// <value>The preci operating system.</value>
        public virtual DbSet<PRECIO> PRECIOs { get; set; }

        /// <summary>Gets or sets the reservacio ns.</summary>
        /// <value>The reservacio ns.</value>
        public virtual DbSet<RESERVACION> RESERVACIONs { get; set; }

        /// <summary>Gets or sets the ro ls.</summary>
        /// <value>The ro ls.</value>
        public virtual DbSet<ROL> ROLs { get; set; }

        /// <summary>Gets or sets the tipo bitacora.</summary>
        /// <value>The tipo bitacora.</value>
        public virtual DbSet<TIPO_BITACORA> TIPO_BITACORA { get; set; }

        /// <summary>Gets or sets the tipo habitacion.</summary>
        /// <value>The tipo habitacion.</value>
        public virtual DbSet<TIPO_HABITACION> TIPO_HABITACION { get; set; }

        /// <summary>Gets or sets the usuari operating system.</summary>
        /// <value>The usuari operating system.</value>
        public virtual DbSet<USUARIO> USUARIOs { get; set; }

        /// <summary>This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.</summary>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.</remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}