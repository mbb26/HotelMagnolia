using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing clients information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class ClientService : BasicService, IClientService
    {
        /// <summary>Context for the client.</summary>
        private readonly IClientContext _clientContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.ClientService class.</summary>
        /// <param name="clientContext">Context for the client.</param>
        public ClientService(IClientContext clientContext) : base(clientContext)
        {
            _clientContext = clientContext;
        }
    }
}