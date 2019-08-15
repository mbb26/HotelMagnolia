using System.Collections.Generic;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Model;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling articles.</summary>
    public class ArticleController : BaseApiController
    {
        /// <summary>The article service.</summary>
        private readonly IArticleService _articleService;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Controllers.ArticleController class.</summary>
        /// <param name="articleService">The article service.</param>
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>(An Action that handles HTTP POST requests) creates a new ApiResultModel&lt;ARTICULO&gt;</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ARTICULO&gt;</returns>
        [HttpPost]
        public ApiResultModel<ARTICULO> Create([FromBody]ARTICULO aux) => GetApiResultModel(() => _articleService.Create(aux));

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;bool&gt;</returns>
        [HttpDelete]
        public ApiResultModel<bool> Delete([FromBody]ARTICULO aux) => GetApiResultModel(() => _articleService.Delete(aux));

        /// <summary>(An Action that handles HTTP GET requests) gets all.</summary>
        /// <returns>all.</returns>
        [HttpGet]
        public ApiResultModel<List<ARTICULO>> GetAll() => GetApiResultModel(() => _articleService.GetAll<ARTICULO>());

        /// <summary>(An Action that handles HTTP GET requests) gets by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        [HttpGet]
        public ApiResultModel<ARTICULO> GetById([FromUri]int id) => GetApiResultModel(() => _articleService.GetById<ARTICULO>(id));

        /// <summary>(An Action that handles HTTP PUT requests) updates the given aux.</summary>
        /// <param name="aux">The auxiliary.</param>
        /// <returns>An ApiResultModel&lt;ARTICULO&gt;</returns>
        [HttpPut]
        public ApiResultModel<ARTICULO> Update([FromBody]ARTICULO aux) => GetApiResultModel(() => _articleService.Update(aux));
    }
}