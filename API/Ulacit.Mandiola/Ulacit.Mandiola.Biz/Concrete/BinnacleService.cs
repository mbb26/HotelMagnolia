using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing binnacles information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class BinnacleService : BasicService, IBinnacleService
    {
        /// <summary>Context for the binnacle.</summary>
        private readonly IBinnacleContext _binnacleContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.BinnacleService class.</summary>
        /// <param name="binnacleContext">Context for the binnacle.</param>
        public BinnacleService(IBinnacleContext binnacleContext) : base(binnacleContext)
        {
            _binnacleContext = binnacleContext;
        }
    }
}