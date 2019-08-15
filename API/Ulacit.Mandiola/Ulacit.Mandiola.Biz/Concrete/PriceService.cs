using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing prices information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class PriceService : BasicService, IPriceService
    {
        /// <summary>Context for the price.</summary>
        private readonly IPriceContext _priceContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.PriceService class.</summary>
        /// <param name="priceContext">Context for the price.</param>
        public PriceService(IPriceContext priceContext) : base(priceContext)
        {
            _priceContext = priceContext;
        }
    }
}