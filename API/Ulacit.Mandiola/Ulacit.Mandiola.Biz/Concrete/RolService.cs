using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing rols information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class RolService : BasicService, IRolService
    {
        /// <summary>Context for the rol.</summary>
        private readonly IRolContext _rolContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.RolService class.</summary>
        /// <param name="rolContext">Context for the rol.</param>
        public RolService(IRolContext rolContext) : base(rolContext)
        {
            _rolContext = rolContext;
        }
    }
}