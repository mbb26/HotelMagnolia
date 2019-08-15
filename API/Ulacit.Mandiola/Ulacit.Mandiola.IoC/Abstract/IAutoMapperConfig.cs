using AutoMapper;

namespace Ulacit.Mandiola.IoC.Abstract
{
    /// <summary>Interface for automatic mapper configuration.</summary>
    public interface IAutoMapperConfig
    {
        /// <summary>Configurations the given configuration.</summary>
        /// <param name="configuration">The configuration.</param>
        void Config(IMapperConfigurationExpression configuration);
    }
}