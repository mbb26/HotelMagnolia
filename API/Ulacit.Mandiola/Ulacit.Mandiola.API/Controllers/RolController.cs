using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling rols.</summary>
    public class RolController : BaseApiController
    {
        /// <summary>The rol service.</summary>
        private readonly IRolService _rolService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.RolController class.</summary>
        /// <param name="rolService">The rol service.</param>
        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;ROL&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ROL&gt;</returns>
        [HttpPost]
        public ApiResultModel<ROL> Create([FromBody]ROL aux) => GetApiResultModel(() => _rolService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]ROL aux) => GetApiResultModel(() => _rolService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<ROL>> GetAll() => GetApiResultModel(() => _rolService.GetAll<ROL>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<ROL> GetById([FromUri]int id) => GetApiResultModel(() => _rolService.GetById<ROL>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ROL&gt;</returns>
        [HttpPut]
        public ApiResultModel<ROL> Update([FromBody]ROL aux) => GetApiResultModel(() => _rolService.Update(aux));
    }
}