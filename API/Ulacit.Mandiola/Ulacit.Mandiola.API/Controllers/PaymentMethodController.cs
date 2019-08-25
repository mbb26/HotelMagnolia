using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;
using System.Web.Http.Cors;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling activities.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaymentMethodController : BaseApiController
    {
        /// <summary>The activity service.</summary>
        private readonly IPaymentMethodsService _paymentMethodService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ActivityController class.</summary>
        /// <param name="userEasyPayService">The activity service.</param>
        public PaymentMethodController(IPaymentMethodsService userEasyPayService)
        {
            _paymentMethodService = userEasyPayService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;ACTIVIDAD&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ACTIVIDAD&gt;</returns>
        [HttpPost]
        public ApiResultModel<PaymentMethod> Create([FromBody]PaymentMethod aux) => GetApiResultModel(() => _paymentMethodService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]PaymentMethod aux) => GetApiResultModel(() => _paymentMethodService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<PaymentMethod>> GetAll() => GetApiResultModel(() => _paymentMethodService.GetAll<PaymentMethod>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<PaymentMethod> GetById([FromUri]int id) => GetApiResultModel(() => _paymentMethodService.GetById<PaymentMethod>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ACTIVIDAD&gt;</returns>
        [HttpPut]
        public ApiResultModel<PaymentMethod> Update([FromBody]PaymentMethod aux) => GetApiResultModel(() => _paymentMethodService.Update(aux));
    }
}