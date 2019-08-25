using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;
using System.Web.Http.Cors;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling room types.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RoomTypeController : BaseApiController
    {
        /// <summary>The room type service.</summary>
        private readonly IRoomTypeService _roomTypeService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.RoomTypeController class.</summary>
        /// <param name="roomTypeService">The room type service.</param>
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;TIPO_HABITACION&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;TIPO_HABITACION&gt;</returns>
        [HttpPost]
        public ApiResultModel<TIPO_HABITACION> Create([FromBody]TIPO_HABITACION aux) => GetApiResultModel(() => _roomTypeService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]TIPO_HABITACION aux) => GetApiResultModel(() => _roomTypeService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<TIPO_HABITACION>> GetAll() => GetApiResultModel(() => _roomTypeService.GetAll<TIPO_HABITACION>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<TIPO_HABITACION> GetById([FromUri]int id) => GetApiResultModel(() => _roomTypeService.GetById<TIPO_HABITACION>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;TIPO_HABITACION&gt;</returns>
        [HttpPut]
        public ApiResultModel<TIPO_HABITACION> Update([FromBody]TIPO_HABITACION aux) => GetApiResultModel(() => _roomTypeService.Update(aux));
    }
}