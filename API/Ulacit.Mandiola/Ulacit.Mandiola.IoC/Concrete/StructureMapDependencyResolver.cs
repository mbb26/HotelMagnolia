using System;
using log4net;
using StructureMap;
using Ulacit.Mandiola.IoC.Abstract;
using Ulacit.Mandiola.IoC.Enum;
using Ulacit.Mandiola.IoC.Helper;

namespace Ulacit.Mandiola.IoC.Concrete
{
    /// <summary>A structure map dependency resolver. This class cannot be inherited.</summary>
    [Dependency(DependencyScope.Singleton)]
    internal sealed class StructureMapDependencyResolver : IDependencyResolver, IDependencyRegister, IDisposable
    {
        /// <summary>The container.</summary>
        private readonly IContainer _container;

        /// <summary>The log.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(StructureMapDependencyResolver));

        /// <summary>Initializes a new instance of the Cenfo.KeepKnowledge.Ioc.Concrete.StructureMapDependencyResolver class.</summary>
        /// <param name="container">The container.</param>
        public StructureMapDependencyResolver(IContainer container)
        {
            ParameterValidator.ValidateNotNullParameters("container", container);

            this._container = container;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this._container.Dispose();
        }

        /// <summary>Gets an instance of the <typeparamref name="T"/> type.</summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>An instance of the <typeparamref name="T"/> type.</returns>
        public T Get<T>()
        {
            try
            {
                return this._container.GetInstance<T>();
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                throw;
            }
        }

        /// <summary>Gets an instance of the type indicated.</summary>
        /// <param name="type">.</param>
        /// <returns>An instance of the type.</returns>
        public object Get(Type type)
        {
            try
            {
                return this._container.GetInstance(type);
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                throw;
            }
        }

        /// <summary>Registers this object.</summary>
        /// <typeparam name="TReturned">Type of the returned.</typeparam>
        /// <param name="object">The object.</param>
        public void Register<TReturned>(TReturned @object) where TReturned : class
        {
            this._container.Configure(configure => configure.For<TReturned>().Use(@object));
        }
    }
}