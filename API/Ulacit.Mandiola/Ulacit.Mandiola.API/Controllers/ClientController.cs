using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling clients.</summary>
    public class ClientController : BaseApiController
    {
        /// <summary>The client service.</summary>
        private readonly IClientService _clientService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ClientController class.</summary>
        /// <param name="clientService">The client service.</param>
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;CLIENTE&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;CLIENTE&gt;</returns>
        [HttpPost]
        public ApiResultModel<CLIENTE> Create([FromBody]CLIENTE aux) => GetApiResultModel(() => _clientService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]CLIENTE aux) => GetApiResultModel(() => _clientService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<CLIENTE>> GetAll() => GetApiResultModel(() => _clientService.GetAll<CLIENTE>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<CLIENTE> GetById([FromUri]int id) => GetApiResultModel(() => _clientService.GetById<CLIENTE>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;CLIENTE&gt;</returns>
        [HttpPut]
        public ApiResultModel<CLIENTE> Update([FromBody]CLIENTE aux) => GetApiResultModel(() => _clientService.Update(aux));
    }
}