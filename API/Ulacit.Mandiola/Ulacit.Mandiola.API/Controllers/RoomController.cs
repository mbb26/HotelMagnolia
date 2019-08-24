using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling rooms.</summary>
    public class RoomController : BaseApiController
    {
        /// <summary>The room service.</summary>
        private readonly IRoomService _roomService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.RoomController class.</summary>
        /// <param name="roomService">The room service.</param>
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;HABITACION&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;HABITACION&gt;</returns>
        [HttpPost]
        public ApiResultModel<HABITACION> Create([FromBody]HABITACION aux) => GetApiResultModel(() => _roomService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]HABITACION aux) => GetApiResultModel(() => _roomService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<HABITACION>> GetAll() => GetApiResultModel(() => _roomService.GetAll<HABITACION>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<HABITACION> GetById([FromUri]int id) => GetApiResultModel(() => _roomService.GetById<HABITACION>(id));

        /// <summary>(An Action that handles HTTP GET requests) gets Available Rooms.</summary>
        /// <returns>The by the availability of a room.</returns>
        [HttpGet]
        public ApiResultModel<HABITACION> GetAvailable() => GetApiResultModel(() => _roomService.GetAvailable<HABITACION>());

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;HABITACION&gt;</returns>
        [HttpPut]
        public ApiResultModel<HABITACION> Update([FromBody]HABITACION aux) => GetApiResultModel(() => _roomService.Update(aux));
    }
}