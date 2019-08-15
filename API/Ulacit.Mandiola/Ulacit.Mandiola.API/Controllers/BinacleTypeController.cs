using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling binacle types.</summary>
    public class BinacleTypeController : BaseApiController
    {
        /// <summary>The binacle type service.</summary>
        private readonly IBinacleTypeService _binacleTypeService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.BinacleTypeController class.</summary>
        /// <param name="binacleTypeService">The binacle type service.</param>
        public BinacleTypeController(IBinacleTypeService binacleTypeService)
        {
            _binacleTypeService = binacleTypeService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;TIPO_BITACORA&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;TIPO_BITACORA&gt;</returns>
        [HttpPost]
        public ApiResultModel<TIPO_BITACORA> Create([FromBody]TIPO_BITACORA aux) => GetApiResultModel(() => _binacleTypeService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]TIPO_BITACORA aux) => GetApiResultModel(() => _binacleTypeService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<TIPO_BITACORA>> GetAll() => GetApiResultModel(() => _binacleTypeService.GetAll<TIPO_BITACORA>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<TIPO_BITACORA> GetById([FromUri]int id) => GetApiResultModel(() => _binacleTypeService.GetById<TIPO_BITACORA>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;TIPO_BITACORA&gt;</returns>
        [HttpPut]
        public ApiResultModel<TIPO_BITACORA> Update([FromBody]TIPO_BITACORA aux) => GetApiResultModel(() => _binacleTypeService.Update(aux));
    }
}