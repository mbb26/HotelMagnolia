using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;
using System.Web.Http.Cors;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling reservation states.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservationStateController : BaseApiController
    {
        /// <summary>The reservation state service.</summary>
        private readonly IReservationStateService _reservationStateService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ReservationStateController class.</summary>
        /// <param name="reservationStateService">The reservation state service.</param>
        public ReservationStateController(IReservationStateService reservationStateService)
        {
            _reservationStateService = reservationStateService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;ESTADO_RESERVACION&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ESTADO_RESERVACION&gt;</returns>
        [HttpPost]
        public ApiResultModel<ESTADO_RESERVACION> Create([FromBody]ESTADO_RESERVACION aux) => GetApiResultModel(() => _reservationStateService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]ESTADO_RESERVACION aux) => GetApiResultModel(() => _reservationStateService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<ESTADO_RESERVACION>> GetAll() => GetApiResultModel(() => _reservationStateService.GetAll<ESTADO_RESERVACION>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<ESTADO_RESERVACION> GetById([FromUri]int id) => GetApiResultModel(() => _reservationStateService.GetById<ESTADO_RESERVACION>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ESTADO_RESERVACION&gt;</returns>
        [HttpPut]
        public ApiResultModel<ESTADO_RESERVACION> Update([FromBody]ESTADO_RESERVACION aux) => GetApiResultModel(() => _reservationStateService.Update(aux));
    }
}