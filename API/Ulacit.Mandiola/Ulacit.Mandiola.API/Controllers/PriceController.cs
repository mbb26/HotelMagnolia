using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling prices.</summary>
    public class PriceController : BaseApiController
    {
        /// <summary>The price service.</summary>
        private readonly IPriceService _priceService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.PriceController class.</summary>
        /// <param name="priceService">The price service.</param>
        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;PRECIO&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;PRECIO&gt;</returns>
        [HttpPost]
        public ApiResultModel<PRECIO> Create([FromBody]PRECIO aux) => GetApiResultModel(() => _priceService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]PRECIO aux) => GetApiResultModel(() => _priceService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<PRECIO>> GetAll() => GetApiResultModel(() => _priceService.GetAll<PRECIO>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<PRECIO> GetById([FromUri]int id) => GetApiResultModel(() => _priceService.GetById<PRECIO>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;PRECIO&gt;</returns>
        [HttpPut]
        public ApiResultModel<PRECIO> Update([FromBody]PRECIO aux) => GetApiResultModel(() => _priceService.Update(aux));
    }
}