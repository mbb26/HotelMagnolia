namespace Ulacit.Mandiola.IoC.Enum
{
    /// <summary>Enumerates the dependency injection scopes.</summary>
    public enum DependencyScope
    {
        /// <summary>
        /// A new instance gets created every time.
        /// </summary>
        Transient,

        /// <summary>
        /// A single instance gets created for the whole lifecycle of the application.
        /// </summary>
        Singleton,

        /// <summary>
        /// An single instance gets created for each thread.
        /// </summary>
        Thread,
    }
}