using System;
using System.IO;
using System.Linq;
using System.Reflection;
using StructureMap;
using StructureMap.Pipeline;
using Ulacit.Mandiola.IoC.Enum;
using Ulacit.Mandiola.IoC.Helper;

namespace Ulacit.Mandiola.IoC.Concrete
{
    /// <summary>A structure map bootstrapper.</summary>
    public static class StructureMapBootstrapper
    {
        /// <summary>Bootstraps.</summary>
        /// <param name="filters">The filters.</param>
        /// <returns>An IContainer.</returns>
        public static IContainer Bootstrap(string[] filters)
        {
            var container = new Container();

            foreach (var filter in filters)
            {
                StructureMapBootstrapper.Bootstrap(container, filter);
            }

            return container;
        }

        /// <summary>Bootstraps.</summary>
        /// <param name="filter">(Optional) Specifies the filter.</param>
        /// <returns>An IContainer.</returns>
        public static IContainer Bootstrap(string filter = null)
        {
            var container = new Container();

            StructureMapBootstrapper.Bootstrap(container, filter);

            return container;
        }

        /// <summary>Bootstraps.</summary>
        /// <param name="container">The container.</param>
        /// <param name="filter">   (Optional) Specifies the filter.</param>
        public static void Bootstrap(IContainer container, string filter = null)
        {
            ParameterValidator.ValidateNotNullParameters("container", container);

            filter = filter != null ? filter + ".dll" : "*.dll";

            foreach (var assembly in Directory.EnumerateFiles(AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory, filter).Select(Assembly.LoadFrom))
            {
                foreach (var type in assembly.GetTypes().Where(x => x.IsClass && x.GetCustomAttribute<DependencyAttribute>() != null))
                {
                    container.Configure(x =>
                    {
                        foreach (var interfaces in type.GetInterfaces().Where(w => w != typeof(IDisposable)))
                        {
                            var instance = x.For(interfaces).Use(type).Named(type.FullName);

                            switch (type.GetCustomAttribute<DependencyAttribute>().Scope)
                            {
                                case DependencyScope.Singleton:
                                    instance.Singleton();
                                    break;

                                case DependencyScope.Thread:
                                    instance.SetLifecycleTo<ThreadLocalStorageLifecycle>();
                                    break;

                                case DependencyScope.Transient:
                                    instance.Transient();
                                    break;
                            }
                        }
                    }
                    );
                }
            }
        }
    }
}