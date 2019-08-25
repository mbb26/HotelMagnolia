using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;
using System.Web.Http.Cors;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling reservations.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservationController : BaseApiController
    {
        /// <summary>The reservation service.</summary>
        private readonly IReservationService _reservationService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ReservationController class.</summary>
        /// <param name="reservationService">The reservation service.</param>
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;RESERVACION&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;RESERVACION&gt;</returns>
        [HttpPost]
        public ApiResultModel<RESERVACION> Create([FromBody]RESERVACION aux) => GetApiResultModel(() => _reservationService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]RESERVACION aux) => GetApiResultModel(() => _reservationService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<RESERVACION>> GetAll() => GetApiResultModel(() => _reservationService.GetAll<RESERVACION>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<RESERVACION> GetById([FromUri]int id) => GetApiResultModel(() => _reservationService.GetById<RESERVACION>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;RESERVACION&gt;</returns>
        [HttpPut]
        public ApiResultModel<RESERVACION> Update([FromBody]RESERVACION aux) => GetApiResultModel(() => _reservationService.Update(aux));
    }
}