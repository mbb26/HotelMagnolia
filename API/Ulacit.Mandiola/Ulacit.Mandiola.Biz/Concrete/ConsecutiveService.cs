using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing consecutives information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class ConsecutiveService : BasicService, IConsecutiveService
    {
        /// <summary>Context for the consecutive.</summary>
        private readonly IConsecutiveContext _consecutiveContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.ConsecutiveService class.</summary>
        /// <param name="consecutiveContext">Context for the consecutive.</param>
        public ConsecutiveService(IConsecutiveContext consecutiveContext) : base(consecutiveContext)
        {
            _consecutiveContext = consecutiveContext;
        }
    }
}