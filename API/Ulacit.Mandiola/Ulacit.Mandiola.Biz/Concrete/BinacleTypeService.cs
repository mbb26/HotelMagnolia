using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing binacle types information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class BinacleTypeService : BasicService, IBinacleTypeService
    {
        /// <summary>Context for the binacle type.</summary>
        private readonly IBinacleTypeContext _binacleTypeContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.BinacleTypeService class.</summary>
        /// <param name="binacleTypeContext">Context for the binacle type.</param>
        public BinacleTypeService(IBinacleTypeContext binacleTypeContext) : base(binacleTypeContext)
        {
            _binacleTypeContext = binacleTypeContext;
        }
    }
}