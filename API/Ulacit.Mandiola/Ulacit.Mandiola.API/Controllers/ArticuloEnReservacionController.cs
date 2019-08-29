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
    public class ArticuloEnReservacionController : BaseApiController
    {
        /// <summary>The Room in reservation service.</summary>
        private readonly IArticuloEnReservacionService _ArticuloEnReservacionService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ArticuloEnReservacionController class.</summary>
        /// <param name="ArticuloEnReservacionService">The _ArticuloEnReservacion service.</param>
        public ArticuloEnReservacionController(IArticuloEnReservacionService ArticuloEnReservacionService)
        {
            _ArticuloEnReservacionService = ArticuloEnReservacionService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;ArticuloEnReservacion&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ArticuloEnReservacion&gt;</returns>
        [HttpPost]
        public ApiResultModel<ArticuloEnReservacion> Create([FromBody]ArticuloEnReservacion aux) => GetApiResultModel(() => _ArticuloEnReservacionService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]ArticuloEnReservacion aux) => GetApiResultModel(() => _ArticuloEnReservacionService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<ArticuloEnReservacion>> GetAll() => GetApiResultModel(() => _ArticuloEnReservacionService.GetAll<ArticuloEnReservacion>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<ArticuloEnReservacion> GetById([FromUri]int id) => GetApiResultModel(() => _ArticuloEnReservacionService.GetById<ArticuloEnReservacion>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ArticuloEnReservacion&gt;</returns>
        [HttpPut]
        public ApiResultModel<ArticuloEnReservacion> Update([FromBody]ArticuloEnReservacion aux) => GetApiResultModel(() => _ArticuloEnReservacionService.Update(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets rooms by reservation ID.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Rooms by reservation.</returns>
        [HttpGet]
        public ApiResultModel<List<ArticuloEnReservacion>> GetJoinArtcsEnResv([FromUri]string id) => GetApiResultModel(() => _ArticuloEnReservacionService.GetJoinArtcsEnResv<ArticuloEnReservacion>(id));

    }
}