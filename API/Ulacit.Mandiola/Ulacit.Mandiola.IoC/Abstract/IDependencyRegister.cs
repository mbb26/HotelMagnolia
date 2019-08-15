namespace Ulacit.Mandiola.IoC.Abstract
{
    /// <summary>Represents a dependency register.</summary>
    public interface IDependencyRegister
    {
        /// <summary>Registers this object.</summary>
        /// <typeparam name="TReturned">Type of the returned.</typeparam>
        /// <param name="object">The object.</param>
        void Register<TReturned>(TReturned @object) where TReturned : class;
    }
}