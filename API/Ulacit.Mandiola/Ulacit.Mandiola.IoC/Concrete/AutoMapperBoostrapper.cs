using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Ulacit.Mandiola.IoC.Abstract;

namespace Ulacit.Mandiola.IoC.Concrete
{
    /// <summary>An automatic mapper boostrapper.</summary>
    public static class AutoMapperBoostrapper
    {
        /// <summary>Bootstraps the given filter.</summary>
        /// <param name="filter">(Optional) Specifies the filter.</param>
        /// <returns>An IMapper.</returns>
        public static IMapper Bootstrap(string filter = null)
        {
            var container = new MapperConfiguration(cfg =>
            {
                filter = filter != null ? filter + ".dll" : "*.dll";

                foreach (var assembly in Directory.EnumerateFiles(AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory, filter).Select(Assembly.LoadFrom))
                {
                    foreach (var config in assembly.GetTypes().Where(x => !x.IsAbstract && x.IsClass && x.GetInterfaces().Any(a => a == typeof(IAutoMapperConfig))).Select(s => (IAutoMapperConfig)Activator.CreateInstance(s)))
                    {
                        config.Config(cfg);
                    }
                }
            });

            return container.CreateMapper();
        }
    }
}