using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;
using System.Web.Http.Cors;
using System;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling users.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class HabitacionesEnReservacionController : BaseApiController
    {
        /// <summary>The Room in reservation service.</summary>
        private readonly IHabitacionesEnReservacionService _HabitacionesEnReservacionService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.HabitacionesEnReservacionController class.</summary>
        /// <param name="HabitacionesEnReservacionService">The _HabitacionesEnReservacion service.</param>
        public HabitacionesEnReservacionController(IHabitacionesEnReservacionService HabitacionesEnReservacionService)
        {
            _HabitacionesEnReservacionService = HabitacionesEnReservacionService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;HabitacionesEnReservacion&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;HabitacionesEnReservacion&gt;</returns>
        [HttpPost]
        public ApiResultModel<HabitacionesEnReservacion> Create([FromBody]HabitacionesEnReservacion aux) => GetApiResultModel(() => _HabitacionesEnReservacionService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]HabitacionesEnReservacion aux) => GetApiResultModel(() => _HabitacionesEnReservacionService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<HabitacionesEnReservacion>> GetAll() => GetApiResultModel(() => _HabitacionesEnReservacionService.GetAll<HabitacionesEnReservacion>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<HabitacionesEnReservacion> GetById([FromUri]int id) => GetApiResultModel(() => _HabitacionesEnReservacionService.GetById<HabitacionesEnReservacion>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;HabitacionesEnReservacion&gt;</returns>
        [HttpPut]
        public ApiResultModel<HabitacionesEnReservacion> Update([FromBody]HabitacionesEnReservacion aux) => GetApiResultModel(() => _HabitacionesEnReservacionService.Update(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets rooms by reservation ID.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Rooms by reservation.</returns>
        [HttpGet]
        public ApiResultModel<List<HabitacionesEnReservacion>> GetJoinHabsEnResv([FromUri]string id) => GetApiResultModel(() => _HabitacionesEnReservacionService.GetJoinHabsEnResv<HabitacionesEnReservacion>(id));



    }
}