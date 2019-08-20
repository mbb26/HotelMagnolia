using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing activities information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class PaymentMethodsService : BasicService, IPaymentMethodsService
    {
        /// <summary>Context for the activity.</summary>
        private readonly IPaymentMethodContext _paymentMethodsService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.PaymentMethodsService class.</summary>
        /// <param name="activityContext">Context for the paymentMethodsService.</param>
        public PaymentMethodsService(IPaymentMethodContext paymentMethodsService) : base(paymentMethodsService)
        {
            _paymentMethodsService = paymentMethodsService;
        }
    }
}